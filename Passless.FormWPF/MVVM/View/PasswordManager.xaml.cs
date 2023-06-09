﻿using System;
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
using Passless.FormWPF.MVVM.Model;
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

        private KeyOwnerModel _keyOwnerInstance = new KeyOwnerModel();

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

        private void UpdatePasswords()
        {
            passwordListBox.ItemsSource = null;
            passwordListBox.ItemsSource = passwords;
        }

        public PasswordManager()
        {
            InitializeComponent();
            _keyOwner = FileHelper.Reader(_selectedLocationPath, "\\.gpg_owner");
            Controller.Activation();
            LoadPasswords();
            searchBox.Focus(); //ВЫБИРАТЬ ТЕКСТБОКС АКТИВИРОВАННЫМ ПРИ ЗАГРУЗКИ ФОРМЫ
            //TODO: сделать чтобы фокус всегда был на серчбоксе чтобы к примеру использовать только
            //клавиатуру
            passwordListBox.ItemsSource = passwords;
            _keyOwner = _keyOwnerInstance.GetKeyOwner();
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.E)
            {
                Close();
            }
        }

        private void PasswordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PasswordListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HandleSelectedPassword(true, false);
        }

        private void PasswordListBoxItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            HandleSelectedPassword(false, false);
        }

        //TODO: сделать так, чтобы не срабатывал ивент на получения пароля
        //чтобы просто открывалось меню редактирования пароля
        private void PasswordListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HandleSelectedPassword(true, true);
        }

        private void HandleSelectedPassword(bool isLeftClick, bool editMode)
        {
            string selectedPassword = passwordListBox.SelectedItem as string;
            if (selectedPassword == "Add new password..." && !editMode)
            {
                AddPasswordView addPasswordWindow = new AddPasswordView(_selectedLocationPath, searchBox.Text, _keyOwner);
                addPasswordWindow.Owner = this;
                addPasswordWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                bool? result = addPasswordWindow.ShowDialog();

                if (result == true)
                {
                    LoadPasswords();
                    UpdatePasswords();
                }
            }
            else if (selectedPassword != "Add new password..." && selectedPassword != null && !editMode)
            {
                string password = GetPassword.GetPasswordFromRepository(_selectedLocationPath + selectedPassword, isLeftClick);
                Clipboard.SetText(password);
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(30000);
                    Clipboard.Clear();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else if (isLeftClick && editMode)
            {
                EditPasswordView editPasswordWindow = new EditPasswordView(_selectedLocationPath, selectedPassword, _keyOwner);
                editPasswordWindow.Owner = this;
                editPasswordWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                bool? result = editPasswordWindow.ShowDialog();

                if (result == true)
                {
                    LoadPasswords();
                    UpdatePasswords();
                }
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (passwordListBox.SelectedIndex > 0)
                {
                    passwordListBox.Focus();
                    passwordListBox.SelectedIndex--;
                    passwordListBox.ScrollIntoView(passwordListBox.SelectedItem);
                }
            }
            else if (e.Key == Key.Down)
            {
                if (passwordListBox.SelectedIndex < passwordListBox.Items.Count - 1)
                {
                    passwordListBox.Focus();
                    passwordListBox.SelectedIndex++;
                    passwordListBox.ScrollIntoView(passwordListBox.SelectedItem);
                }
            }
            else if (e.Key == Key.Left)
            {
                HandleSelectedPassword(true, false);
            }
            else if (e.Key == Key.Right)
            {
                HandleSelectedPassword(false, false);
            }
            else if (e.Key == Key.Delete)
            {
                string selectedPassword = passwordListBox.SelectedItem as string;
                if(selectedPassword != "Add new password..." && selectedPassword != null)
                {
                    DeleteFile(_selectedLocationPath + selectedPassword);

                    passwords.Remove(selectedPassword); //МБ СОКРАТИТЬ КОД ЗДЕСЬ
                    //passwordListBox.ItemsSource = null;
                    //passwordListBox.ItemsSource = passwords;
                    UpdatePasswords();
                }
            }
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
