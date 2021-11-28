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
            globalVars globalVars = new globalVars();
            string profile = globalVars.getProfile();
            if (string.IsNullOrEmpty(profile))
            {
                Utility.WriteError("Profile Identifier Null or empty.", "Error");
            }
            //debug checkmark
            string debug = Utility.SelectString("Profile_" + profile + "_Debug", false);
            string debugvalue = RegEdit.returnValue(gamereg, debug);
            Utility.WriteInfo(debug + debugvalue, "test");
            if (debugvalue == "1")
            {
                DebugCheckbox.Checked = true;
            }
            else
            {
                DebugCheckbox.Checked = false;
            }
        }
    }
}
