namespace YandereSaveEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Credits = new System.Windows.Forms.Label();
            this.githublink = new System.Windows.Forms.LinkLabel();
            this.Studentconfigbutton = new System.Windows.Forms.Button();
            this.GameconfigButton = new System.Windows.Forms.Button();
            this.AdvancedconfigButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProfileCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.updateStatusLabel = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.scriptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(268, 524);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(88, 27);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Close";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to YanSaveEditor/Modding Utility";
            // 
            // Credits
            // 
            this.Credits.AutoSize = true;
            this.Credits.Location = new System.Drawing.Point(10, 52);
            this.Credits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(292, 15);
            this.Credits.TabIndex = 3;
            this.Credits.Text = "This Program was Developed by btelnyy and Loaflover\r\n";
            // 
            // githublink
            // 
            this.githublink.AutoSize = true;
            this.githublink.Location = new System.Drawing.Point(14, 530);
            this.githublink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githublink.Name = "githublink";
            this.githublink.Size = new System.Drawing.Size(45, 15);
            this.githublink.TabIndex = 4;
            this.githublink.TabStop = true;
            this.githublink.Text = "GitHub";
            this.githublink.Click += new System.EventHandler(this.githublink_Click);
            // 
            // Studentconfigbutton
            // 
            this.Studentconfigbutton.Location = new System.Drawing.Point(14, 81);
            this.Studentconfigbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Studentconfigbutton.Name = "Studentconfigbutton";
            this.Studentconfigbutton.Size = new System.Drawing.Size(131, 27);
            this.Studentconfigbutton.TabIndex = 5;
            this.Studentconfigbutton.Text = "Student Config";
            this.Studentconfigbutton.UseVisualStyleBackColor = true;
            this.Studentconfigbutton.Click += new System.EventHandler(this.Studentconfigbutton_Click);
            // 
            // GameconfigButton
            // 
            this.GameconfigButton.Location = new System.Drawing.Point(14, 114);
            this.GameconfigButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GameconfigButton.Name = "GameconfigButton";
            this.GameconfigButton.Size = new System.Drawing.Size(131, 27);
            this.GameconfigButton.TabIndex = 6;
            this.GameconfigButton.Text = "Game Config";
            this.GameconfigButton.UseVisualStyleBackColor = true;
            this.GameconfigButton.Click += new System.EventHandler(this.GameconfigButton_Click);
            // 
            // AdvancedconfigButton
            // 
            this.AdvancedconfigButton.Enabled = false;
            this.AdvancedconfigButton.Location = new System.Drawing.Point(10, 176);
            this.AdvancedconfigButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AdvancedconfigButton.Name = "AdvancedconfigButton";
            this.AdvancedconfigButton.Size = new System.Drawing.Size(131, 27);
            this.AdvancedconfigButton.TabIndex = 7;
            this.AdvancedconfigButton.Text = "Advanced Config";
            this.AdvancedconfigButton.UseVisualStyleBackColor = true;
            this.AdvancedconfigButton.Click += new System.EventHandler(this.AdvancedconfigButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Janky UI, yes I know.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 269);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "If there is no \"close\" button, just hit the X";
            // 
            // ProfileCombobox
            // 
            this.ProfileCombobox.FormattingEnabled = true;
            this.ProfileCombobox.Location = new System.Drawing.Point(10, 230);
            this.ProfileCombobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ProfileCombobox.Name = "ProfileCombobox";
            this.ProfileCombobox.Size = new System.Drawing.Size(140, 23);
            this.ProfileCombobox.TabIndex = 10;
            this.ProfileCombobox.SelectedIndexChanged += new System.EventHandler(this.ProfileCombobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select Save Profile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 287);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "Delete Selected Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 321);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Delete All Profiles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(68, 530);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 15);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Discord";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(117, 380);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(0, 15);
            this.versionLabel.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Current Version:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 405);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Update Status:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // updateStatusLabel
            // 
            this.updateStatusLabel.AutoSize = true;
            this.updateStatusLabel.Location = new System.Drawing.Point(117, 405);
            this.updateStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateStatusLabel.Name = "updateStatusLabel";
            this.updateStatusLabel.Size = new System.Drawing.Size(0, 15);
            this.updateStatusLabel.TabIndex = 18;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(126, 530);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(44, 15);
            this.linkLabel2.TabIndex = 19;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Credits";
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // scriptButton
            // 
            this.scriptButton.Location = new System.Drawing.Point(14, 147);
            this.scriptButton.Name = "scriptButton";
            this.scriptButton.Size = new System.Drawing.Size(131, 23);
            this.scriptButton.TabIndex = 20;
            this.scriptButton.Text = "Scripts";
            this.scriptButton.UseVisualStyleBackColor = true;
            this.scriptButton.Click += new System.EventHandler(this.scriptButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 549);
            this.Controls.Add(this.scriptButton);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.updateStatusLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProfileCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdvancedconfigButton);
            this.Controls.Add(this.GameconfigButton);
            this.Controls.Add(this.Studentconfigbutton);
            this.Controls.Add(this.githublink);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Yandere Simulator Modding Utiliy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Credits;
        private System.Windows.Forms.LinkLabel githublink;
        private System.Windows.Forms.Button Studentconfigbutton;
        private System.Windows.Forms.Button GameconfigButton;
        private System.Windows.Forms.Button AdvancedconfigButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ProfileCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label updateStatusLabel;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private Button scriptButton;
    }
}

