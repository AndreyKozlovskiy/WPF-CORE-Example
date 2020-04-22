using Logic.Contexts;
using Logic.Models;
using Logic.Repositories.Contracts;
using Logic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ApplicationService
    {
        public enum StatesOfRegistration
        {
            Ok,
            WrongUserName,
            WrongEmail
        }

        public readonly IUserService userService;
        public readonly IVacancyService vacancyService;
        public readonly IResumeService resumeService;
        public readonly ISkillService skillService;
        public readonly IDataContext dataContext;
        public readonly IResumeRepository resumeRepository;
        public readonly IVacancyRepository vacancyRepository;
        public readonly IUserRepository userRepository;
        public readonly ISkillRepository skillRepository;

        public ApplicationService(
            IDataContext dataContext,
            IUserService userService,
            IVacancyService vacancyService,
            IResumeService resumeService,
            ISkillService skillService,
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IVacancyRepository vacancyRepository,
            IResumeRepository resumeRepository)
        {
            this.dataContext = dataContext;
            this.userService = userService;
            this.vacancyService = vacancyService;
            this.resumeService = resumeService;
            this.skillService = skillService;
            this.resumeRepository = resumeRepository;
            this.skillRepository = skillRepository;
            this.userRepository = userRepository;
            this.vacancyRepository = vacancyRepository;
        }

        public async Task<StatesOfRegistration> AddUserAsync(User user)
        {
            var users = userRepository.Get();

            var userByUserName = await users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userByUserName != null)
            {
                return StatesOfRegistration.WrongUserName;
            }

            var userByMail = await users.FirstOrDefaultAsync(x => x.Mail == user.Mail);
            if (userByMail != null)
            {
                return StatesOfRegistration.WrongEmail;
            }

            await userRepository.AddAsync(user);
            await dataContext.SaveChangesAsync();
            return StatesOfRegistration.Ok;
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            await vacancyService.AddAsync(vacancy);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var users = userRepository.Get();
            return await users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> GetUserByName(string UserName)
        {
            var users = userRepository.Get();
            var user = await users.FirstOrDefaultAsync(x => x.UserName == UserName);
            return user;
        }
    }
}
