using Domain.Contexts;
using Domain.Models;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ApplicationService
    {
        public readonly IUserService userService;
        public readonly IVacancyService vacancyService;
        public readonly IResumeService resumeService;
        public readonly ISkillService skillService;
        public readonly IDataContext dataContext;
        public readonly IResumeRepository resumeRepository;
        public readonly IVacancyRepository vacancyRepository;
        public readonly IUserRepository userRepository;
        public readonly ISkillRepository skillRepository;
        public readonly IWorkExperienceRepository workExperienceRepository;
        public readonly IWorkExperienceService workExperienceService;
        public readonly IEducationRepository educationRepository;
        public readonly IEducationService educationService;

        public ApplicationService(
            IDataContext dataContext,
            IEducationService educationService,
            IWorkExperienceService workExperienceService,
            IUserService userService,
            IVacancyService vacancyService,
            IResumeService resumeService,
            ISkillService skillService,
            IUserRepository userRepository,
            IWorkExperienceRepository workExperienceRepository,
            IEducationRepository educationRepository,
            ISkillRepository skillRepository,
            IVacancyRepository vacancyRepository,
            IResumeRepository resumeRepository)
        {
            this.dataContext = dataContext;
            this.workExperienceRepository = workExperienceRepository;
            this.workExperienceService = workExperienceService;
            this.educationRepository = educationRepository;
            this.educationService = educationService;
            this.userService = userService;
            this.vacancyService = vacancyService;
            this.resumeService = resumeService;
            this.skillService = skillService;
            this.resumeRepository = resumeRepository;
            this.skillRepository = skillRepository;
            this.userRepository = userRepository;
            this.vacancyRepository = vacancyRepository;
        }

        public async Task<string> AddUserAsync(User user)
        {
            var users = userRepository.Get();

            var userByUserName = await users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userByUserName != null)
            {
                return "This user has already existed";
            }

            var userByMail = await users.FirstOrDefaultAsync(x => x.Mail == user.Mail);
            if (userByMail != null)
            {
                return "This Email has already existed";
            }

            user.Password = EncryptPassword(user.Password);
            await userRepository.AddAsync(user);
            await dataContext.SaveChangesAsync();
            return null;
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            await vacancyService.AddAsync(vacancy);
        }

        public string EncryptPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public bool DecryptPassword(string userPassword,string enteredPassword)
        {
            string savedPasswordHash = userPassword;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
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
