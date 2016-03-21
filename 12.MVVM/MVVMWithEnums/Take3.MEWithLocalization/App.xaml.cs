﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Take3.MEWithLocalization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CultureInfo info = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;
            base.OnStartup(e);
        }
    }
}
