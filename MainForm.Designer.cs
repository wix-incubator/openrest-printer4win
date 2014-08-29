namespace OpenRest
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.loginpanel = new System.Windows.Forms.Panel();
            this.loginError = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Label();
            this.loggedinpanel = new System.Windows.Forms.Panel();
            this.ShowDownButton = new System.Windows.Forms.Label();
            this.OpenSite = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ConfigurePrinter = new System.Windows.Forms.Label();
            this.ConnectionStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadOnStartup = new System.Windows.Forms.CheckBox();
            this.loginpanel.SuspendLayout();
            this.loggedinpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "OpenRest";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "OpenRest";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // loginpanel
            // 
            this.loginpanel.Controls.Add(this.loginError);
            this.loginpanel.Controls.Add(this.Connect);
            this.loginpanel.Controls.Add(this.label2);
            this.loginpanel.Controls.Add(this.textBox2);
            this.loginpanel.Controls.Add(this.label1);
            this.loginpanel.Controls.Add(this.textBox1);
            this.loginpanel.Location = new System.Drawing.Point(12, 12);
            this.loginpanel.Name = "loginpanel";
            this.loginpanel.Size = new System.Drawing.Size(376, 211);
            this.loginpanel.TabIndex = 0;
            // 
            // loginError
            // 
            this.loginError.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginError.ForeColor = System.Drawing.Color.White;
            this.loginError.Location = new System.Drawing.Point(3, 148);
            this.loginError.Name = "loginError";
            this.loginError.Size = new System.Drawing.Size(361, 16);
            this.loginError.TabIndex = 5;
            this.loginError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Connect
            // 
            this.Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Connect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(0)))), ((int)(((byte)(33)))));
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connect.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect.ForeColor = System.Drawing.Color.White;
            this.Connect.Location = new System.Drawing.Point(114, 169);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(234, 39);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(114, 115);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(234, 27);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(114, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 27);
            this.textBox1.TabIndex = 0;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(360, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(24, 23);
            this.close.TabIndex = 1;
            this.close.Text = "_";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // loggedinpanel
            // 
            this.loggedinpanel.Controls.Add(this.ShowDownButton);
            this.loggedinpanel.Controls.Add(this.OpenSite);
            this.loggedinpanel.Controls.Add(this.label4);
            this.loggedinpanel.Controls.Add(this.ConfigurePrinter);
            this.loggedinpanel.Controls.Add(this.ConnectionStatus);
            this.loggedinpanel.Location = new System.Drawing.Point(8, 8);
            this.loggedinpanel.Name = "loggedinpanel";
            this.loggedinpanel.Size = new System.Drawing.Size(376, 215);
            this.loggedinpanel.TabIndex = 1;
            this.loggedinpanel.Visible = false;
            // 
            // ShowDownButton
            // 
            this.ShowDownButton.AutoSize = true;
            this.ShowDownButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowDownButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDownButton.ForeColor = System.Drawing.Color.White;
            this.ShowDownButton.Location = new System.Drawing.Point(289, 187);
            this.ShowDownButton.Name = "ShowDownButton";
            this.ShowDownButton.Size = new System.Drawing.Size(63, 13);
            this.ShowDownButton.TabIndex = 6;
            this.ShowDownButton.Text = "Shutdown";
            this.ShowDownButton.Click += new System.EventHandler(this.ShowDownButton_Click);
            // 
            // OpenSite
            // 
            this.OpenSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSite.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenSite.ForeColor = System.Drawing.Color.White;
            this.OpenSite.Location = new System.Drawing.Point(16, 114);
            this.OpenSite.Name = "OpenSite";
            this.OpenSite.Size = new System.Drawing.Size(336, 52);
            this.OpenSite.TabIndex = 5;
            this.OpenSite.Text = "Open Management Site";
            this.OpenSite.UseVisualStyleBackColor = true;
            this.OpenSite.Click += new System.EventHandler(this.OpenSite_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(133, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Disconnect";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ConfigurePrinter
            // 
            this.ConfigurePrinter.AutoSize = true;
            this.ConfigurePrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfigurePrinter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigurePrinter.ForeColor = System.Drawing.Color.White;
            this.ConfigurePrinter.Location = new System.Drawing.Point(18, 187);
            this.ConfigurePrinter.Name = "ConfigurePrinter";
            this.ConfigurePrinter.Size = new System.Drawing.Size(105, 13);
            this.ConfigurePrinter.TabIndex = 3;
            this.ConfigurePrinter.Text = "Configure Printer";
            this.ConfigurePrinter.Click += new System.EventHandler(this.ConfigurePrinter_Click);
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.AutoSize = true;
            this.ConnectionStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatus.ForeColor = System.Drawing.Color.White;
            this.ConnectionStatus.Location = new System.Drawing.Point(13, 77);
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.Size = new System.Drawing.Size(106, 18);
            this.ConnectionStatus.TabIndex = 0;
            this.ConnectionStatus.Text = "Connection:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenRest.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LoadOnStartup
            // 
            this.LoadOnStartup.AutoSize = true;
            this.LoadOnStartup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadOnStartup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOnStartup.ForeColor = System.Drawing.Color.White;
            this.LoadOnStartup.Location = new System.Drawing.Point(8, 230);
            this.LoadOnStartup.Name = "LoadOnStartup";
            this.LoadOnStartup.Size = new System.Drawing.Size(167, 17);
            this.LoadOnStartup.TabIndex = 6;
            this.LoadOnStartup.Text = "Load on windows startup";
            this.LoadOnStartup.UseVisualStyleBackColor = true;
            this.LoadOnStartup.CheckedChanged += new System.EventHandler(this.LoadOnStartup_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(0)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(390, 253);
            this.Controls.Add(this.LoadOnStartup);
            this.Controls.Add(this.close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loggedinpanel);
            this.Controls.Add(this.loginpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenRest";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.loginpanel.ResumeLayout(false);
            this.loginpanel.PerformLayout();
            this.loggedinpanel.ResumeLayout(false);
            this.loggedinpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel loginpanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Panel loggedinpanel;
        private System.Windows.Forms.Label ConnectionStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ConfigurePrinter;
        private System.Windows.Forms.Label loginError;
        private System.Windows.Forms.Button OpenSite;
        private System.Windows.Forms.Label ShowDownButton;
        private System.Windows.Forms.CheckBox LoadOnStartup;
    }
}

