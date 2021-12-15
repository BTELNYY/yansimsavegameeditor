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
            //and comboboxes
            //the end _ is missing since its not needed, I like it this way too.
            string debug = Utility.SelectString("Profile_" + profile + "_Debug", false);
            string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform", false);
            string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform", false);
            string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim", true);
            string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem", false);
            string infopoints = Utility.SelectString("Profile_" + profile + "_PantyShots", true);
            string chemstat = Utility.SelectString("Profile_" + profile + "_ChemistryGrade", true);
            string biostat = Utility.SelectString("Profile_" + profile + "_BiologyGrade", true);
            string physstat = Utility.SelectString("Profile_" + profile + "_PhysicalGrade", true);
            string langstat = Utility.SelectString("Profile_" + profile + "_LanguageGrade", true);
            string psycstat = Utility.SelectString("Profile_" + profile + "_PsychologyGrade", true);

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

            //idk about the spacing above. Bellow is for the player stats.
            RegEdit.editValue(gamereg, ChemStat.SelectedIndex, chemstat);
            RegEdit.editValue(gamereg, BioStat.SelectedIndex, biostat);
            RegEdit.editValue(gamereg, PhysedStat.SelectedIndex, physstat);
            RegEdit.editValue(gamereg, LangStat.SelectedIndex, langstat);
            RegEdit.editValue(gamereg, PhsycStat.SelectedIndex, psycstat);
            //try parse for the info points, its a textbox, so people can put random shit like words.
            int infopointsint;
            if (Int32.TryParse(InfoTextbox.Text, out infopointsint))
            {
                RegEdit.editValue(gamereg, infopointsint, infopoints);
            }
            else
            {
                int result = 0;
                RegEdit.editValue(gamereg, result, infopoints);
                Utility.WriteWarning("Info Points value is not a valid int32! the number has been set to 0", "Bad Value Warning");
            }
            //you could do this cleaner, but I am writing this. Don't like it? make a pull request.

        }

        private void GameConfig_Load(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profile = Utility.getProfile();
            //debug checkmark
            string debug = Utility.SelectString("Profile_" + profile + "_Debug_", false);
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
            string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform", false);
            string femaleunivalue = RegEdit.returnValue(gamereg, femaleuni);

            FemaleuniformCombo.Text = femaleunivalue;
            //Male uniform
            string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform", false);
            string maleunivalue = RegEdit.returnValue(gamereg, maleuni);

            MaleuniformCombobox.Text = maleunivalue;
            //Kidnap Victim
            string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim", true); //will create the value if none is found.
            string kidnapvictimvalue = RegEdit.returnValue(gamereg, kidnapvictim);

            KidnapCombobox.Text = kidnapvictimvalue;
            //bringing item
            string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem", false);
            string bringitemvalue = RegEdit.returnValue(gamereg, bringitem);

            ItemCombobox.Text = bringitemvalue;

            //info points
            string infopoints = Utility.SelectString("Profile_" + profile + "_PantyShots", true);
            string infopointsvalue = RegEdit.returnValue(gamereg, infopoints);
            InfoTextbox.Text = infopointsvalue;

            //stats
            string chemstat = Utility.SelectString("Profile_" + profile + "_ChemistryGrade", true);
            string biostat = Utility.SelectString("Profile_" + profile + "_BiologyGrade", true);
            string physstat = Utility.SelectString("Profile_" + profile + "_PhysicalGrade", true);
            string langstat = Utility.SelectString("Profile_" + profile + "_LanguageGrade", true);
            string psycstat = Utility.SelectString("Profile_" + profile + "_PsychologyGrade", true);
            ChemStat.Text = RegEdit.returnValue(gamereg, chemstat);
            BioStat.Text = RegEdit.returnValue(gamereg, biostat);
            PhysedStat.Text = RegEdit.returnValue(gamereg, physstat);
            LangStat.Text = RegEdit.returnValue(gamereg, langstat);
            PhsycStat.Text = RegEdit.returnValue(gamereg, psycstat); //I am aware of spelling mistake
        }

        private void mangaButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string[] manga = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"};
            string profile = Utility.getProfile();
            foreach (string s in manga)
            {
                string manga1 = Utility.SelectString("Profile_" + profile + "_MangaCollected_" + s + "_", true);
                string result = manga1.TrimEnd('_');
                RegEdit.editValue(gamereg, 1, result);
            }
            mangaButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //haha! reused code!
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
            string profile = Utility.getProfile();
            foreach (string s in array)
            {
                string value = Utility.SelectString("Profile_" + profile + "_PantyPurchased_" + s + "_", true);
                string result = value.TrimEnd('_');
                RegEdit.editValue(gamereg, 1, result);
            }
            button2.Enabled = false;
        }
    }
}
