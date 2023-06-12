using Passless.FormWPF.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Passless.FormWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));

            var notification = new System.Windows.Forms.NotifyIcon();
            notification.Visible = true;
            notification.Icon = System.Drawing.SystemIcons.Information;
            //((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")))
            //notification.Icon = (System.Drawing.Icon)resources.GetObject("MainLogo");
            notification.BalloonTipTitle = "Passless";
            notification.BalloonTipText = "Запущен!";
            notification.ShowBalloonTip(3000);

            MainWindow mainWindow = new MainWindow();

            mainWindow.Closing += (s, args) => notification.Dispose();
        }
    }
}
