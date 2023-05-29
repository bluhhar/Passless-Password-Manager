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
        private int[] _allowed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public PasswordGenerator()
        {
            InitializeComponent();
        }

        private void CheckBox_Update(object sender, RoutedEventArgs e)
        {
            CheckBox[] checkboxes = { checkBoxLower, checkBoxUpper, checkBoxSpecial,
                checkBoxSlashes, checkBoxOtherChars, checkBoxOperations, checkBoxNumbers,
                checkBoxCommadot, checkBoxBrackets, checkBoxApostraph };
            CheckBox checkBox = (CheckBox)sender;
            int index = Array.IndexOf(checkboxes, checkBox);
            _allowed[index] = checkBox.IsChecked == true ? 1 : 0;
            string result = Passless.Classes.Random.PasswordGenerator.RandomPassword(16, "", _allowed);
        }
    }
}
