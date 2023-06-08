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
using Passless.Modules;

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
            TextBoxSelectedLocation.Text = _selectedLocationPath;
            _keyOwner = FileHelper.Reader(_selectedLocationPath, "\\.gpg_owner");
            TextBoxKeyOwner.Text = _keyOwner;
            _keyOwnerInstance.SetKeyOwner(_keyOwner);
            ComboBoxKeyOwnerCryptoProvider.Items.Add("OpenPGP");
            ComboBoxKeyOwnerCryptoProvider.Items.Add("CryptoPro");
        }

        private void ButtonChangeKeyOwner_Click(object sender, RoutedEventArgs e)
        {
            FileHelper.Writer(_selectedLocationPath, TextBoxKeyOwner.Text, "\\.gpg_owner");
            _keyOwner = FileHelper.Reader(_selectedLocationPath, "\\.gpg_owner");
            TextBoxKeyOwner.Text = _keyOwner;
        }

        private void ButtonChangeRepositoryLocation_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = _selectedLocationPath;
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _selectedLocationPath = folderBrowserDialog.SelectedPath;
                _selectedLocationPath += "\\";
                _selectedLocationInstance.SetRepositoryLocation(_selectedLocationPath);
                TextBoxSelectedLocation.Text = _selectedLocationPath;
            }
        }
    }
}
