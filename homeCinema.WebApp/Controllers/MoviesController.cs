using AutoMapper;
using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using homeCinema.WebApp.Infrastructures.Core;
using homeCinema.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace homeCinema.WebApp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Error> _errorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoviesController(IRepository<Movie> movieRepository,
            IRepository<Error> errorRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieRepository.AllIncludeAsync(x => x.Stocks, x => x.Genre);

            List<MovieViewModel> moviesVm = _mapper.Map<List<Movie>, List<MovieViewModel>>(movies);

            moviesVm = moviesVm.OrderByDescending(x => x.ReleaseDate).Take(6).ToList();

            if (moviesVm != null)
            {
                return Ok(moviesVm);
            }
            else
            {
                return BadRequest("No data!");
            }
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var movie = await _movieRepository.GetSingleAsync(id);
            var movieVm = _mapper.Map<Movie, MovieViewModel>(movie);

            if (movieVm != null)
            {
                return Ok(movie);
            }
            else
            {
                return BadRequest("The movie does not exist");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public async Task<IActionResult> Get([FromRoute]int? page, [FromRoute]int? pageSize, [FromRoute]string filter)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            var result = await _movieRepository
                .FindByAsync(x => x.Title.ToLower().Contains(filter));
            int totalMovies = result.Count;

            // paging
            var movies = result
                .OrderBy(x => x.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize);

            IEnumerable<MovieViewModel> moviesVm = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

            PaginationSet<MovieViewModel> response = new PaginationSet<MovieViewModel>
            {
                Items = moviesVm,
                Page = currentPage,
                TotalCount = totalMovies
            };

            if (moviesVm != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("No data!");
            }

        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] MovieViewModel movieVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newMovie = _mapper.Map<MovieViewModel, Movie>(movieVm);
                for (int i = 0; i < movieVm.NumberOfStocks; i++)
                {
                    Stock stock = new Stock
                    {
                        IsAvailable = true,
                        Movie = newMovie,
                        UniqueKey = new Guid()
                    };
                    newMovie.Stocks.Add(stock);
                }

                _movieRepository.Add(newMovie);
                await _unitOfWork.CommitAsync();

                return Ok(_mapper.Map<Movie, MovieViewModel>(newMovie));
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] MovieViewModel movieVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var movieDb = await _movieRepository.GetSingleAsync(movieVm.Id);
                if (movieDb == null)
                {
                    return BadRequest("Invalid movie.");
                }

                var movie = _mapper.Map<MovieViewModel, Movie>(movieVm);
                movie.Image = movieDb.Image;
                _movieRepository.Edit(movie);

                await _unitOfWork.CommitAsync();
                return Ok(movie);
            }
        }

        [HttpPost]
        [Route("images/upload")]
        public async Task<IActionResult> PostAsync([FromForm] int movieId, [FromForm] IFormFile file)
        {
            var movieDb = await _movieRepository.GetSingleAsync(movieId);
            if (movieDb == null)
                return BadRequest("Invalid movie.");

            try
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot/images/movies", file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                // update image
                movieDb.Image = file.FileName;
                _movieRepository.Edit(movieDb);
                await _unitOfWork.CommitAsync();

                return Ok(new { success = true, message = "Upload successfuly." });
            }
            catch (Exception)
            {
                return BadRequest("Upload failed.");
            }
        }
    }
}