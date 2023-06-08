using Passless.Modules;
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

using Passless.FormWPF.MVVM.Model;

namespace Passless.FormWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для OptionsRepositoryView.xaml
    /// </summary>
    public partial class OptionsRepositoryView : UserControl
    {
        private KeyOwnerModel _keyOwnerInstance = new KeyOwnerModel();
        private SelectedLocationPathModel _selectedLocationInstance = new SelectedLocationPathModel();

        private string _keyOwner;
        private string _selectedLocationPath;

        public OptionsRepositoryView()
        {
            InitializeComponent();
            _selectedLocationPath = _selectedLocationInstance.GetRepositoryLocation();
            _keyOwner = FileHelper.Reader(_selectedLocationPath);
            TextBoxKeyOwner.Text = _keyOwner;
            _keyOwnerInstance.SetKeyOwner(_keyOwner);
        }

        private void ButtonChangeKeyOwner_Click(object sender, RoutedEventArgs e)
        {
            /*FileHelper.Writer(_selectedLocationPath, keyTextBox.Text);
            _keyOwner = FileHelper.Reader(_selectedLocationPath);
            keyTextBox.Text = _keyOwner;*/
        }
    }
}
