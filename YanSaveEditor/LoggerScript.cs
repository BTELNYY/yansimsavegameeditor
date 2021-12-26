using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YanSimSaveEditor
{
    public class Log
    {
        public void Info(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + "] " + "[INFO]: " + input + "\n");
            sw.Close();
        }
        public static void Warning(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + "] " + "[WARNING]: " + input + "\n");
            sw.Close();
        }
        public static void Error(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append:true);
            sw.Write("[" + time + "] " + "[ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void FatalError(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + "] " + "[FATAL ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void Debug(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true); ;
            sw.Write("[" + time + "] " + "[DEBUG]: " + input + "\n");
            sw.Close();
        }
        public static void Header()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.WriteLine("---------- BEGIN LOG: " + time + " ----------");
            sw.Close();
        }
    }
}
