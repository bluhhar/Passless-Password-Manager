﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Passless.FormWPF.MVVM.View;

namespace Passless.FormWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.E)
            {
                PasswordManager passwordManager = Application.Current.Windows.OfType<PasswordManager>().FirstOrDefault();

                if (passwordManager != null) //ПОФИКСИТЬ ЗАКРЫТИЕ, тк когда нажимаешь CNTL E заново чтобы раскрыть, он его закрывает
                {
                    if (passwordManager.WindowState == WindowState.Minimized)
                    {
                        passwordManager.WindowState = WindowState.Normal;
                    }
                    passwordManager.Activate();
                }
                else
                {
                    passwordManager = new PasswordManager();
                    passwordManager.Show();
                }
            }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
            {
                OptionsView optionsView = Application.Current.Windows.OfType<OptionsView>().FirstOrDefault();

                if (optionsView != null)
                {
                    if (optionsView.WindowState == WindowState.Minimized)
                    {
                        optionsView.WindowState = WindowState.Normal;
                    }
                    optionsView.Activate();
                }
                else
                {
                    optionsView = new OptionsView();
                    optionsView.Show();
                }
            }
        }
    }
}
