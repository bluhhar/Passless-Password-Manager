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

using Passless.Modules;
using Gpg.NET;
using System.IO;
using Passless.Classes.Passwords;
using System.Threading;

namespace Passless.WinForm
{
    public partial class FormMain : Form
    {
        private string _selectedLocationPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\");
        private string _keyOwner = null;
        
        private void GetPasswords()
        {
            DirectoryInfo dir = new DirectoryInfo(_selectedLocationPath);
            FileInfo[] files = dir.GetFiles("*.gpg");

            getPasswordToolStripMenuItem.DropDownItems.Clear();
            foreach (var file in files)
            {
                var item = getPasswordToolStripMenuItem.DropDownItems.Add(file.Name);
                item.Click += (object snder, EventArgs evnt) =>
                {
                    string password = GetPassword.GetPasswordFromRepository(_selectedLocationPath + file.Name, true);
                    Clipboard.SetText(password);
                    Thread t = new Thread(() =>
                    {
                        Thread.Sleep(30000);
                        Clipboard.Clear();
                    });
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    notifyIconMain.ShowBalloonTip(3000, "Passless", "Пароль скопирован в буфер обмена, очищение через 30 секунд", ToolTipIcon.Info);
                };
            }
        }

        public FormMain()
        {
            InitializeComponent();
            _keyOwner = FileHelper.Reader(_selectedLocationPath);
            keyTextBox.Text = _keyOwner;
            Controller.Activation();
            notifyIconMain.ShowBalloonTip(3000, "Passless", "Запущен", ToolTipIcon.Info);
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
            FormAddPassword formAddPassword = new FormAddPassword(_selectedLocationPath, _keyOwner);
            formAddPassword.Show();
        }

        private void chooseLocationItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = _selectedLocationPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _selectedLocationPath = folderBrowserDialog.SelectedPath;
                _selectedLocationPath += "\\";
            }
        }

        private void keyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FileHelper.Writer(_selectedLocationPath, keyTextBox.Text);
                _keyOwner = FileHelper.Reader(_selectedLocationPath);
                keyTextBox.Text = _keyOwner;
            }
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            GetPasswords();
        }
    }
}
