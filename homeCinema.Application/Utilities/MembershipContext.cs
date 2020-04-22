using homeCinema.Data.Entities;
using System.Security.Principal;

namespace homeCinema.Application.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
