using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using System.Linq;

namespace homeCinema.Data.Extensions
{
    public static class UserExtension
    {
        public static User GetSingleByUsername(this IRepository<User> userRepository ,string username)
        {
            return userRepository.All.FirstOrDefault(x => x.UserName == username);
        }
    }
}
