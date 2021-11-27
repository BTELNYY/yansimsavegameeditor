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
            /*
            string config = @"HKEY_CURRENT_USER\SOFTWARE\btelnyy\YanSaveEdit";
            string logFolder = GetValue(config, "logFolder", null).ToString();
            string noLog = GetValue(config, "noLog", null).ToString();
            //check if the keys exist, if not, simply create them
            if (string.IsNullOrEmpty(logFolder))
            {
                SetValue(config, "logFolder", ".");
            }
            if (string.IsNullOrEmpty(noLog))
            {
                SetValue(config, "noLog", "false");
            }
            if (noLog == "true")
            {
                return;
            }
            else
            {
                string file = logFolder.ToString() + "\\latest.log";
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(text);
                sw.Close();
                return;
            }
            */
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
        public static string SelectString(string pattern)
        {
            //registry of the game
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            //gets list of values
            string[] list = RegEdit.returnValuesList(gamereg);
            foreach(string s in list)
            {
                //check if the pattern matches the current position in array, if yes, return the name of the value otherwise try again
                bool result = Regex.IsMatch(s, pattern + @"*"); //regex is my nightmare
                if (result)
                {
                    return s;
                }
                else if(!result)
                {
                    continue;
                }
                else
                {
                    return null;
                }
                //returns null if the loop breaks. cuz yes.
            }
            return null;
        }


    }
};