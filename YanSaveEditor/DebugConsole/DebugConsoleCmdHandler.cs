using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Win32;

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
                    case "getvalue":
                        GetValue(inputargs);
                        break;
                    case "gethexvalue":
                        GetHexValue(inputargs);
                        break;
                    case "getdecvalue":
                        GetDecValue(inputargs);
                        break;
                    case "toint":
                        ConvertToInt32(inputargs);
                        break;
                }
            }
        }
        private static void GetValue(string[] args)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string value = RegEdit.returnValue(key, UtilityScript.SelectString(args[1], false));
                DebugConsole.WriteLineColor(value, ConsoleColor.White);
            }
            catch (Exception e)
            {
                DebugConsole.WriteLineColor("Error occured while getting value. " + e.ToString(), ConsoleColor.Red);
            }
        }
        private static void GetHexValue(string[] args)
        {
            try
            {
                DebugConsole.WriteLineColor(UtilityScript.GetHexValue(args[1]), ConsoleColor.White);
            }
            catch (Exception e)
            {
                DebugConsole.WriteLineColor("Error getting hex value. " + e.ToString(), ConsoleColor.Red);
            }
        }
        private static void GetDecValue(string[] args)
        {
            try
            {
                DebugConsole.WriteLineColor(UtilityScript.GetDecValue(args[1]), ConsoleColor.White);
            }
            catch (Exception e)
            {
                DebugConsole.WriteLineColor("Error converting integer to long. " + e.ToString(), ConsoleColor.Red);
            }
        }
        private static void ConvertToInt32(string[] args)
        {
            try
            {
                DebugConsole.WriteLineColor(Convert.ToInt32(args[1]).ToString(), ConsoleColor.White);
            }catch(Exception e)
            {
                DebugConsole.WriteLineColor("Error converting double to integer. " + e.ToString(), ConsoleColor.Red);
            }
        }
    }
}
