using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Passless.Classes.Passwords;

namespace Passless.WinForm
{
    public partial class FormAddPassword : Form
    {
        private string _path;
        private string _keyOwner;
        public FormAddPassword(string path, string keyOwner)
        {
            InitializeComponent();
            _path = path;
            _keyOwner = keyOwner;
        }

        private void buttonAddPassword_Click(object sender, EventArgs e)
        {
           AddPassword.AddPasswordToRepository(_path, _keyOwner, textBoxFileName.Text, textBoxPassword.Text);
        }
    }
}
