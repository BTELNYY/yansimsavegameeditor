using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
#nullable disable
namespace YandereSaveEditor
{
    internal class ScriptHandler
    {
        //shabby fix, should work.
        private static string profile = Globals.profile;
        private static int errorcount = 0;
        public static void Script(string path, string curprofile)
        {
            if (path == null)
            {
                Utility.WriteError("Sepecified path is null.", "Error");
                return;
            }
            if (curprofile == null)
            {
                Utility.WriteError("Specified profile is null.", "Error");
                return;
            }
            Globals.profile = curprofile;
            ScriptHandler.profile = curprofile;
            StreamReader sw = new StreamReader(path);
            string readdata = sw.ReadToEnd();
            string[] script = Utility.SeperateIntoArray(readdata, '\n');
            Log.Info($"Seperated script file {path} into {script.Length} elements");
            ScriptLogic(script);
            sw.Close();
        }
        private static void ScriptLogic(string[] script)
        {
            //method handles IO for registry and JSON data.
            int counter = 0;
            string[] allowedprofiles = { "1", "2", "3", "11", "12", "13" };
            if (!allowedprofiles.Contains(profile))
            {
                Utility.WriteError("Profile is not legal!", "Error");
                return;
            }
            foreach (string line in script)
            {
                Log.Info("Passing " + line + " into Script.");
                string[] args = Utility.SeperateIntoArray(line, ' ');
                counter++;
                if (args[0] == "set")
                {
                    Script(args);
                }
                else
                {
                    Log.Warning("Unkown command in script at " + counter.ToString());
                    errorcount += 1;
                }
            }
            Utility.WriteInfo($"Finished parsing script. \n Error(s): {errorcount} \n if this value is larger then 0, check the log.", "Done");
        }
        private static void Script(string[] args)
        {
            if (args.Length < 3)
            {
                Utility.WriteError("Script parse error: The syntax is invalid.", "Error");
                //acts like a list of errors which occured, this is intended for a print out at the end of the operation.
                errorcount += 1;
            }
            //syntax: command operation value student
            string operation = args[1];
            string value = args[2];
            string student;
            if (args.Length == 3)
            {
                //if the length is 3, to ensure that the student being modified is something that does not exist.
                student = "1";
            }
            else 
            {
                student = args[3];
            }
            int[] students = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
            int studentint = int.Parse(student);
            //verifies if the ID specified is valid and can be used.
            if (student != "0")
            {
                if (!students.Contains(studentint))
                {
                    Log.Error($"Script parse error: {student} is not a valid student but is used as one.");
                    return;
                }
            }
            student json = JSONEdit.GetInfo(int.Parse(student));
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string studentdead = Utility.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true);
            string studentrep = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
            string kidnapped = Utility.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
            string photo = Utility.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
            string dying = Utility.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
            string friend = Utility.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
            string panty = Utility.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
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
            string raiburuloner = Utility.SelectString("Profile_" + profile + "_RaiburuLoner", true);
            string lovesick = Utility.SelectString(profilecombined + "_LoveSick", true);
            string darkend = Utility.SelectString(profilecombined + "_DarkEnding", true);
            string trueend = Utility.SelectString(profilecombined + "_TrueEnding", true);
            string money = Utility.SelectString("Profile_" + profile + "_Money", true);
            string reputation = Utility.SelectString("Profile_" + profile + "_Reputation_", true);
            string arrested = Utility.SelectString("Profile_" + profile + "_StudentArrested_" + student + "_", true);
            string vtuber_id = Utility.SelectString(profilecombined + "_VtuberID", true);
            string abduction_target = Utility.SelectString(profilecombined + "_AbductionTarget", true);
            string show_abduction = Utility.SelectString(profilecombined + "_ShowAbduction", true);
            string atmosphere_precent = Utility.SelectString(profilecombined + "_SchoolAtmosphere", true);
            string pris1fn = Utility.SelectString(profilecombined + "_Prisoner1", true);
            string pris2fn = Utility.SelectString(profilecombined + "_Prisoner2", true);
            string pris3fn = Utility.SelectString(profilecombined + "_Prisoner3", true);
            string pris4fn = Utility.SelectString(profilecombined + "_Prisoner4", true);
            string pris5fn = Utility.SelectString(profilecombined + "_Prisoner5", true);
            string pris6fn = Utility.SelectString(profilecombined + "_Prisoner6", true);
            string pris7fn = Utility.SelectString(profilecombined + "_Prisoner7", true);
            string pris8fn = Utility.SelectString(profilecombined + "_Prisoner8", true);
            string pris9fn = Utility.SelectString(profilecombined + "_Prisoner9", true);
            string pris10fn = Utility.SelectString(profilecombined + "_Prisoner10", true);
            try
            {
                switch (operation)
                {
                    case "prisonerone":
                        RegEdit.editValue(gamereg, int.Parse(value), pris1fn);
                        break;
                    case "prisonertwo":
                        RegEdit.editValue(gamereg, int.Parse(value), pris2fn);
                        break;
                    case "prisonerthree":
                        RegEdit.editValue(gamereg, int.Parse(value), pris3fn);
                        break;
                    case "prisonerfour":
                        RegEdit.editValue(gamereg, int.Parse(value), pris4fn);
                        break;
                    case "prisonerfive":
                        RegEdit.editValue(gamereg, int.Parse(value), pris5fn);
                        break;
                    case "prisonersix":
                        RegEdit.editValue(gamereg, int.Parse(value), pris6fn);
                        break;
                    case "prisonerseven":
                        RegEdit.editValue(gamereg, int.Parse(value), pris7fn);
                        break;
                    case "prisonereight":
                        RegEdit.editValue(gamereg, int.Parse(value), pris8fn);
                        break;
                    case "prisonernine":
                        RegEdit.editValue(gamereg, int.Parse(value), pris9fn);
                        break;
                    case "prisonerten":
                        RegEdit.editValue(gamereg, int.Parse(value), pris10fn);
                        break;
                    case "abducttarget":
                        RegEdit.editValue(gamereg, int.Parse(value), abduction_target);
                        break;
                    case "showabduction":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), show_abduction);
                        break;
                    case "vtuberid":
                        RegEdit.editValue(gamereg, int.Parse(value), vtuber_id);
                        break;
                    case "atmosphere":
                        RegEdit.SetCorruptValue(atmosphere_precent, Utility.ToDouble(value));
                        break;
                    case "rep":
                        RegEdit.editValue(gamereg, int.Parse(value), studentrep);
                        break;
                    case "arrested":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), arrested);
                        break;
                    case "dead":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), studentdead);
                        break;
                    case "friend":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), friend);
                        break;
                    case "kidnapped":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), kidnapped);
                        break;
                    case "photo":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), photo);
                        break;
                    case "dying":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), dying);
                        break;
                    case "panty":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), panty);
                        break;
                    case "debug":
                        if (value == "true") { value = "1"; } else { value = "0"; }
                        RegEdit.editValue(gamereg, int.Parse(value), debug);
                        break;
                    case "femaleuni":
                        RegEdit.editValue(gamereg, int.Parse(value), femaleuni);
                        break;
                    case "maleuni":
                        RegEdit.editValue(gamereg, int.Parse(value), maleuni);
                        break;
                    case "money":
                        RegEdit.SetCorruptValue(money, double.Parse(value));
                        break;
                    case "selfrep":
                        RegEdit.SetCorruptValue(reputation, double.Parse(value));
                        break;
                    case "kidnapvictim":
                        Log.Warning("Using outdated command in script! Ignore this if you are using a build older than june 15th 2022!");
                        RegEdit.editValue(gamereg, int.Parse(value), kidnapvictim);
                        break;
                    case "bringitem":
                        RegEdit.editValue(gamereg, int.Parse(value), bringitem);
                        break;
                    case "selfclub":
                        RegEdit.editValue(gamereg, int.Parse(value), club);
                        break;
                    case "infopoints":
                        RegEdit.editValue(gamereg, int.Parse(value), infopoints);
                        break;
                    case "biostat":
                        RegEdit.editValue(gamereg, int.Parse(value), biostat);
                        break;
                    case "langstat":
                        RegEdit.editValue(gamereg, int.Parse(value), langstat);
                        break;
                    case "chemstat":
                        RegEdit.editValue(gamereg, int.Parse(value), chemstat);
                        break;
                    case "physstat":
                        RegEdit.editValue(gamereg, int.Parse(value), physstat);
                        break;
                    case "psycstat":
                        RegEdit.editValue(gamereg, int.Parse(value), psycstat);
                        break;
                    case "name":
                        value = value.Replace('-', ' ');
                        json.Name = value;
                        break;
                    case "realname":
                        value = value.Replace('-', ' ');
                        json.RealName = value;
                        break;
                    case "gender":
                        json.Gender = value;
                        break;
                    case "class":
                        json.Class = value;
                        break;
                    case "seat":
                        json.Seat = value;
                        break;
                    case "club":
                        json.Club = value;
                        break;
                    case "persona":
                        json.Persona = value;
                        break;
                    case "crush":
                        json.Crush = value;
                        break;
                    case "breastsize":
                        json.BreastSize = value;
                        break;
                    case "strength":
                        json.Strength = value;
                        break;
                    case "hairstyle":
                        json.Hairstyle = value;
                        break;
                    case "color":
                        json.Color = value;
                        break;
                    case "eyes":
                        json.Eyes = value;
                        break;
                    case "eyetype":
                        json.EyeType = value;
                        break;
                    case "stockings":
                        json.Stockings = value;
                        break;
                    case "accessory":
                        json.Accessory = value;
                        break;
                    case "scheduletime":
                        json.ScheduleTime = value;
                        break;
                    case "scheduleaction":
                        json.ScheduleAction = value;
                        break;
                    case "scheduledestination":
                        json.ScheduleDestination = value;
                        break;
                    case "info":
                        value = value.Replace('-', ' ');
                        json.Info = value;
                        break;
                    default:
                        Log.Warning("Script operation is unknown.");
                        errorcount += 1;
                        break;
                }
                JSONEdit.WriteInfo(json);
            }
            catch (Exception e)
            {
                Utility.WriteError($"Error occured while parsing script: \n \n {e.Message}", "Error");
                errorcount += 1;
            }
        }
    }
}
