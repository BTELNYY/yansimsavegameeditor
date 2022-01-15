using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace YanSimSaveEditor
{
    internal class DebugConsoleCmdHandler
    {
        public static void Debug(bool nolog)
        {
            if (!DebugConsole.ConsoleCreated)
            {
                UtilityScript.WriteError("Console must be created before being used!", "Error");
                return;
            }
            while (nolog)
            {
                string input = DebugConsole.ReadConsole("> ");
                string[] inputargs = UtilityScript.SeperateIntoArray(input, ' ');
                switch (inputargs[0])
                {
                    default:
                        DebugConsole.WriteLineColor("Error: Unkown command.", ConsoleColor.Red);
                        Debug(true);
                        break;
                    case "version":
                        DebugConsole.WriteLineColor(Program.version, ConsoleColor.White);
                        break;
                    case "exit":
                        DebugConsole.StopConsole();
                        break;
                    case "log":
                        if (Globals.noLogPrint)
                        {
                            DebugConsole.WriteLineColor("Error: Cannot show log if console logging is disabled.", ConsoleColor.Red);
                        }
                        else
                        {
                            DebugConsole.WriteLineColor("Showing game log", ConsoleColor.White);
                            Debug(false);
                            nolog = false;
                        }
                        break;
                    case "update":
                        int update = Upgrade.checkUpdate();
                        //I am doing an ALEX MOMENT, HELP ME
                        if (update == 2)
                        {
                            DebugConsole.WriteLineColor("Error occured when checking for update.", ConsoleColor.Red);
                        }
                        else if (update == 0)
                        {
                            DebugConsole.WriteLineColor("Application up to date.", ConsoleColor.Green);
                        }
                        else if (update == 1)
                        {
                            DebugConsole.WriteLineColor("Application is outdated.", ConsoleColor.Yellow);
                        }
                        else if (update == 3)
                        {
                            DebugConsole.WriteLineColor("Server is outdated.", ConsoleColor.Yellow);
                        }
                        break;
                }
            }
        }
    }
}
