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
                    case "modify":
                        modify(UtilityScript.ToInteger(inputargs[1]), inputargs[2], inputargs[3], inputargs[4]);
                        break;
                }
            }
        }
        public static void modify(int id, string profile, string type, string value)
        {
            int[] students = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 }; //HOLY FUCKING JESUS KILL ME NOW
            string[] profiles = { "1", "2", "3", "11", "12", "13" };
            if (!students.Contains(id))
            {
                DebugConsole.WriteLineColor("Error: Invalid syntax. Syntax: ID, Profile, value name, new value.", ConsoleColor.Red);
                return;
            }
            if (!profiles.Contains(profile))
            {
                DebugConsole.WriteLineColor("Error: Invalid syntax. Syntax: ID, Profile, value name, new value.", ConsoleColor.Red);
                return;
            }



            UtilityScript.SetProfile(profile);
            try
            {
                PropertyInfo student1 = typeof(student).GetProperty(type);
                student studentjson = JSONEdit.GetInfo(id);
                object property = UtilityScript.GetPropValue(studentjson, type);
                student1.SetValue(property, value);
            }
            catch (Exception ex)
            {
                DebugConsole.WriteLineColor("Error: " + ex.ToString(), ConsoleColor.Red);
                DebugConsole.WriteLineColor("This is most commonly caused by a invalid property name.", ConsoleColor.White);
            }
            

        }
    }
}
