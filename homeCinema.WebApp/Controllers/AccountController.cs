using homeCinema.Application.Interfaces;
using homeCinema.Data.EF;
using homeCinema.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace homeCinema.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IMembershipService membershipService,
            IUnitOfWork unitOfWork)
        {
            _membershipService = membershipService;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userContext = await _membershipService.ValidateUser(user.Username, user.Password);
                if (userContext.User != null)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
            else
            {
                return Ok(new { success = false });
            }
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { success = false });
            }
            else
            {
                var rUser = await _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });
                if (rUser != null)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
        }
    }
}
