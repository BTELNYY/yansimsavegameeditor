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
                string profile = Utility.GetProfile();
                string profilecombined = "Profile_" + profile;
                string debug = Utility.SelectString("Profile_" + profile + "_Debug", false);
                string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform", false);
                string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform", false);
                string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim_", true);
                string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem", false);
                string infopoints = Utility.SelectString("Profile_" + profile + "_PantyShots", true);
                string chemstat = Utility.SelectString("Profile_" + profile + "_ChemistryGrade", true);
                string biostat = Utility.SelectString("Profile_" + profile + "_BiologyGrade", true);
                string physstat = Utility.SelectString("Profile_" + profile + "_PhysicalGrade", true);
                string langstat = Utility.SelectString("Profile_" + profile + "_LanguageGrade", true);
                string psycstat = Utility.SelectString("Profile_" + profile + "_PsychologyGrade", true);
                string club = Utility.SelectString("Profile_" + profile + "_Club", true);
                string fakeid = Utility.SelectString("Profile_" + profile + "_FakeID", true);
                string raiburu_loner = Utility.SelectString("Profile_" + profile + "_RaiburuLoner", true);
                string love_sick = Utility.SelectString(profilecombined + "LoveSick", true);
                string dark_end = Utility.SelectString(profilecombined + "_DarkEnding", true);
                string trueend = Utility.SelectString(profilecombined + "_TrueEnding", true);
                string money = Utility.SelectString("Profile_" + profile + "_Money", true);
                //for some reason, sometimes the other reputation is shown here, which is odd. I simply yeeted this as a possible bug.
                string reputation = Utility.SelectString("Profile_" + profile + "_Reputation_", true);
                string vtuber_id = Utility.SelectString(profilecombined + "_VtuberID", true);
                string abduction_target = Utility.SelectString(profilecombined + "_AbductionTarget", true);
                string show_abduction = Utility.SelectString(profilecombined + "_ShowAbduction", true);
                string atmosphere_precent = Utility.SelectString(profilecombined + "_SchoolAtmosphere", true);
                string fragiletarget = Utility.SelectString(profilecombined + "_FragileTarget", true);
                string fragileslave = Utility.SelectString(profilecombined + "_FragileSlave", true);
                string studentslave = Utility.SelectString(profilecombined + "_StudentSlave", true);

                RegEdit.editValue(gamereg, FragileTargetCombo.SelectedIndex, fragiletarget);
                RegEdit.editValue(gamereg, FragileSlaveCombo.SelectedIndex, fragileslave);
                RegEdit.editValue(gamereg, StudentSlaveCombo.SelectedIndex, studentslave);
                
                RegEdit.SetCorruptValue(atmosphere_precent, Utility.ToDouble(SchoolAtmosphereTextbox.Text) / 100);

                RegEdit.editValue(gamereg, Convert.ToInt32(vtuberIdTextbox.Text), vtuber_id);

                RegEdit.editValue(gamereg, Convert.ToInt32(abductionTargetCombo.Text), abduction_target);

                RegEdit.editValue(gamereg, Utility.ConvertBool(loveSickCheckbox.Checked), love_sick);

                RegEdit.editValue(gamereg, Utility.ConvertBool(darkEndingCheckbox.Checked), dark_end);

                RegEdit.editValue(gamereg, Utility.ConvertBool(showAbductionCheckbox.Checked), show_abduction);

                

                RegEdit.editValue(gamereg, Utility.ConvertBool(DebugCheckbox.Checked), debug);

                RegEdit.editValue(gamereg, Utility.ConvertBool(fakeIDcheckbox.Checked), fakeid);

                RegEdit.editValue(gamereg, Utility.ConvertBool(trueEndingCheckbox.Checked), trueend);

                RegEdit.editValue(gamereg, Utility.ConvertBool(raiburuLonerCheck.Checked), raiburu_loner);

                RegEdit.editValue(gamereg, FemaleuniformCombo.SelectedIndex + 1, femaleuni);

                RegEdit.editValue(gamereg, MaleuniformCombobox.SelectedIndex + 1, maleuni);

                RegEdit.editValue(gamereg, ItemCombobox.SelectedIndex, bringitem);

                int clubvalue = ClubCombobox.SelectedIndex;
                RegEdit.editValue(gamereg, clubvalue, club);
                if(clubvalue == 16)
                {
                    //deal with the one special case
                    RegEdit.editValue(gamereg, 99, club);
                }


                //idk about the spacing above. Bellow is for the player stats.
                RegEdit.editValue(gamereg, ChemStat.SelectedIndex, chemstat);
                RegEdit.editValue(gamereg, BioStat.SelectedIndex, biostat);
                RegEdit.editValue(gamereg, PhysedStat.SelectedIndex, physstat);
                RegEdit.editValue(gamereg, LangStat.SelectedIndex, langstat);
                RegEdit.editValue(gamereg, PhsycStat.SelectedIndex, psycstat);
                //try parse for the info points, its a textbox, so people can put random shit like words.
                int infopointsvalue = Utility.ToInteger(InfoTextbox.Text);
                RegEdit.editValue(gamereg, infopointsvalue, infopoints);
                //Money code.
                //these 2 lines actually have over 100 behind them, its cleaner this way.
                double d = Utility.ToDouble(MoneyTextbox.Text);
                if (d > 9223372036854775807)
                {
                    //this wont trigger as a overflow will occur, but whatever.
                    Utility.WriteError("Value is larger then the 64-bit integer limit. Dont, I repeat don't try this.", "Error");
                }
                else
                {
                    RegEdit.SetCorruptValue(money, d);
                }
                double r = Utility.ToDouble(ReputationTextbox.Text);
                if (r > 9223372036854775807)
                {
                    //this wont trigger as a overflow will occur, but whatever.
                    Utility.WriteError("Value is larger then the 64-bit integer limit. Dont, I repeat don't try this.", "Error");
                }
                else
                {
                    RegEdit.SetCorruptValue(reputation, r);
                }
                //you could do this cleaner, but I am writing this. Don't like it? make a pull request.
                Log.Info("All Registry Data written successfully.");
                Utility.WriteInfo("All Data Written Succesfully", "Done");
            }
            catch (Exception ex)
            {
                Utility.WriteError(ex.ToString(), "Error");
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
                string profile = Utility.GetProfile();
                string profilecombined = "Profile_" + profile; //wow this would be so much more easy.
                //debug checkmark
                string debug = Utility.SelectString("Profile_" + profile + "_Debug_", false);
                string debugvalue = RegEdit.returnValue(gamereg, debug);
                DebugCheckbox.Checked = Utility.ToBool(Utility.ToInteger(debugvalue));
                //FakeID Checkbox
                string fakeid = Utility.SelectString("Profile_" + profile + "_FakeID", true);
                fakeIDcheckbox.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, fakeid))); //lots of conversions
                //Raiburu Loner check
                string raiburu_loner = Utility.SelectString("Profile_" + profile + "_RaiburuLoner", true);
                raiburuLonerCheck.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, raiburu_loner)));
                //love sick mode
                string love_sick = Utility.SelectString(profilecombined + "_LoveSick", true);
                loveSickCheckbox.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, love_sick)));
                //dark ending
                string dark_end = Utility.SelectString(profilecombined + "_DarkEnding", true);
                darkEndingCheckbox.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, dark_end)));
                //true ending
                string trueend = Utility.SelectString(profilecombined + "_TrueEnding", true);
                trueEndingCheckbox.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, trueend)));
                //Female Uniform
                string femaleuni = Utility.SelectString("Profile_" + profile + "_FemaleUniform", false);
                string femaleunivalue = RegEdit.returnValue(gamereg, femaleuni);
                FemaleuniformCombo.SelectedIndex = Utility.ToInteger(femaleunivalue) - 1;
                //Male uniform
                string maleuni = Utility.SelectString("Profile_" + profile + "_MaleUniform", false);
                string maleunivalue = RegEdit.returnValue(gamereg, maleuni);

                //atmosphere
                string atmosphere_precent = Utility.SelectString(profilecombined + "_SchoolAtmosphere_", true);
                string atmosphereval = RegEdit.returnValue(gamereg, atmosphere_precent);
                Int64 atmosphere = Int64.Parse(atmosphereval);
                SchoolAtmosphereTextbox.Text = (BitConverter.Int64BitsToDouble(atmosphere) * 100).ToString();

                string fragiletarget = Utility.SelectString(profilecombined + "_FragileTarget", true);
                string fragileslave = Utility.SelectString(profilecombined + "_FragileSlave", true);
                string studentslave = Utility.SelectString(profilecombined + "_StudentSlave", true);
                FragileTargetCombo.SelectedIndex = Utility.ToInteger(RegEdit.returnValue(gamereg, fragiletarget));
                FragileSlaveCombo.SelectedIndex = Utility.ToInteger(RegEdit.returnValue(gamereg, fragileslave));
                StudentSlaveCombo.SelectedIndex = Utility.ToInteger(RegEdit.returnValue(gamereg, studentslave));



                MaleuniformCombobox.SelectedIndex = Utility.ToInteger(maleunivalue) - 1;
                //Kidnap Victim
                string kidnapvictim = Utility.SelectString("Profile_" + profile + "_KidnapVictim", true); //will create the value if none is found.
                string kidnapvictimvalue = RegEdit.returnValue(gamereg, kidnapvictim);
                //abduction target
                string abduction_target = Utility.SelectString(profilecombined + "_AbductionTarget", true);
                string abduction_target_value = RegEdit.returnValue(gamereg, abduction_target);
                abductionTargetCombo.Text = abduction_target_value;
                //bringing item
                string bringitem = Utility.SelectString("Profile_" + profile + "_BringingItem", false);
                string bringitemvalue = RegEdit.returnValue(gamereg, bringitem);

                ItemCombobox.Text = bringitemvalue;
                //show abduction
                string show_abduction = Utility.SelectString(profilecombined + "_ShowAbduction", true);
                string show_abduction_value = RegEdit.returnValue(gamereg, show_abduction);
                showAbductionCheckbox.Checked = Convert.ToBoolean(Utility.ToInteger(show_abduction_value));
                //info points
                string infopoints = Utility.SelectString(profilecombined + "_PantyShots", true);
                string infopointsvalue = RegEdit.returnValue(gamereg, infopoints);
                InfoTextbox.Text = infopointsvalue;
                //club
                string club = Utility.SelectString("Profile_" + profile + "_Club", true);
                int clubvalue = Utility.ToInteger(RegEdit.returnValue(gamereg, club));
                ClubCombobox.SelectedIndex = clubvalue;

                //vtuberid
                //currently not used in game, but this is still cool ig
                string vtuber_id = Utility.SelectString(profilecombined + "_VtuberID", true);
                vtuberIdTextbox.Text = RegEdit.returnValue(gamereg, vtuber_id);
                //stats
                string chemstat = Utility.SelectString("Profile_" + profile + "_ChemistryGrade", true);
                string biostat = Utility.SelectString("Profile_" + profile + "_BiologyGrade", true);
                string physstat = Utility.SelectString("Profile_" + profile + "_PhysicalGrade", true);
                string langstat = Utility.SelectString("Profile_" + profile + "_LanguageGrade", true);
                string psycstat = Utility.SelectString("Profile_" + profile + "_PsychologyGrade", true);
                string money = Utility.SelectString("Profile_" + profile + "_Money", true);
                string moneyval = RegEdit.returnValue(gamereg, money);
                MoneyTextbox.Text = BitConverter.Int64BitsToDouble(Int64.Parse(moneyval)).ToString();
                string reputation = Utility.SelectString("Profile_" + profile + "_Reputation_", true);
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
                Utility.WriteError("Error occured when loading data: \n \n " + ex.ToString(), "Error");
            }
        }
        private void mangaButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string[] manga = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
                string profile = Utility.GetProfile();
                foreach (string s in manga)
                {
                    string manga1 = Utility.SelectString("Profile_" + profile + "_MangaCollected_" + s + "_", true);
                    string result = manga1.TrimEnd('_');
                    RegEdit.editValue(gamereg, 1, result);
                }
                mangaButton.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Error("Error when getting all Manga: " + ex.ToString());
                Utility.WriteError("Error when getting all manga: " + ex.ToString(), "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //haha! reused code!
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
                string profile = Utility.GetProfile();
                foreach (string s in array)
                {
                    string value = Utility.SelectString("Profile_" + profile + "_PantyPurchased_" + s + "_", true);
                    string result = value.TrimEnd('_');
                    RegEdit.editValue(gamereg, 1, result);
                }
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Error("Error when giving user all Panties: " + ex.ToString());
                Utility.WriteError("Error on panty item grant: \n \n" + ex.ToString(), "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrisonerForm form = new();
            form.Show();
        }
    }
    
}
