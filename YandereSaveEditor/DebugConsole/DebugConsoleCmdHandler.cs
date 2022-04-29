using Microsoft.Win32;
using System.Runtime.InteropServices;
#nullable disable
namespace YandereSaveEditor
{
    internal class DebugConsoleCmdHandler
    {
        //this script is used for the DebugConsole.cs script, I dont care that its messy, its debug code, not meant for usage.
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
                //I am aware this may spam the screen, but who cares?
                Log.Debug($"User command input: {inputargs[0]}");
                switch (inputargs[0])
                {
                    default:
                        Log.Error("Unkown Command.");
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
                    case "todouble":
                        try
                        {
                            double output = BitConverter.Int64BitsToDouble(Int64.Parse(inputargs[1]));
                            DebugConsole.WriteLineColor(output.ToString(), ConsoleColor.White);
                        }catch(Exception e)
                        {
                            DebugConsole.WriteLineColor("Error: " + e.ToString(), ConsoleColor.Red);
                        }
                        break;
                    case "setvalue":
                        SetNamedValue(inputargs);
                        break;
                    case "getfullname":
                        DebugConsole.WriteLineColor(UtilityScript.SelectString(inputargs[1], false), ConsoleColor.White);
                        break;
                    case "script":
                        try
                        {
                            string path = UtilityScript.OpenFileDialog(".\\", "txt files (*.txt)|*.txt|All files (*.*)|*.*");
                            DebugConsole.WriteLineColor("Enter profile.", ConsoleColor.White);
                            string profile = DebugConsole.ReadConsole("> ");
                            ScriptHandler.Script(path, profile);
                            break;
                        }
                        catch (Exception e)
                        {
                            DebugConsole.WriteLineColor(e.ToString(), ConsoleColor.Red);
                        }
                        break;
                    case "setprofile":
                        UtilityScript.SetProfile(inputargs[1]);
                        break;
                    case "gettopic":
                        //fuck you, and ill see you tomorrow
                        string output1 = JSONEdit.GetTopicValue(inputargs[1], inputargs[2]);
                        DebugConsole.WriteLineColor(output1, ConsoleColor.White);
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
        [DllImport("advapi32.dll")]
        static extern uint RegSetValueEx(
        UIntPtr hKey,
        [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
        int Reserved,
        RegistryValueKind dwType,
        IntPtr lpData,
        int cbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern uint RegOpenKeyEx(
            IntPtr hKey,
            string subKey,
            int ulOptions,
            int samDesired,
            out UIntPtr hkResult);

        [DllImport("advapi32.dll")]
        public static extern int RegCloseKey(UIntPtr hKey);

        static public readonly IntPtr HKEY_CURRENT_USER = new IntPtr(-2147483647);

        public static void SetNamedValue(string[] args)
        {
            string path = "SOFTWARE\\YandereDev\\YandereSimulator\\";
            string valName = args[1];
            double value = double.Parse(args[2]);
            UIntPtr hKey = UIntPtr.Zero;
            try
            {
                if (RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, 0x20006, out hKey) != 0)
                {
                    UtilityScript.WriteError("Error opening key for registry editing.", "Error");
                }
                    

                int size = 8;
                IntPtr pData = Marshal.AllocHGlobal(size);
                Marshal.WriteInt64(pData, BitConverter.DoubleToInt64Bits(value));
                if (RegSetValueEx(hKey, valName, 0, RegistryValueKind.DWord, pData, size) != 0)
                {
                    UtilityScript.WriteError("Failed to write registry data.", "Error");
                }

            }
            catch(Exception e)
            {
                DebugConsole.WriteLineColor("So Bassicly something went wrong, so the finally loop is running.", ConsoleColor.White);
                UtilityScript.WriteError("Something went wrong: " + e.ToString(), "Error");
                if (hKey != UIntPtr.Zero)
                {
                    RegCloseKey(hKey);
                }


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
                double d = UtilityScript.ToDouble(args[1]);
                long longVal = BitConverter.DoubleToInt64Bits(d);
                DebugConsole.WriteLineColor(longVal.ToString(), ConsoleColor.White);
            }
            catch (Exception e)
            {
                DebugConsole.WriteLineColor("Error converting double to integer. " + e.ToString(), ConsoleColor.Red);
            }
        }
    }
}
