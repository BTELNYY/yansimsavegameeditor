using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
#nullable disable
namespace YandereSaveEditor
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
            if (Globals.debugConsole && !Globals.noLogPrint)
            {
                DebugConsole.WriteLineColor("[" + time + " INFO]: " + input, ConsoleColor.White);
            }
            
        }
        public static void Warning(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " WARNING]: " + input + "\n");
            sw.Close();
            if (Globals.debugConsole && !Globals.noLogPrint)
            {
                DebugConsole.WriteLineColor("[" + time + " WARNING]: " + input, ConsoleColor.Yellow);
            }
            
        }
        public static void Error(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append:true);
            sw.Write("[" + time + " ERROR]: " + input + "\n");
            sw.Close();
            if (Globals.debugConsole && !Globals.noLogPrint)
            {
                DebugConsole.WriteLineColor("[" + time + " ERROR]: " + input, ConsoleColor.Red);
            }
           
        }
        public static void FatalError(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " FATAL ERROR]: " + input + "\n");
            sw.Close();
            if (Globals.debugConsole && !Globals.noLogPrint)
            {
                DebugConsole.WriteLineColor("[" + time + " FATAL ERROR]: " + input, ConsoleColor.DarkRed);
            }
            
        }
        public static void Debug(string input)
        {
            if (Globals.noDebug)
            {
                return;
            }
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " DEBUG]: " + input + "\n");
            sw.Close();
            if (Globals.debugConsole && !Globals.noLogPrint)
            {
                DebugConsole.WriteLineColor("[" + time + " DEBUG]: " + input, ConsoleColor.Gray);
            }
            
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
            if (Globals.debugConsole)
            {
                DebugConsole.WriteLineColor("A crash dump was called.", ConsoleColor.Red);
                DebugConsole.WriteLineColor("date and time: " + date + " " + time, ConsoleColor.Red);
                DebugConsole.WriteLineColor("Method Caller: " + (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, ConsoleColor.Red);
                foreach(string error in Globals.errorArray)
                {
                    DebugConsole.WriteLineColor("Error: \n " + error, ConsoleColor.Red);
                }
            }
        }
    }
}
