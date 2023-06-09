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
using System.Xaml.Schema;
using System.IO;

using Passless.Classes.Passwords;
using Passless.Classes.Random;


namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddPasswordView.xaml
    /// </summary>
    public partial class AddPasswordView : Window
    {
        private string _path;
        private string _fileName;
        private string _keyOwner;

        private int[] _allowed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private List<string> _words = new List<string>();
        private const string _pathToWordLists = @"C:\Users\bluhhar\AppData\Local\Passless\Wordlists";
        //private const string _pathToWordLists = @"C:\Users\bluhhar\source\repos\Passless\Passless.FormWPF\bin\Debug\Wordlists";

        public AddPasswordView(string path, string fileName, string keyOwner)
        {
            InitializeComponent();

            foreach (string file in Directory.GetFiles(_pathToWordLists, "*.words"))
            {
                comboBoxWordList.Items.Add(file.Replace(_pathToWordLists, ""));
            }

            _path = path;
            _fileName = fileName;
            _keyOwner = keyOwner;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
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

        private void GeneratePassword()
        {
            if (TabControlPasswordGenerate.SelectedIndex == 0)
            {
                passwordTextBox.Text = Classes.Random.PasswordGenerator.RandomPassword(int.Parse(textBoxLength.Text), textBoxOtherChars.Text, _allowed);
            }
            else if (TabControlPasswordGenerate.SelectedIndex == 1 && _words.Any())
            {
                passwordTextBox.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxLength.Text), _words.ToArray(), textBoxSeparator.Text);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (textBoxLength != null)
            {
                double value = sliderLength.Value;
                textBoxLength.Text = value.ToString();
                GeneratePassword();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxLength != null && sliderLength != null)
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
        }

        private void TextBoxOtherChars_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(string.IsNullOrEmpty(textBoxOtherChars.Text))
            {
                textBox.BorderThickness = new Thickness(0);
                checkBoxOtherChars.IsChecked = false;
            }
            else
            {
                textBox.BorderThickness = new Thickness(1);
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
        }

        private void TextBoxSeparator_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordTextBox.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxLength.Text), _words.ToArray(), textBoxSeparator.Text);
        }
    }
}
