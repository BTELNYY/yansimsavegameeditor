using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
#nullable disable
namespace YandereSaveEditor
{
    internal class DebugConsole
    {
        //dont ask me how this works, I dont know.
        [DllImport("kernel32")]
        static extern int AllocConsole();
        [DllImport("kernel32")]
        static extern int FreeConsole();
        public static bool ConsoleCreated;
        public static void StartConsole()
        {
            AllocConsole();
            ConsoleCreated = true;
            Console.Title = "YanSaveEditor Debug Console";
            Console.WriteLine("BTELNYY's and Loaflover's Yandere Simulator Modding Utility Debug Console");
            Console.WriteLine("Version: " + Program.version);
            Console.WriteLine("This is a debug console meant for debugging, do not report bugs caused by this function.");
            if (Globals.debug)
            {
                WriteLineColor("Warning: the application is in debug mode, in order to continue normal execution, type 'log'", ConsoleColor.Yellow);
                DebugConsoleCmdHandler.Debug(true);
            }
        }
        public static void StopConsole()
        {
            ConsoleCreated = false;
            FreeConsole();
        }
        public static void WriteLineColor(string text, ConsoleColor color)
        {
            if (!ConsoleCreated)
            {
                UtilityScript.WriteError("Console must be created before being used!", "Error");
                return;
            }
            //these 3 lines are important, So I need to make them a method.
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static string ReadConsole(string displaypath)
        {
            if (!ConsoleCreated)
            {
                UtilityScript.WriteError("Console must be created before being used!", "Error");
                return null;
            }
            Console.Write(displaypath);
            return Console.ReadLine();
        }
    }
}
