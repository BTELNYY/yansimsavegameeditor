namespace YandereSaveEditor
{
    partial class randomizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(randomizerForm));
            this.randomizeButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.photoCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pantyCheck = new System.Windows.Forms.CheckBox();
            this.friendCheck = new System.Windows.Forms.CheckBox();
            this.repCheck = new System.Windows.Forms.CheckBox();
            this.personaCheck = new System.Windows.Forms.CheckBox();
            this.clubCheck = new System.Windows.Forms.CheckBox();
            this.bustCheckbox = new System.Windows.Forms.CheckBox();
            this.accessoryCheck = new System.Windows.Forms.CheckBox();
            this.crushCheck = new System.Windows.Forms.CheckBox();
            this.hairstyleCheck = new System.Windows.Forms.CheckBox();
            this.strengthCheck = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.warnLabel = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(254, 226);
            this.randomizeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(88, 27);
            this.randomizeButton.TabIndex = 0;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(160, 226);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 27);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // photoCheck
            // 
            this.photoCheck.AutoSize = true;
            this.photoCheck.Location = new System.Drawing.Point(14, 54);
            this.photoCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.photoCheck.Name = "photoCheck";
            this.photoCheck.Size = new System.Drawing.Size(94, 19);
            this.photoCheck.TabIndex = 2;
            this.photoCheck.Text = "Photographs";
            this.photoCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "btelnyy\'s Randomizer, this may cause bugs ang glitches.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enable or Disable Randomizer Changes";
            // 
            // pantyCheck
            // 
            this.pantyCheck.AutoSize = true;
            this.pantyCheck.Location = new System.Drawing.Point(14, 81);
            this.pantyCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pantyCheck.Name = "pantyCheck";
            this.pantyCheck.Size = new System.Drawing.Size(88, 19);
            this.pantyCheck.TabIndex = 5;
            this.pantyCheck.Text = "Panty Shots";
            this.pantyCheck.UseVisualStyleBackColor = true;
            // 
            // friendCheck
            // 
            this.friendCheck.AutoSize = true;
            this.friendCheck.Location = new System.Drawing.Point(14, 107);
            this.friendCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.friendCheck.Name = "friendCheck";
            this.friendCheck.Size = new System.Drawing.Size(64, 19);
            this.friendCheck.TabIndex = 6;
            this.friendCheck.Text = "Friends";
            this.friendCheck.UseVisualStyleBackColor = true;
            // 
            // repCheck
            // 
            this.repCheck.AutoSize = true;
            this.repCheck.Location = new System.Drawing.Point(14, 134);
            this.repCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repCheck.Name = "repCheck";
            this.repCheck.Size = new System.Drawing.Size(84, 19);
            this.repCheck.TabIndex = 7;
            this.repCheck.Text = "Reputation";
            this.repCheck.UseVisualStyleBackColor = true;
            // 
            // personaCheck
            // 
            this.personaCheck.AutoSize = true;
            this.personaCheck.Location = new System.Drawing.Point(121, 54);
            this.personaCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.personaCheck.Name = "personaCheck";
            this.personaCheck.Size = new System.Drawing.Size(73, 19);
            this.personaCheck.TabIndex = 8;
            this.personaCheck.Text = "Personas";
            this.personaCheck.UseVisualStyleBackColor = true;
            // 
            // clubCheck
            // 
            this.clubCheck.AutoSize = true;
            this.clubCheck.Location = new System.Drawing.Point(118, 81);
            this.clubCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clubCheck.Name = "clubCheck";
            this.clubCheck.Size = new System.Drawing.Size(56, 19);
            this.clubCheck.TabIndex = 9;
            this.clubCheck.Text = "Clubs";
            this.clubCheck.UseVisualStyleBackColor = true;
            // 
            // bustCheckbox
            // 
            this.bustCheckbox.AutoSize = true;
            this.bustCheckbox.Location = new System.Drawing.Point(121, 107);
            this.bustCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bustCheckbox.Name = "bustCheckbox";
            this.bustCheckbox.Size = new System.Drawing.Size(72, 19);
            this.bustCheckbox.TabIndex = 10;
            this.bustCheckbox.Text = "Bust Size";
            this.bustCheckbox.UseVisualStyleBackColor = true;
            // 
            // accessoryCheck
            // 
            this.accessoryCheck.AutoSize = true;
            this.accessoryCheck.Location = new System.Drawing.Point(121, 134);
            this.accessoryCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.accessoryCheck.Name = "accessoryCheck";
            this.accessoryCheck.Size = new System.Drawing.Size(84, 19);
            this.accessoryCheck.TabIndex = 11;
            this.accessoryCheck.Text = "Accessorys";
            this.accessoryCheck.UseVisualStyleBackColor = true;
            // 
            // crushCheck
            // 
            this.crushCheck.AutoSize = true;
            this.crushCheck.Location = new System.Drawing.Point(210, 54);
            this.crushCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.crushCheck.Name = "crushCheck";
            this.crushCheck.Size = new System.Drawing.Size(57, 19);
            this.crushCheck.TabIndex = 12;
            this.crushCheck.Text = "Crush";
            this.crushCheck.UseVisualStyleBackColor = true;
            // 
            // hairstyleCheck
            // 
            this.hairstyleCheck.AutoSize = true;
            this.hairstyleCheck.Location = new System.Drawing.Point(210, 81);
            this.hairstyleCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hairstyleCheck.Name = "hairstyleCheck";
            this.hairstyleCheck.Size = new System.Drawing.Size(72, 19);
            this.hairstyleCheck.TabIndex = 13;
            this.hairstyleCheck.Text = "Haristyle";
            this.hairstyleCheck.UseVisualStyleBackColor = true;
            // 
            // strengthCheck
            // 
            this.strengthCheck.AutoSize = true;
            this.strengthCheck.Location = new System.Drawing.Point(210, 107);
            this.strengthCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.strengthCheck.Name = "strengthCheck";
            this.strengthCheck.Size = new System.Drawing.Size(71, 19);
            this.strengthCheck.TabIndex = 14;
            this.strengthCheck.Text = "Strength";
            this.strengthCheck.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(14, 232);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 15);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Submit Funny Result";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Careful, may break";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Lime;
            this.progressBar.Location = new System.Drawing.Point(0, 193);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(342, 27);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 17;
            // 
            // warnLabel
            // 
            this.warnLabel.AutoSize = true;
            this.warnLabel.Location = new System.Drawing.Point(10, 174);
            this.warnLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warnLabel.Name = "warnLabel";
            this.warnLabel.Size = new System.Drawing.Size(226, 15);
            this.warnLabel.TabIndex = 19;
            this.warnLabel.Text = "Why Does it take so long? My Bad code....";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(251, 174);
            this.githubLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(75, 15);
            this.githubLink.TabIndex = 20;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "You can help";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // randomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(337, 250);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.warnLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.strengthCheck);
            this.Controls.Add(this.hairstyleCheck);
            this.Controls.Add(this.crushCheck);
            this.Controls.Add(this.accessoryCheck);
            this.Controls.Add(this.bustCheckbox);
            this.Controls.Add(this.clubCheck);
            this.Controls.Add(this.personaCheck);
            this.Controls.Add(this.repCheck);
            this.Controls.Add(this.friendCheck);
            this.Controls.Add(this.pantyCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.photoCheck);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.randomizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "randomizerForm";
            this.Text = "Randomizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button randomizeButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox photoCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox pantyCheck;
        private System.Windows.Forms.CheckBox friendCheck;
        private System.Windows.Forms.CheckBox repCheck;
        private System.Windows.Forms.CheckBox personaCheck;
        private System.Windows.Forms.CheckBox clubCheck;
        private System.Windows.Forms.CheckBox bustCheckbox;
        private System.Windows.Forms.CheckBox accessoryCheck;
        private System.Windows.Forms.CheckBox crushCheck;
        private System.Windows.Forms.CheckBox hairstyleCheck;
        private System.Windows.Forms.CheckBox strengthCheck;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label warnLabel;
        private System.Windows.Forms.LinkLabel githubLink;
    }
}