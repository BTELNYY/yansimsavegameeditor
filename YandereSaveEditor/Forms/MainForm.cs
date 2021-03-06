using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YandereSaveEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = Program.version;
            //causes lag, gotta fix
            //MaximizeBox = false;
            button1.Enabled = true; //enables the button if it was disabled.
            button2.Enabled = true;
            string[] saves = { "1", "2", "3", "11", "12", "13" };
            foreach (string s in saves)
            {
                //checks for every save and sees if its "enabled"
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string result = Utility.SelectValueNameOld("ProfileCreated_" + s + "_", false);
                if (result != null)
                {
                    string value = RegEdit.returnValue(gamereg, result);
                    if (value == "1")
                    {
                        //adds the stuff to the combobox
                        ProfileCombobox.Items.Add(s);
                        Log.Info("Detected and added profile " + s);
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    continue;
                }
            }
            int update = Upgrade.checkUpdate();
            //I am doing an ALEX MOMENT, HELP ME
            if (update == 2)
            {
                updateStatusLabel.Text = "Error Occured.";
                updateStatusLabel.ForeColor = Color.Red;
            }
            else if (update == 0)
            {
                updateStatusLabel.Text = "Up to date.";
                updateStatusLabel.ForeColor = Color.Green;
            }
            else if (update == 1)
            {
                updateStatusLabel.Text = "Outdated Version.";
                updateStatusLabel.ForeColor = Color.Gold;
            }
            else if (update == 3)
            {
                updateStatusLabel.Text = "Server Outdated.";
                updateStatusLabel.ForeColor = Color.Gold;
            }
        }

        private void Studentconfigbutton_Click(object sender, EventArgs e)
        {
            if(ProfileCombobox.SelectedIndex < 0)
            {
                Utility.WriteWarning("A save file must be selected!", "Warning");
            }
            else
            {
                StudentConfig StudentConfig = new StudentConfig();
                MainForm MainForm = new MainForm();
                Utility.SetProfile(ProfileCombobox.Text);
                //what even is this bullshit?
                MainForm.Close();
                StudentConfig.ShowDialog();
            }
        }

        private void GameconfigButton_Click(object sender, EventArgs e)
        {
            if (ProfileCombobox.SelectedIndex < 0)
            {
                Utility.WriteWarning("A save file must be selected!", "Warning");
            }
            else
            {
                Utility.SetProfile(ProfileCombobox.Text);
                GameConfig GameConfig = new GameConfig();
                GameConfig.ShowDialog();
            }
        }

            private void AdvancedconfigButton_Click(object sender, EventArgs e)
        {
            //waiting for loaf
        }

        private void ChangeGameDirButton_Click(object sender, EventArgs e)
        {
            //open the change dir dialog
        }

        private void ApplysaveButton_Click(object sender, EventArgs e)
        {

        }

        private void ProfileCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator"); //i know I could just make it a global, but fuck you.
            MainForm MainForm = new MainForm();
            if (ProfileCombobox.SelectedIndex < 0)
            {
                Utility.WriteError("No profile was selected. Select a profile and try again.", "Error");
            }
            else //haha best code ever. KILL ME
            {
                Utility.SetProfile(ProfileCombobox.Text);
                string profile = Utility.GetProfile();
                Utility.DeleteProfile(profile);
                button1.Enabled = false;
                MainForm.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utility.DeleteProfile("1");
            Utility.DeleteProfile("2");
            Utility.DeleteProfile("3");
            Utility.DeleteProfile("11");
            Utility.DeleteProfile("12");
            Utility.DeleteProfile("13");
            button2.Enabled = false;
            MainForm MainForm = new MainForm();
            MainForm.Refresh();
            //its late at night, relax.
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/P22tFkjTm3");
        }

        private void githublink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BTELNYY/yansimsavegameeditor");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            CreditsForm creditsForm = new CreditsForm();
            creditsForm.ShowDialog();
        }

        private void scriptButton_Click(object sender, EventArgs e)
        {
            ScriptForm script = new ScriptForm();
            script.ShowDialog();
        }
    }
}
