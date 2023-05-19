namespace Passless.WinForm
{
    partial class FormAddPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonAddPassword = new System.Windows.Forms.Button();
            this.tabControlGenerator = new System.Windows.Forms.TabControl();
            this.tabPagePassword = new System.Windows.Forms.TabPage();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.trackBarCount = new System.Windows.Forms.TrackBar();
            this.checkBoxOthersChars = new System.Windows.Forms.CheckBox();
            this.textBoxOtherChars = new System.Windows.Forms.TextBox();
            this.checkBoxApostraph = new System.Windows.Forms.CheckBox();
            this.checkBoxBrackets = new System.Windows.Forms.CheckBox();
            this.checkBoxOperations = new System.Windows.Forms.CheckBox();
            this.checkBoxSlashes = new System.Windows.Forms.CheckBox();
            this.checkBoxCommadot = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecial = new System.Windows.Forms.CheckBox();
            this.checkBoxNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxUpper = new System.Windows.Forms.CheckBox();
            this.checkBoxLower = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPagePassphrase = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSeparator = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxWordsSets = new System.Windows.Forms.ComboBox();
            this.textBoxCountWords = new System.Windows.Forms.TextBox();
            this.trackBarCountWords = new System.Windows.Forms.TrackBar();
            this.tabControlGenerator.SuspendLayout();
            this.tabPagePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCount)).BeginInit();
            this.tabPagePassphrase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCountWords)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя файла:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFileName.Location = new System.Drawing.Point(100, 6);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(276, 26);
            this.textBoxFileName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.Location = new System.Drawing.Point(100, 35);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(276, 26);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonAddPassword
            // 
            this.buttonAddPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPassword.Location = new System.Drawing.Point(382, 20);
            this.buttonAddPassword.Name = "buttonAddPassword";
            this.buttonAddPassword.Size = new System.Drawing.Size(84, 35);
            this.buttonAddPassword.TabIndex = 4;
            this.buttonAddPassword.Text = "Добавить";
            this.buttonAddPassword.UseVisualStyleBackColor = true;
            this.buttonAddPassword.Click += new System.EventHandler(this.buttonAddPassword_Click);
            // 
            // tabControlGenerator
            // 
            this.tabControlGenerator.Controls.Add(this.tabPagePassword);
            this.tabControlGenerator.Controls.Add(this.tabPagePassphrase);
            this.tabControlGenerator.Location = new System.Drawing.Point(12, 67);
            this.tabControlGenerator.Name = "tabControlGenerator";
            this.tabControlGenerator.SelectedIndex = 0;
            this.tabControlGenerator.Size = new System.Drawing.Size(439, 232);
            this.tabControlGenerator.TabIndex = 5;
            // 
            // tabPagePassword
            // 
            this.tabPagePassword.Controls.Add(this.textBoxCount);
            this.tabPagePassword.Controls.Add(this.trackBarCount);
            this.tabPagePassword.Controls.Add(this.checkBoxOthersChars);
            this.tabPagePassword.Controls.Add(this.textBoxOtherChars);
            this.tabPagePassword.Controls.Add(this.checkBoxApostraph);
            this.tabPagePassword.Controls.Add(this.checkBoxBrackets);
            this.tabPagePassword.Controls.Add(this.checkBoxOperations);
            this.tabPagePassword.Controls.Add(this.checkBoxSlashes);
            this.tabPagePassword.Controls.Add(this.checkBoxCommadot);
            this.tabPagePassword.Controls.Add(this.checkBoxSpecial);
            this.tabPagePassword.Controls.Add(this.checkBoxNumbers);
            this.tabPagePassword.Controls.Add(this.checkBoxUpper);
            this.tabPagePassword.Controls.Add(this.checkBoxLower);
            this.tabPagePassword.Controls.Add(this.label10);
            this.tabPagePassword.Controls.Add(this.label9);
            this.tabPagePassword.Controls.Add(this.label8);
            this.tabPagePassword.Controls.Add(this.label7);
            this.tabPagePassword.Controls.Add(this.label6);
            this.tabPagePassword.Controls.Add(this.label5);
            this.tabPagePassword.Controls.Add(this.label4);
            this.tabPagePassword.Controls.Add(this.label3);
            this.tabPagePassword.Controls.Add(this.label11);
            this.tabPagePassword.Location = new System.Drawing.Point(4, 22);
            this.tabPagePassword.Name = "tabPagePassword";
            this.tabPagePassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePassword.Size = new System.Drawing.Size(431, 206);
            this.tabPagePassword.TabIndex = 0;
            this.tabPagePassword.Text = "Password";
            this.tabPagePassword.UseVisualStyleBackColor = true;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.Location = new System.Drawing.Point(335, 21);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(91, 26);
            this.textBoxCount.TabIndex = 24;
            this.textBoxCount.Text = "16";
            this.textBoxCount.TextChanged += new System.EventHandler(this.countTextBoxChange);
            this.textBoxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countTextBoxKeyPress);
            // 
            // trackBarCount
            // 
            this.trackBarCount.AutoSize = false;
            this.trackBarCount.Location = new System.Drawing.Point(8, 11);
            this.trackBarCount.Maximum = 128;
            this.trackBarCount.Minimum = 1;
            this.trackBarCount.Name = "trackBarCount";
            this.trackBarCount.Size = new System.Drawing.Size(316, 45);
            this.trackBarCount.TabIndex = 23;
            this.trackBarCount.TickFrequency = 0;
            this.trackBarCount.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarCount.Value = 16;
            this.trackBarCount.Scroll += new System.EventHandler(this.trackBarScrollUpdate);
            // 
            // checkBoxOthersChars
            // 
            this.checkBoxOthersChars.AutoSize = true;
            this.checkBoxOthersChars.Location = new System.Drawing.Point(309, 174);
            this.checkBoxOthersChars.Name = "checkBoxOthersChars";
            this.checkBoxOthersChars.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOthersChars.TabIndex = 22;
            this.checkBoxOthersChars.UseVisualStyleBackColor = true;
            this.checkBoxOthersChars.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // textBoxOtherChars
            // 
            this.textBoxOtherChars.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOtherChars.Location = new System.Drawing.Point(172, 168);
            this.textBoxOtherChars.Name = "textBoxOtherChars";
            this.textBoxOtherChars.Size = new System.Drawing.Size(114, 26);
            this.textBoxOtherChars.TabIndex = 21;
            // 
            // checkBoxApostraph
            // 
            this.checkBoxApostraph.AutoSize = true;
            this.checkBoxApostraph.Location = new System.Drawing.Point(309, 148);
            this.checkBoxApostraph.Name = "checkBoxApostraph";
            this.checkBoxApostraph.Size = new System.Drawing.Size(15, 14);
            this.checkBoxApostraph.TabIndex = 20;
            this.checkBoxApostraph.UseVisualStyleBackColor = true;
            this.checkBoxApostraph.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxBrackets
            // 
            this.checkBoxBrackets.AutoSize = true;
            this.checkBoxBrackets.Location = new System.Drawing.Point(309, 121);
            this.checkBoxBrackets.Name = "checkBoxBrackets";
            this.checkBoxBrackets.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBrackets.TabIndex = 19;
            this.checkBoxBrackets.UseVisualStyleBackColor = true;
            this.checkBoxBrackets.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxOperations
            // 
            this.checkBoxOperations.AutoSize = true;
            this.checkBoxOperations.Location = new System.Drawing.Point(309, 95);
            this.checkBoxOperations.Name = "checkBoxOperations";
            this.checkBoxOperations.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOperations.TabIndex = 18;
            this.checkBoxOperations.UseVisualStyleBackColor = true;
            this.checkBoxOperations.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxSlashes
            // 
            this.checkBoxSlashes.AutoSize = true;
            this.checkBoxSlashes.Location = new System.Drawing.Point(309, 67);
            this.checkBoxSlashes.Name = "checkBoxSlashes";
            this.checkBoxSlashes.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSlashes.TabIndex = 17;
            this.checkBoxSlashes.UseVisualStyleBackColor = true;
            this.checkBoxSlashes.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxCommadot
            // 
            this.checkBoxCommadot.AutoSize = true;
            this.checkBoxCommadot.Location = new System.Drawing.Point(126, 176);
            this.checkBoxCommadot.Name = "checkBoxCommadot";
            this.checkBoxCommadot.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCommadot.TabIndex = 16;
            this.checkBoxCommadot.UseVisualStyleBackColor = true;
            this.checkBoxCommadot.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxSpecial
            // 
            this.checkBoxSpecial.AutoSize = true;
            this.checkBoxSpecial.Location = new System.Drawing.Point(126, 148);
            this.checkBoxSpecial.Name = "checkBoxSpecial";
            this.checkBoxSpecial.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSpecial.TabIndex = 15;
            this.checkBoxSpecial.UseVisualStyleBackColor = true;
            this.checkBoxSpecial.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxNumbers
            // 
            this.checkBoxNumbers.AutoSize = true;
            this.checkBoxNumbers.Location = new System.Drawing.Point(126, 121);
            this.checkBoxNumbers.Name = "checkBoxNumbers";
            this.checkBoxNumbers.Size = new System.Drawing.Size(15, 14);
            this.checkBoxNumbers.TabIndex = 14;
            this.checkBoxNumbers.UseVisualStyleBackColor = true;
            this.checkBoxNumbers.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxUpper
            // 
            this.checkBoxUpper.AutoSize = true;
            this.checkBoxUpper.Location = new System.Drawing.Point(126, 95);
            this.checkBoxUpper.Name = "checkBoxUpper";
            this.checkBoxUpper.Size = new System.Drawing.Size(15, 14);
            this.checkBoxUpper.TabIndex = 13;
            this.checkBoxUpper.UseVisualStyleBackColor = true;
            this.checkBoxUpper.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // checkBoxLower
            // 
            this.checkBoxLower.AutoSize = true;
            this.checkBoxLower.Location = new System.Drawing.Point(126, 70);
            this.checkBoxLower.Name = "checkBoxLower";
            this.checkBoxLower.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLower.TabIndex = 12;
            this.checkBoxLower.UseVisualStyleBackColor = true;
            this.checkBoxLower.CheckedChanged += new System.EventHandler(this.checkBoxUpdate);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(217, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "<*+-!?=>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(238, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "/_|-\\";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(240, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "{[(";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(241, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "“ ’";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(57, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = ".,:;";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(25, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "#$%&@^`~";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(52, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "0-9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(51, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "A-Z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(52, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 18);
            this.label11.TabIndex = 3;
            this.label11.Text = "a-z";
            // 
            // tabPagePassphrase
            // 
            this.tabPagePassphrase.Controls.Add(this.label13);
            this.tabPagePassphrase.Controls.Add(this.textBoxSeparator);
            this.tabPagePassphrase.Controls.Add(this.label14);
            this.tabPagePassphrase.Controls.Add(this.comboBoxWordsSets);
            this.tabPagePassphrase.Controls.Add(this.textBoxCountWords);
            this.tabPagePassphrase.Controls.Add(this.trackBarCountWords);
            this.tabPagePassphrase.Location = new System.Drawing.Point(4, 22);
            this.tabPagePassphrase.Name = "tabPagePassphrase";
            this.tabPagePassphrase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePassphrase.Size = new System.Drawing.Size(431, 206);
            this.tabPagePassphrase.TabIndex = 1;
            this.tabPagePassphrase.Text = "Passphrase";
            this.tabPagePassphrase.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(13, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 18);
            this.label13.TabIndex = 33;
            this.label13.Text = "Separator";
            // 
            // textBoxSeparator
            // 
            this.textBoxSeparator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSeparator.Location = new System.Drawing.Point(97, 57);
            this.textBoxSeparator.Name = "textBoxSeparator";
            this.textBoxSeparator.Size = new System.Drawing.Size(181, 26);
            this.textBoxSeparator.TabIndex = 32;
            this.textBoxSeparator.TextChanged += new System.EventHandler(this.separatorTextBoxChange);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(12, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 18);
            this.label14.TabIndex = 31;
            this.label14.Text = "Words set";
            // 
            // comboBoxWordsSets
            // 
            this.comboBoxWordsSets.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWordsSets.FormattingEnabled = true;
            this.comboBoxWordsSets.Location = new System.Drawing.Point(97, 23);
            this.comboBoxWordsSets.Name = "comboBoxWordsSets";
            this.comboBoxWordsSets.Size = new System.Drawing.Size(181, 28);
            this.comboBoxWordsSets.TabIndex = 30;
            this.comboBoxWordsSets.SelectedValueChanged += new System.EventHandler(this.comboBoxChange);
            // 
            // textBoxCountWords
            // 
            this.textBoxCountWords.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountWords.Location = new System.Drawing.Point(308, 98);
            this.textBoxCountWords.Name = "textBoxCountWords";
            this.textBoxCountWords.Size = new System.Drawing.Size(91, 26);
            this.textBoxCountWords.TabIndex = 29;
            this.textBoxCountWords.Text = "4";
            this.textBoxCountWords.TextChanged += new System.EventHandler(this.countTextBoxChange);
            this.textBoxCountWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countTextBoxKeyPress);
            // 
            // trackBarCountWords
            // 
            this.trackBarCountWords.AutoSize = false;
            this.trackBarCountWords.Location = new System.Drawing.Point(16, 89);
            this.trackBarCountWords.Maximum = 128;
            this.trackBarCountWords.Minimum = 1;
            this.trackBarCountWords.Name = "trackBarCountWords";
            this.trackBarCountWords.Size = new System.Drawing.Size(286, 45);
            this.trackBarCountWords.TabIndex = 28;
            this.trackBarCountWords.TickFrequency = 0;
            this.trackBarCountWords.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarCountWords.Value = 4;
            this.trackBarCountWords.Scroll += new System.EventHandler(this.trackBarScrollUpdate);
            // 
            // FormAddPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(469, 304);
            this.Controls.Add(this.tabControlGenerator);
            this.Controls.Add(this.buttonAddPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormAddPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пароля";
            this.tabControlGenerator.ResumeLayout(false);
            this.tabPagePassword.ResumeLayout(false);
            this.tabPagePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCount)).EndInit();
            this.tabPagePassphrase.ResumeLayout(false);
            this.tabPagePassphrase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCountWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonAddPassword;
        private System.Windows.Forms.TabControl tabControlGenerator;
        private System.Windows.Forms.TabPage tabPagePassword;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TrackBar trackBarCount;
        private System.Windows.Forms.CheckBox checkBoxOthersChars;
        private System.Windows.Forms.TextBox textBoxOtherChars;
        private System.Windows.Forms.CheckBox checkBoxApostraph;
        private System.Windows.Forms.CheckBox checkBoxBrackets;
        private System.Windows.Forms.CheckBox checkBoxOperations;
        private System.Windows.Forms.CheckBox checkBoxSlashes;
        private System.Windows.Forms.CheckBox checkBoxCommadot;
        private System.Windows.Forms.CheckBox checkBoxSpecial;
        private System.Windows.Forms.CheckBox checkBoxNumbers;
        private System.Windows.Forms.CheckBox checkBoxUpper;
        private System.Windows.Forms.CheckBox checkBoxLower;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPagePassphrase;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxSeparator;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxWordsSets;
        private System.Windows.Forms.TextBox textBoxCountWords;
        private System.Windows.Forms.TrackBar trackBarCountWords;
    }
}