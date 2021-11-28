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
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profile = Utility.getProfile();
            //top part of checkboxes
            string debug = Utility.SelectString("Profile_" + profile + "_Debug", false);
            string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform_", false);
            string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform_", false);
            string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim_", true);
            string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem_", false);
            //debug checkbox if
            if (DebugCheckbox.Checked == true)
            {
                RegEdit.editValue(gamereg, 1, debug);
            }
            else
            {
                RegEdit.editValue(gamereg, 0, debug);
            }
            RegEdit.editValue(gamereg, FemaleuniformCombo.SelectedIndex, femaleuni);
            RegEdit.editValue(gamereg, MaleuniformCombobox.SelectedIndex, maleuni);
            RegEdit.editValue(gamereg, KidnapCombobox.SelectedIndex, kidnapvictim);
            RegEdit.editValue(gamereg, ItemCombobox.SelectedIndex, bringitem);
        }

        private void GameConfig_Load(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
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
            string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform_", false);
            string maleunivalue = RegEdit.returnValue(gamereg, maleuni);
            MaleuniformCombobox.Text = maleunivalue;
            //Kidnap Victim
            string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim_", true); //will create the value if none is found.
            string kidnapvictimvalue = RegEdit.returnValue(gamereg, kidnapvictim);
            KidnapCombobox.Text = kidnapvictimvalue;
            //bringing item
            string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem_", false);
            string bringitemvalue = RegEdit.returnValue(gamereg, bringitem);
            ItemCombobox.Text = bringitemvalue;

        }

        private void mangaButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string[] manga = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"};
            string profile = Utility.getProfile();
            foreach (string s in manga)
            {
                string manga1 = Utility.SelectString("Profile_" + profile + "_MangaCollected_" + s + "_", true);
                RegEdit.editValue(gamereg, 1, manga1);
            }
            mangaButton.Enabled = false;
        }
    }
}
