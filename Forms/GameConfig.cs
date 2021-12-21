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
//using is needed to import things correctly.
namespace YanSimSaveEditor
{
    public partial class GameConfig : Form
    {
        public GameConfig()
        {
            //this starts the form, don't touch.
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //GameConfig is not a static class, you need to EXPLAIN to the computer that you are calling it
            GameConfig GameConfig = new GameConfig();
            //why wont this shit work.
            GameConfig.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profile = utilityScript.getProfile();
            //top part of checkboxes
            //and comboboxes
            //the end _ is missing since its not needed, I like it this way too.
            string debug = utilityScript.SelectString("Profile_" + profile + "_Debug", false);
            string femaleuni = utilityScript.SelectString("Profile_" + profile + "_FemaleUniform", false);
            string maleuni = utilityScript.SelectString("Profile_" + profile + "_MaleUniform", false);
            string kidnapvictim = utilityScript.SelectString("Profile_" + profile + "_KidnapVictim_", true);
            string bringitem = utilityScript.SelectString("Profile_" + profile + "_BringingItem", false);
            string infopoints = utilityScript.SelectString("Profile_" + profile + "_PantyShots", true);
            string chemstat = utilityScript.SelectString("Profile_" + profile + "_ChemistryGrade", true);
            string biostat = utilityScript.SelectString("Profile_" + profile + "_BiologyGrade", true);
            string physstat = utilityScript.SelectString("Profile_" + profile + "_PhysicalGrade", true);
            string langstat = utilityScript.SelectString("Profile_" + profile + "_LanguageGrade", true);
            string psycstat = utilityScript.SelectString("Profile_" + profile + "_PsychologyGrade", true);
            string club = utilityScript.SelectString("Profile_" + profile + "_Club", true);

            //debug checkbox if
            if (DebugCheckbox.Checked == true)
            {
                regEdit.editValue(gamereg, 1, debug);
            }
            else
            {
                regEdit.editValue(gamereg, 0, debug);
            }
            regEdit.editValue(gamereg, FemaleuniformCombo.SelectedIndex, femaleuni);

            regEdit.editValue(gamereg, MaleuniformCombobox.SelectedIndex, maleuni);

            regEdit.editValue(gamereg, KidnapCombobox.SelectedIndex, kidnapvictim);

            regEdit.editValue(gamereg, ItemCombobox.SelectedIndex, bringitem);

            int clubvalue = ClubCombobox.SelectedIndex;
            if (clubvalue > 14)
            {
                regEdit.editValue(gamereg, clubvalue + 84, club);
            }
            else
            {
                regEdit.editValue(gamereg, clubvalue, club);
            }

            //idk about the spacing above. Bellow is for the player stats.
            regEdit.editValue(gamereg, ChemStat.SelectedIndex, chemstat);
            regEdit.editValue(gamereg, BioStat.SelectedIndex, biostat);
            regEdit.editValue(gamereg, PhysedStat.SelectedIndex, physstat);
            regEdit.editValue(gamereg, LangStat.SelectedIndex, langstat);
            regEdit.editValue(gamereg, PhsycStat.SelectedIndex, psycstat);
            //try parse for the info points, its a textbox, so people can put random shit like words.
            int infopointsint;
            if (Int32.TryParse(InfoTextbox.Text, out infopointsint))
            {
                regEdit.editValue(gamereg, infopointsint, infopoints);
            }
            else
            {
                int result = 0;
                regEdit.editValue(gamereg, result, infopoints);
                utilityScript.WriteWarning("Info Points value is not a valid int32! the number has been set to 0", "Bad Value Warning");
            }
            //you could do this cleaner, but I am writing this. Don't like it? make a pull request.
            utilityScript.WriteInfo("All Data Written Succesfully", "Done");
        }

        private void GameConfig_Load(object sender, EventArgs e)
        {
            //causes lag, gotta fix.
            //MaximizeBox = false;
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profile = utilityScript.getProfile();
            //debug checkmark
            string debug = utilityScript.SelectString("Profile_" + profile + "_Debug_", false);
            string debugvalue = regEdit.returnValue(gamereg, debug);
            if (debugvalue == "1")
            {
                DebugCheckbox.Checked = true;
            }
            else
            {
                DebugCheckbox.Checked = false;
            }
            //Female Uniform
            string femaleuni = utilityScript.SelectString("Profile_" + profile + "_FemaleUniform", false);
            string femaleunivalue = regEdit.returnValue(gamereg, femaleuni);

            FemaleuniformCombo.Text = femaleunivalue;
            //Male uniform
            string maleuni = utilityScript.SelectString("Profile_" + profile + "_MaleUniform", false);
            string maleunivalue = regEdit.returnValue(gamereg, maleuni);

            MaleuniformCombobox.Text = maleunivalue;
            //Kidnap Victim
            string kidnapvictim = utilityScript.SelectString("Profile_" + profile + "_KidnapVictim", true); //will create the value if none is found.
            string kidnapvictimvalue = regEdit.returnValue(gamereg, kidnapvictim);

            KidnapCombobox.Text = kidnapvictimvalue;
            //bringing item
            string bringitem = utilityScript.SelectString("Profile_" + profile + "_BringingItem", false);
            string bringitemvalue = regEdit.returnValue(gamereg, bringitem);

            ItemCombobox.Text = bringitemvalue;

            //info points
            string infopoints = utilityScript.SelectString("Profile_" + profile + "_PantyShots", true);
            string infopointsvalue = regEdit.returnValue(gamereg, infopoints);
            InfoTextbox.Text = infopointsvalue;

            //club
            string club = utilityScript.SelectString("Profile_" + profile + "_Club", true);
            int clubvalue = utilityScript.ToInteger(regEdit.returnValue(gamereg, club));
            if(clubvalue > 14)
            {
                ClubCombobox.SelectedIndex = clubvalue - 84;
            }
            else
            {
                ClubCombobox.SelectedIndex = clubvalue;
            }

            //stats
            string chemstat = utilityScript.SelectString("Profile_" + profile + "_ChemistryGrade", true);
            string biostat = utilityScript.SelectString("Profile_" + profile + "_BiologyGrade", true);
            string physstat = utilityScript.SelectString("Profile_" + profile + "_PhysicalGrade", true);
            string langstat = utilityScript.SelectString("Profile_" + profile + "_LanguageGrade", true);
            string psycstat = utilityScript.SelectString("Profile_" + profile + "_PsychologyGrade", true);
            ChemStat.Text = regEdit.returnValue(gamereg, chemstat);
            BioStat.Text = regEdit.returnValue(gamereg, biostat);
            PhysedStat.Text = regEdit.returnValue(gamereg, physstat);
            LangStat.Text = regEdit.returnValue(gamereg, langstat);
            PhsycStat.Text = regEdit.returnValue(gamereg, psycstat); //I am aware of spelling mistake
        }

        private void mangaButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string[] manga = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"};
            string profile = utilityScript.getProfile();
            foreach (string s in manga)
            {
                string manga1 = utilityScript.SelectString("Profile_" + profile + "_MangaCollected_" + s + "_", true);
                string result = manga1.TrimEnd('_');
                regEdit.editValue(gamereg, 1, result);
            }
            mangaButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //haha! reused code!
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
            string profile = utilityScript.getProfile();
            foreach (string s in array)
            {
                string value = utilityScript.SelectString("Profile_" + profile + "_PantyPurchased_" + s + "_", true);
                string result = value.TrimEnd('_');
                regEdit.editValue(gamereg, 1, result);
            }
            button2.Enabled = false;
        }
    }
}
