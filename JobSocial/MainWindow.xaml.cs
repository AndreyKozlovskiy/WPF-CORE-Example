using Logic;
using Logic.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Presentation;

namespace JobSocial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IService<User>, UserService>();
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(@"Server=DESKTOP-MA2QV8N\SQLEXPRESS;Database=JobSocialNetwork;Integrated Security=True")
               );
            services.AddTransient<ServicePresentation>();
            return services.BuildServiceProvider();
        }
        
        public MainWindow()
        {
            var serviceProvider = ConfigureServices();
            var userService = serviceProvider.GetService<ServicePresentation>();
            var user = new User() { FirstName = "Andrey", SecondName = "Kozlovskiy", City = "Borisov", Mail = "as", Password = "1234", UserName = "Caratos" };
            userService.AddUser(user);

            InitializeComponent();
            MessageBox.Show(user.FirstName);
        }
    }
}
