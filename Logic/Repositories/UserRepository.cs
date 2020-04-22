using Logic.Contexts;
using Logic.Models;
using Logic.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(IDataContext dataContext)
        {
            UserSet = dataContext.Set<User>();
        }

        protected DbSet<User> UserSet { get; private set; }

        public IQueryable<User> Get() => UserSet;

        public async Task AddAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException();
            }

            UserSet.Attach(user);
            await UserSet.AddAsync(user);
        }

        public async Task RemoveAsync(int userId)
        {
            var userToRemove = await UserSet.FindAsync(userId);

            UserSet.Attach(userToRemove);
            UserSet.Remove(userToRemove);
        }

        public async Task UpdateAsync(int userId, User newUser)
        {
            var userToChange = await UserSet.FindAsync(userId);

            UserSet.Attach(userToChange);

            userToChange.City = newUser.City;
            userToChange.FirstName = newUser.FirstName;
            userToChange.Mail = newUser.Mail;
            userToChange.Password = newUser.Password;
            userToChange.SecondName = newUser.SecondName;
            userToChange.UserName = newUser.UserName;
        }
    }
}
