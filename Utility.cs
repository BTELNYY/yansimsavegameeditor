using System.IO;
using System;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
namespace YanSimSaveEditor
{
    public class Main
    {

    }
    public class Utility
    {
        public static void CreateLog(string text)
        {
<<<<<<< Updated upstream
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
=======
           
>>>>>>> Stashed changes
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

    }
};