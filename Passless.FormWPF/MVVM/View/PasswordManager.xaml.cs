using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Passless.Classes.Passwords;
using Passless.Modules;

namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для PasswordManager.xaml
    /// </summary>
    public partial class PasswordManager : Window
    {
        private string _selectedLocationPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\");
        private string _keyOwner = null;

        private List<string> passwords;

        private void LoadPasswords()
        {
            passwords = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(_selectedLocationPath);
            FileInfo[] files = dir.GetFiles("*.gpg");
            foreach (var file in files)
            {
                passwords.Add(file.Name);
            }
        }

        public PasswordManager()
        {
            InitializeComponent();
            _keyOwner = FileHelper.Reader(_selectedLocationPath);
            Controller.Activation();
            LoadPasswords();
            searchBox.Focus(); //ВЫБИРАТЬ ТЕКСТБОКС АКТИВИРОВАННЫМ ПРИ ЗАГРУЗКИ ФОРМЫ
            //TODO: сделать чтобы фокус всегда был на серчбоксе чтобы к примеру использовать только
            //клавиатуру
            passwordListBox.ItemsSource = passwords;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadPasswords();//ПЕРЕДЕЛАТЬ ЧТОБЫ НЕ ВСЕГДА ВЫЗЫВАЛСЯ А К ПРИМЕРУ КОГДА ДОБАВИЛИ ПАРОЛЬ
            string searchText = searchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                passwordListBox.ItemsSource = passwords;
            }
            else
            {
                // Фильтруем пароли по поисковому запросу
                List<string> filteredPasswords = new List<string>();
                foreach (string password in passwords)
                {
                    if (password.ToLower().Contains(searchText))
                    {
                        filteredPasswords.Add(password);
                    }
                }
                filteredPasswords.Add("Add new password...");
                // Отображаем отфильтрованные пароли
                passwordListBox.ItemsSource = filteredPasswords;
            }
        }

        private void PasswordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбранного пароля
            string selectedPassword = passwordListBox.SelectedItem as string;
            if (selectedPassword == "Add new password...")
            {
                AddPasswordView addPasswordWindow = new AddPasswordView(_selectedLocationPath, "bluh@btwow.ru", searchBox.Text);
                addPasswordWindow.Owner = this; // Установка владельца новой формы
                addPasswordWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner; // Установка положения новой формы в центре владельца
                bool? result = addPasswordWindow.ShowDialog();

                // Проверяем результат диалогового окна
                if (result == true)
                {
                    LoadPasswords();
                }
            }
            else if (selectedPassword != "Add new password..." && selectedPassword != null)
            {
                string password = GetPassword.GetPasswordFromRepository(_selectedLocationPath + selectedPassword);
                Clipboard.SetText(password);
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(30000);
                    Clipboard.Clear(); //В ВПФ НЕ РАБОТАЕТ СКОРЕЕ ВСЕГО ПРОТЕСТИРОВАТЬ НАДО
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
        }
    }
}
