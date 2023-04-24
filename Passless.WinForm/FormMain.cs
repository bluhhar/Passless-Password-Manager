using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Passless.Classes.FileHelper;
using Gpg.NET;

namespace Passless.WinForm
{
    public partial class FormMain : Form
    {
        private string _selectedLocationPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\");

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddPassword formAddPassword = new FormAddPassword();
            formAddPassword.Show();
        }


        //TODO:сделать чтобы путь запоминался
        private void chooseLocationItem_Click(object sender, EventArgs e)
        {
            //string initialFolder = @"C:\Users\bluhhar\AppData\Local";
            //string initialFolder = @"C:\Users\bluhhar\source\repos\Passless\Passless.WinForm\bin\Debug";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.SelectedPath = initialFolder;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _selectedLocationPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void keyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _ = FileCreates.CreateHiddenFile(_selectedLocationPath, keyTextBox.Text);
            }
        }
    }
}
