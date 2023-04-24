namespace Passless.WinForm
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.passlessPasswordManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.passwordStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contextMenuMain.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passlessPasswordManagerToolStripMenuItem,
            this.toolStripSeparator3,
            this.passwordStoreToolStripMenuItem,
            this.toolStripSeparator2,
            this.addPasswordToolStripMenuItem,
            this.getPasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(202, 176);
            // 
            // passlessPasswordManagerToolStripMenuItem
            // 
            this.passlessPasswordManagerToolStripMenuItem.Enabled = false;
            this.passlessPasswordManagerToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passlessPasswordManagerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.passlessPasswordManagerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.passlessPasswordManagerToolStripMenuItem.Name = "passlessPasswordManagerToolStripMenuItem";
            this.passlessPasswordManagerToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.passlessPasswordManagerToolStripMenuItem.Text = "Passless Password Manager";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 10);
            // 
            // passwordStoreToolStripMenuItem
            // 
            this.passwordStoreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.passwordStoreToolStripMenuItem.Name = "passwordStoreToolStripMenuItem";
            this.passwordStoreToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.passwordStoreToolStripMenuItem.Text = "Репозиторий";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 10);
            // 
            // addPasswordToolStripMenuItem
            // 
            this.addPasswordToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addPasswordToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addPasswordToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addPasswordToolStripMenuItem.Name = "addPasswordToolStripMenuItem";
            this.addPasswordToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.addPasswordToolStripMenuItem.Text = "Добавить";
            this.addPasswordToolStripMenuItem.Click += new System.EventHandler(this.addPasswordToolStripMenuItem_Click);
            // 
            // getPasswordToolStripMenuItem
            // 
            this.getPasswordToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.getPasswordToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.getPasswordToolStripMenuItem.Name = "getPasswordToolStripMenuItem";
            this.getPasswordToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.getPasswordToolStripMenuItem.Text = "Получить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 10);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.quitToolStripMenuItem.Text = "Выход";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Passless";
            this.notifyIconMain.Visible = true;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.contextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem addPasswordToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripMenuItem getPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem passlessPasswordManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem passwordStoreToolStripMenuItem;
    }
}

