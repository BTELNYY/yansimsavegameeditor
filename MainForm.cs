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

namespace YanSimSaveEditor
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
            string[] saves = { "1", "2", "3", "11", "12", "13" };
            foreach (string s in saves)
            {
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string result = Utility.SelectString("ProfileCreated_" + s + "_", false);
                if (result != null)
                {
                    string value = RegEdit.returnValue(gamereg, result);
                    if(value == "1")
                    {
                        ProfileCombobox.Items.Add(s);
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
        }
        private void githublink_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //link to github open in default browser
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
            Open SelectGameDir = new Open();
            SelectGameDir.ShowDialog();
        }
    }
}
