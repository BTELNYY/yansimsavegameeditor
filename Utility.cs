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
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            string file = "." + "\\latest.log"; //currently hard set, will be changed later.
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(text);
            sw.Close();
            return;
        }

        public static void WriteError(string msg, string title)
        {
            //displays old icon, no idea why.
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void WriteWarning(string msg, string title)
        {
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void WriteInfo(string msg, string title)
        {
            MessageBox.Show(msg, title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool FileExists(string path)
        {
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
                //make log later.
            }
        }
        public static void setProfile(string profile)
        {
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            int result = Int32.Parse(profile);
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
            catch (Exception e)
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
            //lame ass function not needed, useful for one liners.
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