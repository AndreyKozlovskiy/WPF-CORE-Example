using Logic.Contexts;
using Logic.Repositories;
using Logic.Repositories.Contracts;
using Logic.Services;
using Logic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Presentation
{
    static public class ServiceConfiguration
    {
        static public ApplicationService GetMainService()
        {
            var services = new ServiceCollection();
            services.AddTransient(typeof(IDataContext), typeof(DataContext));
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(@"Server=DESKTOP-MA2QV8N\SQLEXPRESS;Database=JobSocialNetwork;Integrated Security=True")
               );
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IResumeRepository), typeof(ResumeRepository));
            services.AddTransient(typeof(IVacancyRepository), typeof(VacancyRepository));
            services.AddTransient(typeof(ISkillRepository), typeof(SkillRepository));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IVacancyService), typeof(VacancyService));
            services.AddTransient(typeof(ISkillService), typeof(SkillService));
            services.AddTransient(typeof(IResumeService), typeof(ResumeService));
            services.AddTransient<ApplicationService>();

            var serviceProvider = services.BuildServiceProvider();

            var mainService = serviceProvider.GetService<ApplicationService>();

            return mainService;
        }

    }
}
