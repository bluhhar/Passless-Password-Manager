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
using System.IO;

using Passless.Classes.Passwords;

namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для EditPasswordView.xaml
    /// </summary>
    public partial class EditPasswordView : Window
    {
        private string _path;
        private string _fileName;
        private string _keyOwner;

        protected string _login;
        protected string _password;

        private void LoadContentFromFile(string filepath, string fileName)
        {
            string content = GetPassword.GetContentFromRepository(filepath);
            filenameTextBox.Text = fileName;
            string[] parts = content.Split(':');

            _login = parts[0].Trim();
            _password = parts[1].Trim();
            loginTextBox.Text = _login;
        }

        public EditPasswordView(string path, string fileName, string keyOwner)
        {
            InitializeComponent();
            LoadContentFromFile(path + fileName, fileName);
            _path = path;
            _fileName = fileName;
            _keyOwner = keyOwner;
        }

        private void closeEditPasswordView_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            if(!string.IsNullOrEmpty(filenameTextBox.Text) && File.Exists(_path + _fileName))
            {
                File.Move(_path + _fileName, _path + filenameTextBox.Text);
                File.Delete(_path + _fileName);
                _fileName = filenameTextBox.Text;
            }
            if (string.IsNullOrEmpty(loginTextBox.Text))
            {
                result = "_:";
            }
            else
            {
                if (string.IsNullOrEmpty(loginTextBox.Text))
                {
                    result += "_";
                }
                else
                {
                    result = loginTextBox.Text + ":" + passwordTextBox.Text;
                    AddPassword.AddPasswordToRepository(_path, _keyOwner, _fileName, result);
                    DialogResult = true;
                }
            }
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = _password;
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = "****************";
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
