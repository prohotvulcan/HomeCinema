using AutoMapper;
using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using homeCinema.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homeCinema.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenresController(IRepository<Genre> genreRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreRepository.AllIncludeAsync(x => x.Movies);
            var genreVms = _mapper.Map<List<Genre>, List<GenreViewModel>>(genres)
                .Where(x => x.NumberOfMovies > 0);

            if (genreVms != null)
            {
                return Ok(genreVms);
            }
            else
            {
                return BadRequest("Genre not exist.");
            }
        }
    }
}
