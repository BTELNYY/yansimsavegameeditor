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
#nullable disable
namespace YandereSaveEditor
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
            try
            {
                //Sorry for not making this very clean, its both my fault and alexes
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string profile = UtilityScript.GetProfile();
                string profilecombined = "Profile_" + profile;
                string debug = UtilityScript.SelectString("Profile_" + profile + "_Debug", false);
                string femaleuni = UtilityScript.SelectString("Profile_" + profile + "_FemaleUniform", false);
                string maleuni = UtilityScript.SelectString("Profile_" + profile + "_MaleUniform", false);
                string kidnapvictim = UtilityScript.SelectString("Profile_" + profile + "_KidnapVictim_", true);
                string bringitem = UtilityScript.SelectString("Profile_" + profile + "_BringingItem", false);
                string infopoints = UtilityScript.SelectString("Profile_" + profile + "_PantyShots", true);
                string chemstat = UtilityScript.SelectString("Profile_" + profile + "_ChemistryGrade", true);
                string biostat = UtilityScript.SelectString("Profile_" + profile + "_BiologyGrade", true);
                string physstat = UtilityScript.SelectString("Profile_" + profile + "_PhysicalGrade", true);
                string langstat = UtilityScript.SelectString("Profile_" + profile + "_LanguageGrade", true);
                string psycstat = UtilityScript.SelectString("Profile_" + profile + "_PsychologyGrade", true);
                string club = UtilityScript.SelectString("Profile_" + profile + "_Club", true);
                string fakeid = UtilityScript.SelectString("Profile_" + profile + "_FakeID", true);
                string raiburu_loner = UtilityScript.SelectString("Profile_" + profile + "_raiburu_loner", true);
                string love_sick = UtilityScript.SelectString(profilecombined + "_love_sick", true);
                string dark_end = UtilityScript.SelectString(profilecombined + "_dark_ending", true);
                string trueend = UtilityScript.SelectString(profilecombined + "_TrueEnding", true);
                string money = UtilityScript.SelectString("Profile_" + profile + "_Money", true);
                //for some reason, sometimes the other reputation is shown here, which is odd. I simply yeeted this as a possible bug.
                string reputation = UtilityScript.SelectString("Profile_" + profile + "_Reputation_", true);
                string vtuber_id = UtilityScript.SelectString(profilecombined + "_VtuberID", true);
                string abduction_target = UtilityScript.SelectString(profilecombined + "AbductionTarget", true);

                RegEdit.editValue(gamereg, Convert.ToInt32(vtuberIdTextbox.Text), vtuber_id);

                RegEdit.editValue(gamereg, Convert.ToInt32(abductionTargetCombo.Text), abduction_target);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(loveSickCheckbox.Checked), love_sick);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(darkEndingCheckbox.Checked), dark_end);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(DebugCheckbox.Checked), debug);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(fakeIDcheckbox.Checked), fakeid);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(trueEndingCheckbox.Checked), trueend);

                RegEdit.editValue(gamereg, UtilityScript.ConvertBool(raiburuLonerCheck.Checked), raiburu_loner);

                RegEdit.editValue(gamereg, FemaleuniformCombo.SelectedIndex + 1, femaleuni);

                RegEdit.editValue(gamereg, MaleuniformCombobox.SelectedIndex + 1, maleuni);

                RegEdit.editValue(gamereg, KidnapCombobox.SelectedIndex, kidnapvictim);

                RegEdit.editValue(gamereg, ItemCombobox.SelectedIndex, bringitem);

                int clubvalue = ClubCombobox.SelectedIndex;
                if (clubvalue > 15)
                {
                    RegEdit.editValue(gamereg, clubvalue + 84, club);
                }
                else
                {
                    RegEdit.editValue(gamereg, clubvalue, club);
                }

                //idk about the spacing above. Bellow is for the player stats.
                RegEdit.editValue(gamereg, ChemStat.SelectedIndex, chemstat);
                RegEdit.editValue(gamereg, BioStat.SelectedIndex, biostat);
                RegEdit.editValue(gamereg, PhysedStat.SelectedIndex, physstat);
                RegEdit.editValue(gamereg, LangStat.SelectedIndex, langstat);
                RegEdit.editValue(gamereg, PhsycStat.SelectedIndex, psycstat);
                //try parse for the info points, its a textbox, so people can put random shit like words.
                int infopointsvalue = UtilityScript.ToInteger(InfoTextbox.Text);
                RegEdit.editValue(gamereg, infopointsvalue, infopoints);
                if (infopointsvalue == 0)
                {
                    Log.Warning("Info Points were set to a invalid value, reset to 0");
                    UtilityScript.WriteWarning("Info Points value is not a valid int32! the number has been set to 0", "Bad Value Warning");
                }
                //Money code.
                //these 2 lines actually have over 100 behind them, its cleaner this way.
                double d = UtilityScript.ToDouble(MoneyTextbox.Text);
                if (d > 9223372036854775807)
                {
                    //this wont trigger as a overflow will occur, but whatever.
                    UtilityScript.WriteError("Value is larger then the 64-bit integer limit. Dont, I repeat don't try this.", "Error");
                }
                else
                {
                    RegEdit.SetCorruptValue(money, d);
                }
                double r = UtilityScript.ToDouble(ReputationTextbox.Text);
                if (r > 9223372036854775807)
                {
                    //this wont trigger as a overflow will occur, but whatever.
                    UtilityScript.WriteError("Value is larger then the 64-bit integer limit. Dont, I repeat don't try this.", "Error");
                }
                else
                {
                    RegEdit.SetCorruptValue(reputation, r);
                }
                //you could do this cleaner, but I am writing this. Don't like it? make a pull request.
                Log.Info("All Registry Data written successfully.");
                UtilityScript.WriteInfo("All Data Written Succesfully", "Done");
            }
            catch (Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), "Error");
                Log.Error("Data write failed: " + ex.ToString());
            }
        }
        private void GameConfig_Load(object sender, EventArgs e)
        {
            try
            {
                //causes lag, gotta fix.
                //MaximizeBox = false;
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string profile = UtilityScript.GetProfile();
                string profilecombined = "Profile_" + profile; //wow this would be so much more easy.
                //debug checkmark
                string debug = UtilityScript.SelectString("Profile_" + profile + "_Debug_", false);
                string debugvalue = RegEdit.returnValue(gamereg, debug);
                DebugCheckbox.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(debugvalue));
                //FakeID Checkbox
                string fakeid = UtilityScript.SelectString("Profile_" + profile + "_FakeID", true);
                fakeIDcheckbox.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(RegEdit.returnValue(gamereg, fakeid))); //lots of conversions
                //Raiburu Loner check
                string raiburu_loner = UtilityScript.SelectString("Profile_" + profile + "_raiburu_loner", true);
                raiburuLonerCheck.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(RegEdit.returnValue(gamereg, raiburu_loner)));
                //love sick mode
                string love_sick = UtilityScript.SelectString(profilecombined + "_love_sick", true);
                loveSickCheckbox.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(RegEdit.returnValue(gamereg, love_sick)));
                //dark ending
                string dark_end = UtilityScript.SelectString(profilecombined + "_dark_ending", true);
                darkEndingCheckbox.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(RegEdit.returnValue(gamereg, dark_end)));
                //true ending
                string trueend = UtilityScript.SelectString(profilecombined + "_TrueEnding", true);
                trueEndingCheckbox.Checked = UtilityScript.ToBool(UtilityScript.ToInteger(RegEdit.returnValue(gamereg, trueend)));
                //Female Uniform
                string femaleuni = UtilityScript.SelectString("Profile_" + profile + "_FemaleUniform", false);
                string femaleunivalue = RegEdit.returnValue(gamereg, femaleuni);
                FemaleuniformCombo.SelectedIndex = UtilityScript.ToInteger(femaleunivalue) - 1;
                //Male uniform
                string maleuni = UtilityScript.SelectString("Profile_" + profile + "_MaleUniform", false);
                string maleunivalue = RegEdit.returnValue(gamereg, maleuni);

                MaleuniformCombobox.SelectedIndex = UtilityScript.ToInteger(maleunivalue) - 1;
                //Kidnap Victim
                string kidnapvictim = UtilityScript.SelectString("Profile_" + profile + "_KidnapVictim", true); //will create the value if none is found.
                string kidnapvictimvalue = RegEdit.returnValue(gamereg, kidnapvictim);
                KidnapCombobox.Text = kidnapvictimvalue;
                //abduction target
                string abduction_target = UtilityScript.SelectString(profilecombined + "AbductionTarget", true);
                string abduction_target_value = RegEdit.returnValue(gamereg, abduction_target);
                abductionTargetCombo.Text = abduction_target_value;
                //bringing item
                string bringitem = UtilityScript.SelectString("Profile_" + profile + "_BringingItem", false);
                string bringitemvalue = RegEdit.returnValue(gamereg, bringitem);

                ItemCombobox.Text = bringitemvalue;

                //info points
                string infopoints = UtilityScript.SelectString("Profile_" + profile + "_PantyShots", true);
                string infopointsvalue = RegEdit.returnValue(gamereg, infopoints);
                InfoTextbox.Text = infopointsvalue;

                //club
                string club = UtilityScript.SelectString("Profile_" + profile + "_Club", true);
                int clubvalue = UtilityScript.ToInteger(RegEdit.returnValue(gamereg, club));
                if (clubvalue > 14)
                {
                    ClubCombobox.SelectedIndex = clubvalue - 84;
                }
                else
                {
                    ClubCombobox.SelectedIndex = clubvalue;
                }
                //vtuberid
                //currently not used in game, but this is still cool ig
                string vtuber_id = UtilityScript.SelectString(profilecombined + "_VtuberID", true);
                vtuberIdTextbox.Text = RegEdit.returnValue(gamereg, vtuber_id);
                //stats
                string chemstat = UtilityScript.SelectString("Profile_" + profile + "_ChemistryGrade", true);
                string biostat = UtilityScript.SelectString("Profile_" + profile + "_BiologyGrade", true);
                string physstat = UtilityScript.SelectString("Profile_" + profile + "_PhysicalGrade", true);
                string langstat = UtilityScript.SelectString("Profile_" + profile + "_LanguageGrade", true);
                string psycstat = UtilityScript.SelectString("Profile_" + profile + "_PsychologyGrade", true);
                string money = UtilityScript.SelectString("Profile_" + profile + "_Money", true);
                string moneyval = RegEdit.returnValue(gamereg, money);
                MoneyTextbox.Text = BitConverter.Int64BitsToDouble(Int64.Parse(moneyval)).ToString();
                string reputation = UtilityScript.SelectString("Profile_" + profile + "_Reputation_", true);
                string reputationval = RegEdit.returnValue(gamereg, reputation);
                ReputationTextbox.Text = BitConverter.Int64BitsToDouble(Int64.Parse(reputationval)).ToString();
                ChemStat.Text = RegEdit.returnValue(gamereg, chemstat);
                BioStat.Text = RegEdit.returnValue(gamereg, biostat);
                PhysedStat.Text = RegEdit.returnValue(gamereg, physstat);
                LangStat.Text = RegEdit.returnValue(gamereg, langstat);
                PhsycStat.Text = RegEdit.returnValue(gamereg, psycstat); //I am aware of spelling mistake
            }
            catch (Exception ex)
            {
                Log.Error("Error occured while reading data: " + ex.ToString());
                UtilityScript.WriteError("Error occured when loading data: \n \n " + ex.ToString(), "Error");
            }
        }
        private void mangaButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string[] manga = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
                string profile = UtilityScript.GetProfile();
                foreach (string s in manga)
                {
                    string manga1 = UtilityScript.SelectString("Profile_" + profile + "_MangaCollected_" + s + "_", true);
                    string result = manga1.TrimEnd('_');
                    RegEdit.editValue(gamereg, 1, result);
                }
                mangaButton.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Error("Error when getting all Manga: " + ex.ToString());
                UtilityScript.WriteError("Error when getting all manga: " + ex.ToString(), "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //haha! reused code!
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
                string profile = UtilityScript.GetProfile();
                foreach (string s in array)
                {
                    string value = UtilityScript.SelectString("Profile_" + profile + "_PantyPurchased_" + s + "_", true);
                    string result = value.TrimEnd('_');
                    RegEdit.editValue(gamereg, 1, result);
                }
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Error("Error when giving user all Panties: " + ex.ToString());
                UtilityScript.WriteError("Error on panty item grant: \n \n" + ex.ToString(), "Error");
            }
        }
    }
    
}
