using Passless.Classes.Passwords;
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
using System.Xaml.Schema;

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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
