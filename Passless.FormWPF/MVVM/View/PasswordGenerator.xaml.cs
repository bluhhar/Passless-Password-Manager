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

namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для PasswordGenerator.xaml
    /// </summary>
    public partial class PasswordGenerator : UserControl
    {
        public PasswordGenerator()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = slider.Value;
            textBox.Text = value.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double value;
            if (double.TryParse(textBox.Text, out value))
            {
                if (value >= slider.Minimum && value <= slider.Maximum)
                {
                    slider.Value = value;
                }
            }
        }
    }
}
