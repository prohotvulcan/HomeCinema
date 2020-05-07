using AutoMapper;
using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using homeCinema.WebApp.Infrastructures.Core;
using homeCinema.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homeCinema.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IRepository<Customer> customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            List<Customer> customers = null;
            if (string.IsNullOrEmpty(filter))
            {
                customers = await _customerRepository.GetAllAsync();
            }
            else
            {
                filter = filter.Trim().ToLower();
                customers = await _customerRepository.FindByAsync(x => x.LastName.ToLower().Contains(filter)
                || x.IdentityCard.ToLower().Contains(filter)
                || x.FirstName.ToLower().Contains(filter));

                customers = customers.OrderBy(x => x.Id).ToList();
            }

            int totalCustomer = customers.Count;

            customers = customers
                .Skip(currentPage * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            List<CustomerViewModel> customerVm = _mapper.Map<List<Customer>, List<CustomerViewModel>>(customers);
            PaginationSet<CustomerViewModel> pagination = new PaginationSet<CustomerViewModel>
            {
                Items = customerVm,
                Page = currentPage,
                PageSize = currentPageSize,
                TotalCount = totalCustomer
            };

            return Ok(pagination);
        }

        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CustomerViewModel customerVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Keys
                    .SelectMany(x => ModelState[x].Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray());
            }
            else
            {
                Customer customer = await _customerRepository.GetSingleAsync(customerVm.Id);
                // update
                customer.FirstName = customerVm.FirstName;
                customer.LastName = customerVm.LastName;
                customer.IdentityCard = customerVm.IdentityCard;
                customer.Mobile = customerVm.Mobile;
                customer.DateOfBirth = customerVm.DateOfBirth;
                customer.Email = customerVm.Email;
                customer.UniqueKey = (customerVm.UniqueKey == null || customerVm.UniqueKey == Guid.Empty)
                    ? Guid.NewGuid()
                    : customerVm.UniqueKey;
                customer.RegistrationDate = customerVm.RegistrationDate == DateTime.MinValue
                    ? DateTime.Now
                    : customerVm.RegistrationDate;

                await _unitOfWork.CommitAsync();
                return Ok();
            }
        }
    }
}
