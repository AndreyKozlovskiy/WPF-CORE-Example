using Logic;
using Logic.Models;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Presentation
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            var app = ServiceConfiguration.GetMainService();

            app.
            
            InitializeComponent();
        }
    }
}
