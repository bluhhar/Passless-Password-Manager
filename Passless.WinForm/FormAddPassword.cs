using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Passless.Classes.Passwords;
using Passless.Classes.Random;

namespace Passless.WinForm
{
    public partial class FormAddPassword : Form
    {
        private string _path;
        private string _keyOwner;
        private int[] _allowed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private const string _pathToFiles = @"C:\Users\bluhhar\source\repos\Passless\Passless.WinForm\bin\Debug\wordlists";

        public FormAddPassword(string path, string keyOwner)
        {
            InitializeComponent();
            _path = path;
            _keyOwner = keyOwner;
            checkBoxLower.Checked = true;
            foreach (string file in Directory.GetFiles(_pathToFiles, "*.words"))
            {
                comboBoxWordsSets.Items.Add(file.Replace(_pathToFiles, ""));
            }
            textBoxSeparator.Enabled = false;
        }

        private void buttonAddPassword_Click(object sender, EventArgs e)
        {
            if(textBoxFileName.Text == "")
            {
                MessageBox.Show("Введите имя файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddPassword.AddPasswordToRepository(_path, _keyOwner, textBoxFileName.Text, textBoxPassword.Text);
            }
        }

        private void checkBoxUpdate(object sender, EventArgs e)
        {
            CheckBox[] checkboxes = { checkBoxLower, checkBoxUpper, checkBoxSpecial, 
                checkBoxSlashes, checkBoxOthersChars, checkBoxOperations, checkBoxNumbers,
                    checkBoxCommadot, checkBoxBrackets, checkBoxApostraph};
            CheckBox checkBox = (CheckBox)sender;
            int index = Array.IndexOf(checkboxes, checkBox);
            _allowed[index] = checkBox.Checked ? 1 : 0;
            textBoxPassword.Text = PasswordGenerator.RandomPassword(int.Parse(textBoxCount.Text), textBoxOtherChars.Text, _allowed);
        }

        private List<string> _words = new List<string>();
        private void comboBoxChange(object sender, EventArgs e)
        {
            string readText;
            using (StreamReader readtext = new StreamReader(_pathToFiles + comboBoxWordsSets.Text))
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
            textBoxSeparator.Enabled = true;
            textBoxPassword.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxCountWords.Text), words, textBoxSeparator.Text);
        }

        private void separatorTextBoxChange(object sender, EventArgs e)
        {
            textBoxPassword.Text = PassphraseGenerator.RandomPassphrase(int.Parse(textBoxCountWords.Text), _words.ToArray(), textBoxSeparator.Text);
        }

        private void trackBarScrollUpdate(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            if(trackBar == trackBarCount)
            {
                textBoxCount.Text = trackBarCount.Value.ToString();
            }
            else
            {
                textBoxCountWords.Text = trackBarCountWords.Value.ToString();
            }
        }

        private void countTextBoxChange(object sender, EventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "1";
            }
            else if (int.Parse(textBox.Text) > 128)
            {
                textBox.Text = "128";
            }
            else if (int.Parse(textBox.Text) < 1)
            {
                textBox.Text = "1";
            }
            if (textBox == textBoxCount)
            {
                trackBarCount.Value = int.Parse(textBoxCount.Text);
            }
            else
            {
                trackBarCountWords.Value = int.Parse(textBoxCountWords.Text);
            }
        }

        private void countTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
