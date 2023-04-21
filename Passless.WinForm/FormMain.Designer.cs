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
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPasswordToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(150, 26);
            // 
            // addPasswordToolStripMenuItem
            // 
            this.addPasswordToolStripMenuItem.Name = "addPasswordToolStripMenuItem";
            this.addPasswordToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addPasswordToolStripMenuItem.Text = "Add password";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuMain;
            this.notifyIconMain.Text = "notifyIcon1";
            this.notifyIconMain.Visible = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.contextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem addPasswordToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
    }
}

