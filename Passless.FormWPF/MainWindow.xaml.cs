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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Passless.FormWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> passwords; // Ваши пароли
        public MainWindow()
        {
            InitializeComponent();
            passwords = new List<string>()
            {
                "githubPassword1",
                "githubPassword2",
                "otherPassword1",
                "otherPassword2"
            };
            passwordListBox.ItemsSource = passwords;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
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

                // Отображаем отфильтрованные пароли
                passwordListBox.ItemsSource = filteredPasswords;
            }
        }

        private void PasswordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбранного пароля
            string selectedPassword = passwordListBox.SelectedItem as string;
            if (selectedPassword != null)
            {
                // Добавьте вашу логику обработки выбранного пароля здесь
                MessageBox.Show("Выбран пароль: " + selectedPassword);
            }
        }
    }
}
