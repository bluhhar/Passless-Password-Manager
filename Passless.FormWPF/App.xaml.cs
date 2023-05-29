using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
            // Создаем уведомление
            var notification = new System.Windows.Forms.NotifyIcon();
            notification.Visible = true;
            notification.Icon = System.Drawing.SystemIcons.Information;
            notification.BalloonTipTitle = "Passless";
            notification.BalloonTipText = "Запущен!";
            notification.ShowBalloonTip(3000);

            MainWindow mainWindow = new MainWindow();

            // Закрываем уведомление при закрытии приложения
            mainWindow.Closing += (s, args) => notification.Dispose();
        }
    }
}
