﻿using Passless.Classes.Passwords;
using System;
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

namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddPasswordView.xaml
    /// </summary>
    public partial class AddPasswordView : Window
    {
        private string _path;
        private string _keyOwner;
        private string _fileName;
        public AddPasswordView(string path, string keyOwner, 
            string fileName)
        {
            InitializeComponent();
            _path = path;
            _keyOwner = keyOwner;
            _fileName = fileName;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPassword.AddPasswordToRepository(_path, _keyOwner, _fileName, passwordTextBox.Text);
            DialogResult = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Закрыть текущую форму
        }
    }
}