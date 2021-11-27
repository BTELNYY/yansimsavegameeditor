namespace YanSimSaveEditor
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
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(230, 344);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Close";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to YanSaveEditor/Modding Utility";
            // 
            // Credits
            // 
            this.Credits.AutoSize = true;
            this.Credits.Location = new System.Drawing.Point(9, 45);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(296, 13);
            this.Credits.TabIndex = 3;
            this.Credits.Text = "This Program was Developed by btelnyy, loaflover, and Bsce.";
            // 
            // githublink
            // 
            this.githublink.AutoSize = true;
            this.githublink.Location = new System.Drawing.Point(9, 349);
            this.githublink.Name = "githublink";
            this.githublink.Size = new System.Drawing.Size(40, 13);
            this.githublink.TabIndex = 4;
            this.githublink.TabStop = true;
            this.githublink.Text = "GitHub";
            this.githublink.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.githublink_MouseDoubleClick);
            // 
            // Studentconfigbutton
            // 
            this.Studentconfigbutton.Location = new System.Drawing.Point(12, 70);
            this.Studentconfigbutton.Name = "Studentconfigbutton";
            this.Studentconfigbutton.Size = new System.Drawing.Size(112, 23);
            this.Studentconfigbutton.TabIndex = 5;
            this.Studentconfigbutton.Text = "Student Config";
            this.Studentconfigbutton.UseVisualStyleBackColor = true;
            this.Studentconfigbutton.Click += new System.EventHandler(this.Studentconfigbutton_Click);
            // 
            // GameconfigButton
            // 
            this.GameconfigButton.Location = new System.Drawing.Point(12, 99);
            this.GameconfigButton.Name = "GameconfigButton";
            this.GameconfigButton.Size = new System.Drawing.Size(112, 23);
            this.GameconfigButton.TabIndex = 6;
            this.GameconfigButton.Text = "Game Config";
            this.GameconfigButton.UseVisualStyleBackColor = true;
            this.GameconfigButton.Click += new System.EventHandler(this.GameconfigButton_Click);
            // 
            // AdvancedconfigButton
            // 
            this.AdvancedconfigButton.Enabled = false;
            this.AdvancedconfigButton.Location = new System.Drawing.Point(12, 128);
            this.AdvancedconfigButton.Name = "AdvancedconfigButton";
            this.AdvancedconfigButton.Size = new System.Drawing.Size(112, 23);
            this.AdvancedconfigButton.TabIndex = 7;
            this.AdvancedconfigButton.Text = "Advanced Config";
            this.AdvancedconfigButton.UseVisualStyleBackColor = true;
            this.AdvancedconfigButton.Click += new System.EventHandler(this.AdvancedconfigButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Janky UI, yes I know.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "If there is no \"close\" button, just hit the X";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 367);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdvancedconfigButton);
            this.Controls.Add(this.GameconfigButton);
            this.Controls.Add(this.Studentconfigbutton);
            this.Controls.Add(this.githublink);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

