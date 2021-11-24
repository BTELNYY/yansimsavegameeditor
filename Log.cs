using System.IO;
using System.Text;
using static Microsoft.Win32.Registry;
namespace YanSimSaveEditor
{
    public class Main
    {

    }
    public class Log
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
                return;
            };
        }
    }
};