using homeCinema.Application.Utilities;
using homeCinema.Data.Entities;
using System.Collections.Generic;

namespace homeCinema.Application.Interfaces
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User GetUser(int id);
        User CreateUser(string username, string email, string password, int[] roles);
        List<Role> GetUserRoles(string username);
    }
}
