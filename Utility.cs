using System.IO;
using System;
using System.Text;
using static Microsoft.Win32.Registry;
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
            //I spent 2 and a half hours importing vairables. not proud rn.
            string config = "HKEY_CURRENT_USER\\SOFTWARE\\btelnyy\\YanSaveEdit".ToString();
            string logFolder = GetValue(config, "logFolder", null).ToString();
            string noLog = GetValue(config, "noLog", null).ToString();
            //check if the keys exist, if not, simply create them
            if (string.IsNullOrEmpty(logFolder))
            {
                SetValue(config, "logFolder", ".");
            };
            if (string.IsNullOrEmpty(noLog))
            {
                SetValue(config, "noLog", "false");
            };
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
            };
        }

        public static void WriteError(string msg, string title)
        {
            //displays old icon, no idea why.
            MessageBox.Show(msg, title,
             MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
};