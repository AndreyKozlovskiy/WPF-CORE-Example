using Domain.Models;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await userRepository.AddAsync(user);
        }

        public User Get(int itemId)
        {
            return userRepository.Get().FirstOrDefault(x => x.Id == itemId);
        }

        public async Task RemoveAsync(int userId)
        {
            await userRepository.RemoveAsync(userId);
        }

        public async Task UpdateAsync(int userId, User newuser)
        {
            await userRepository.UpdateAsync(userId, newuser);
        }
    }
}
