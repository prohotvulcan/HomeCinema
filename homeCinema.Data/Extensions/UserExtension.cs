using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace homeCinema.Data.Extensions
{
    public static class UserExtension
    {
        public static async Task<User> GetSingleByUsername(this IRepository<User> userRepository ,string username)
        {
            var users = await userRepository.GetAllAsync();
            return users.FirstOrDefault(x => x.UserName == username);
        }
    }
}
