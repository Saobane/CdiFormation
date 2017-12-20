using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WpfMvvmSample.View;

namespace WpfMvvmSample
{
    /// <summary>
    /// Voici la classe générale de l'application
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // au démarrage de l'application on lance cette vue par défaut
            VoirContactView win = new VoirContactView();
            win.Width = 300;
            win.MinWidth = 300;
            win.Height = 300;
            win.MinHeight = 300;
            win.WindowState = WindowState.Normal;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }
    }
}
