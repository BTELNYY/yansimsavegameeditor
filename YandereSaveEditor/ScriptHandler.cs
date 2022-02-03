using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
namespace YanSimSaveEditor
{
    internal class ScriptHandler
    {
        //shabby fix, should work.
        private static string? profile = Globals.profile;
        private static int errorcount = 0;
        public static void Script(string path, string curprofile)
        {
            Globals.profile = curprofile;
            ScriptHandler.profile = curprofile;
            StreamReader sw = new StreamReader(path);
            string readdata = sw.ReadToEnd();
            string[] script = UtilityScript.SeperateIntoArray(readdata, '\n');
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
                UtilityScript.WriteError("Profile is not legal!", "Error");
                return;
            }
            foreach (string line in script)
            {
                Log.Info("Passing " + line + " into Script.");
                string[] args = UtilityScript.SeperateIntoArray(line, ' ');
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
            UtilityScript.WriteInfo($"Finished parsing script. \n Error(s): {errorcount} \n if this value is larger then 0, check the log.", "Done");
        }
        private static void Script(string[] args)
        {
            if (args.Length < 3)
            {
                UtilityScript.WriteError("Script parse error: The syntax is invalid.", "Error");
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
            string studentdead = UtilityScript.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true);
            string studentrep = UtilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
            string kidnapped = UtilityScript.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
            string photo = UtilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
            string dying = UtilityScript.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
            string friend = UtilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
            string panty = UtilityScript.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
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
            string raiburuloner = UtilityScript.SelectString("Profile_" + profile + "_RaiburuLoner", true);
            string lovesick = UtilityScript.SelectString(profilecombined + "_LoveSick", true);
            string darkend = UtilityScript.SelectString(profilecombined + "_DarkEnding", true);
            string trueend = UtilityScript.SelectString(profilecombined + "_TrueEnding", true);
            string money = UtilityScript.SelectString("Profile_" + profile + "_Money", true);
            string reputation = UtilityScript.SelectString("Profile_" + profile + "_Reputation_", true);
            try
            {
                switch (operation)
                {
                    case "rep":
                        RegEdit.editValue(gamereg, int.Parse(value), reputation);
                        break;
                    case "dead":
                        RegEdit.editValue(gamereg, int.Parse(value), studentdead);
                        break;
                    case "friend":
                        RegEdit.editValue(gamereg, int.Parse(value), friend);
                        break;
                    case "kidnapped":
                        RegEdit.editValue(gamereg, int.Parse(value), kidnapped);
                        break;
                    case "photo":
                        RegEdit.editValue(gamereg, int.Parse(value), photo);
                        break;
                    case "dying":
                        RegEdit.editValue(gamereg, int.Parse(value), dying);
                        break;
                    case "panty":
                        RegEdit.editValue(gamereg, int.Parse(value), panty);
                        break;
                    case "debug":
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
                        value = value.Trim('"');
                        json.Name = value;
                        break;
                    case "realname":
                        value = value.Trim('"');
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
                        value = value.Trim('"');
                        json.Info = value;
                        break;
                    default:
                        Log.Warning("Script operation is unknown.");
                        errorcount += 1;
                        break;
                    JSONEdit.WriteInfo(json);
                }
            }
            catch (Exception e)
            {
                UtilityScript.WriteError($"Error occured while parsing script: \n \n {e.Message}", "Error");
                errorcount += 1;
            }
        }
        private static string SelectString(string[] array, string pattern)
        {
            //gets list of values
            foreach (string s in array)
            {
                //check if the pattern matches the current position in array, if yes, return the name of the value otherwise try again
                bool result = Regex.IsMatch(s, pattern + @"*"); //regex is my nightmare
                if (result)
                {
                    return s;
                }
                else if (!result)
                {
                    continue;
                }
                //returns null if the loop breaks. cuz yes.
                return null;
            }
            return null;
        }
    }
}
