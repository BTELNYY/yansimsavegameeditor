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
    public partial class GameConfig : Form
    {
        public GameConfig()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            GameConfig GameConfig = new GameConfig();
            GameConfig.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void GameConfig_Load(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            MainForm mainForm = new MainForm();
            string profile = Utility.getProfile();
            //debug checkmark
            string debug = Utility.SelectString("Profile_" + profile + "_Debug", false);
            string debugvalue = RegEdit.returnValue(gamereg, debug);
            if (debugvalue == "1")
            {
                DebugCheckbox.Checked = true;
            }
            else
            {
                DebugCheckbox.Checked = false;
            }
            //Female Uniform
            string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform_", false);
            string femaleunivalue = RegEdit.returnValue(gamereg, femaleuni);
            FemaleuniformCombo.Text = femaleunivalue;
            //Male uniform
            string maleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform_", false);
            string maleunivalue = RegEdit.returnValue(gamereg, maleuni);
            FemaleuniformCombo.Text = maleunivalue;
        }
    }
}
