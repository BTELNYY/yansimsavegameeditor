using System.IO;
using System;
using System.Text;
using Microsoft.Win32;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
#nullable disable
namespace YandereSaveEditor
{
    
    public class Utility
    {
        //value to see if the better handler has broken, and if yes, use the old handler
        public static bool BetterRegValLoaderHadError = false;
        //removed the log function from here, see LoggerScript.cs, or call Log
        private SHA256 Sha256 = SHA256.Create();
        public string GetHashSha256(string filename)
        {
            using FileStream stream = File.OpenRead(filename);
            return Sha256.ComputeHash(stream).ToString();
        }
        public static void WriteError(string msg, string title)
        {
            //Allows the display of error messages, used for when shit breaks.
            if (Globals.debugConsole)
            {
                DebugConsole.WriteLineColor(msg, ConsoleColor.Red);
            }
            else
            {
                MessageBox.Show(msg, title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.errorArray.Append(msg);
            }
        }
        public static void LineChange(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public static void WriteWarning(string msg, string title)
        {
            //warning message.
            if (Globals.debugConsole)
            {
                DebugConsole.WriteLineColor(msg, ConsoleColor.Yellow);
            }
            else
            {
                MessageBox.Show(msg, title,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void WriteInfo(string msg, string title)
        {
            //info stuff
            if (Globals.debugConsole)
            {
                DebugConsole.WriteLineColor(msg, ConsoleColor.White);
            }
            else
            {
                MessageBox.Show(msg, title,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //this code is completely useless, it serves no purpose, but Its being used, I will rewrite this later. (I wrote this a few days into C#, dont judge :) )
        public static bool FileExists(string path)
        {
            //returns a bool depending on if a path exists.
            return File.Exists(path);
        }
        public static bool DirExists(string path)
        {
            //returns depedning on if a directory exists.
            return Directory.Exists(path);
        }
        public static string SelectString(string pattern, bool allowCreation)
        {
            if (pattern.EndsWith('_'))
            {
                pattern = pattern.TrimEnd('_');
            }
            string value = BetterRegnameGetter.GetFullName(pattern);
            if(value == null)
            {
                value = SelectValueNameOld(pattern, allowCreation);
            }
            return value;
        }
        public static string SelectValueNameOld(string pattern, bool allowCreation)
        {
            //prevents tool from setting exact same value many times
            if (!pattern.EndsWith("_"))
            {
                pattern += "_";
            }
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
        public static void DeleteProfile(string profile)
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
        public static void SetProfile(string profile)
        {
            //wow, thats so simple I am going to die of anger from how I did not do this before.
            Globals.profile = profile;
            Log.Info("Set the profile to " + profile);
        }
        public static string GetProfile()
        {
            if (Globals.profile == null)
            {
                WriteError("Something went wrong with the profile system.", "Error");
                return null;
            }
            else
            {
                return Globals.profile;
            }
        }

        public static void SetStudent(string student)
        {
            Globals.student = student;
            Log.Info("Set the student to " + student);
        }
        public static string GetStudent()
        {
            if (Globals.student == null)
            {
                WriteError("Something went wrong with the student system.", "Error");
                return null;
            }
            else
            {
                return Globals.student;
            }
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
            string profilestring = GetProfile();
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
        public static string GetTopics()
        {
            string profilestring = GetProfile();
            int profile = ToInteger(profilestring);
            if (profile > 3)
            {
                // @ is needed so you dont have to replace the \ with \\
                string path = @".\YandereSimulator_Data\StreamingAssets\JSON\EightiesTopics.json";
                return path;
            }
            else
            {
                string path = @".\YandereSimulator_Data\StreamingAssets\JSON\Topics.json";
                return path;
            }
        }
        public static int ConvertBool(bool input)
        {
            //converts a boolean into a registry friendly integer, used for checkboes
            return Convert.ToInt32(input);
        }
        public static bool ToBool(int input)
        {
            //holy shit, the convert method, I guess my dumbass brain is stupid or something.;
            return Convert.ToBoolean(input);
        }
        public static float ToFloat(string input)
        {
            return float.Parse(input);
        }
        public static long ToLong(string input)
        {
            return Convert.ToInt64(input);
        }
        public static int GetRandomInt(int min, int max)
        {
            //allows for one liners in my code.
            Random random = new Random();
            int output = random.Next(min, max);
            return output;
        }
        public static bool GetRandomBool()
        {
            //gets a random boolian. 
            Random random = new Random();
            int output = random.Next(0, 3);
            if (output == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //this shit don't work. why? has I ever? //works now.
        public static double GetRandomDouble(int min, int max, int min2, int max2)
        {
            Random random = new Random();
            string firstdigit = random.Next(min, max).ToString();
            string seconddigit = random.Next(min2, max2).ToString();
            string combined = firstdigit + "." + seconddigit;
            double result = ToDouble(combined);
            return result;
        }
        public static bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static string OpenFileDialog(string path, string fileTypes)
        {
            try //try to run this code, on error break and show the error.
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //sets info about our file dialog.
                    openFileDialog.InitialDirectory = @path;
                    openFileDialog.Filter = fileTypes; //format: "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                    openFileDialog.FilterIndex = 1; //ensure that filter is always this one.
                    openFileDialog.RestoreDirectory = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;
                        return filePath;
                    }
                    else //needed so that it can return something.
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured with the OpenFileDialog Method. Exception: " + ex.ToString());
                WriteError("Failed parsing files as per user selection: \n \n" + ex.ToString(), "Error");
                return null;
            }
        }
        public static string[] SeperateIntoArray(string input, char seperator)
        {
            try
            {
                string[] output = input.Split(seperator);
                return output;
            }
            catch (Exception ex)
            {
                WriteError("Failed to seperate input into array: \n \n " + ex.ToString(), "Error");
                return Array.Empty<string>();
            }
        }
        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        //although these methods piss me off, I am not touching them since they dont even do anything for the application.
        public static string GetHexValue(string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            else
            {
                return long.Parse(input, System.Globalization.NumberStyles.HexNumber).ToString();
            }
        }
        public static string GetDecValue(string input)
        {
            if(input == null)
            {
                return string.Empty;
            }
            else
            {
                long decValue = Utility.ToLong(input);
                string hexValue = decValue.ToString("X");
                return hexValue;
            }
        }
    }
}