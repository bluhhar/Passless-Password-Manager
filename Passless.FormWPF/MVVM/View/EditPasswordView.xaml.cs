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
using Passless.Classes.Random;

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

        private int[] _allowed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private List<string> _words = new List<string>();
        private const string _pathToWordLists = @"C:\Users\bluhhar\AppData\Local\Passless\Wordlists";

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

            foreach (string file in Directory.GetFiles(_pathToWordLists, "*.words"))
            {
                comboBoxWordList.Items.Add(file.Replace(_pathToWordLists, ""));
            }
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
                    result = loginTextBox.Text + ":" + _password;
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
            if (passwordTextBox.IsFocused)
            {
                _password = passwordTextBox.Text;
            }
            //ДОБАВИТЬ В ДОБАВЛЕНИЕ ЕСЛИ УЖЕ ЕСТЬ РАСШИРЕНИЕ .GPG
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (textBoxLength != null) // Проверяем, что textBoxLength не равен null
            {
                double value = sliderLength.Value;
                textBoxLength.Text = value.ToString();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxLength != null && sliderLength != null) // Проверяем, что и textBoxLength, и sliderLength не равны null
            {
                double value;
                if (double.TryParse(textBoxLength.Text, out value))
                {
                    if (value >= sliderLength.Minimum && value <= sliderLength.Maximum)
                    {
                        sliderLength.Value = value;
                    }
                }
            }
        }

        private void CheckBox_Update(object sender, RoutedEventArgs e)
        {
            CheckBox[] checkboxes = { checkBoxLower, checkBoxUpper, checkBoxNumbers,
                checkBoxSpecial, checkBoxSlashes, checkBoxBrackets,
                checkBoxCommadot, checkBoxApostraph, checkBoxOperations, checkBoxOtherChars};
            CheckBox checkBox = (CheckBox)sender;
            int index = Array.IndexOf(checkboxes, checkBox);
            _allowed[index] = checkBox.IsChecked == true ? 1 : 0;
            passwordTextBox.Text = Classes.Random.PasswordGenerator.RandomPassword(int.Parse(textBoxLength.Text), textBoxOtherChars.Text, _allowed);
            _password = passwordTextBox.Text;
        }

        private void TextBoxOtherChars_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBoxOtherChars.Text))
            {
                textBox.BorderThickness = new Thickness(0);
                checkBoxOtherChars.IsChecked = false;
            }
            else
            {
                textBox.BorderThickness = new Thickness(0.6);
                checkBoxOtherChars.IsChecked = true;
            }
        }

        private void ComboBoxWordList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string readText;
            string path = _pathToWordLists + comboBoxWordList.SelectedItem;
            using (StreamReader readtext = new StreamReader(path))
            {
                readText = readtext.ReadLine();
            }
            char[] delimiterChars = { ' ', ',' };
            string[] words = readText.Split(delimiterChars);
            List<string> temp = new List<string>(words);
            for (int i = 0; i < temp.Count; i++)
            {
                temp.Remove("");
            }
            words = temp.ToArray();
            _words = words.ToList();
            textBoxSeparator.IsEnabled = true;
            passwordTextBox.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxLength.Text), words, textBoxSeparator.Text);
            _password = passwordTextBox.Text;
        }

        private void TextBoxSeparator_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordTextBox.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxLength.Text), _words.ToArray(), textBoxSeparator.Text);
            _password = passwordTextBox.Text;
        }
    }
}
