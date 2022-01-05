using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace YanSimSaveEditor
{
    public class Log
    {
        public static void Info(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " INFO]: " + input + "\n");
            sw.Close();
        }
        public static void Warning(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " WARNING]: " + input + "\n");
            sw.Close();
        }
        public static void Error(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append:true);
            sw.Write("[" + time + " ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void FatalError(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " FATAL ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void Debug(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true); ;
            sw.Write("[" + time + " DEBUG]: " + input + "\n");
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
        public static void crashdump()
        {
            string date = DateTime.Now.ToString("dd-mm-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\logs\\" + "crashdump" + ".txt";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.WriteLine("a crush dump was called.");
            sw.WriteLine("date: " + date);
            sw.WriteLine("time: " + time);
            sw.WriteLine("method caller: " + (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name);
            sw.WriteLine("exception list: " + Globals.errorArray.Count());
            foreach (string error in Globals.errorArray)
            {
                sw.WriteLine(error);
            }
            sw.Close();
        }
    }
}
