using System.IO;
using System;
using System.Text;
using Microsoft.Win32;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace YanSimSaveEditor
{
    public class Main
    {

    }
    public class Utility
    {
        public static void CreateLog(string text)
        {
            //takes a string and writes it to a file in the same folder as the app. not used atm.
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            string file = "." + "\\latest.log"; //currently hard set, will be changed later.
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(text);
            sw.Close();
            return;
        }

        public static void WriteError(string msg, string title)
        {
            //Allows the display of error messages, used for when shit breaks.
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void WriteWarning(string msg, string title)
        {
            //warning message.
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void WriteInfo(string msg, string title)
        {
            //info stuff
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool FileExists(string path)
        {
            //returns a bool depending on if a path exists.
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string SelectString(string pattern, bool allowCreation)
        {
            //registry of the game
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            //gets list of values
            string[] list = RegEdit.returnValuesList(gamereg);
            foreach (string s in list)
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
                else
                {
                    return null;
                }
                //returns null if the loop breaks. cuz yes.
            }
            if (allowCreation)
            {
                //basiclly removes the last _ in a name to prevent yansim from ignoring it and making a nww value.
                string trimpattern = pattern.TrimEnd('_');
                gamereg.SetValue(trimpattern, 0);
                return trimpattern;
            }
            return null;
        }
        public static void deleteProfile(string profile)
        {
            try
            {
                //registry of the game
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                //gets list of values
                string[] list = RegEdit.returnValuesList(gamereg);
                string pattern = "Profile_" + profile + "_";
                string profilemarker = Utility.SelectString("ProfileCreated_" + profile + "_", false);
                foreach (string s in list)
                {
                    //check if the pattern matches the current position in array, if yes, return the name of the value otherwise try again
                    bool result = Regex.IsMatch(s, pattern + @"*"); //regex is my nightmare
                    if (result)
                    {
                        gamereg.DeleteValue(s);
                        gamereg.DeleteValue(profilemarker);
                    }
                    else if (!result)
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                    return;
                    //returns null if the loop breaks. cuz yes.
                }
            }
            catch (Exception e)
            {
                WriteError(e.ToString(), "Error");
            }
        }
        public static void setProfile(string profile)
        {
            //techinically a very bad way to do this, but I can make a "recover on crash" system later.
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            int result = int.Parse(profile);
            RegEdit.createValue(config, result, "profile");
        }
        public static string getProfile()
        {
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            string result = RegEdit.returnValue(config, "profile");
            return result;
        }
        public static int ToInteger(string input)
        {
            try
            {
                int result = int.Parse(input);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(string input) //same as above.
        {
            try
            {
                double result = double.Parse(input); //Parse throws an exception, if its thrown, just convert it to 0
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public static string GetJSON()
        {
            string profilestring = getProfile();
            int profile = ToInteger(profilestring);
            if (profile > 3)
            {
                // @ is needed so you dont have to replace the \ with \\
                string path = @".\YandereSimulator_Data\StreamingAssets\JSON\Eighties.json";
                return path;
            }
            else
            {
                string path = @".\YandereSimulator_Data\StreamingAssets\JSON\Students.json";
                return path;
            }
        }
        public static int ConvertBool(bool input)
        {
            //converts a boolean into a registry friendly integer, used for checkboes
            if (input)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
};