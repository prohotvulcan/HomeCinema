using homeCinema.Application.Utilities;
using homeCinema.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace homeCinema.Application.Interfaces
{
    public interface IMembershipService
    {
        Task<MembershipContext> ValidateUser(string username, string password);
        Task<User> GetUser(int id);
        Task<User> CreateUser(string username, string email, string password, int[] roles);
        Task<List<Role>> GetUserRoles(string username);
    }
}
