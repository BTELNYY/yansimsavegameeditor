global using System;
global using System.Linq;
global using System.Windows.Forms;
global using Microsoft.Win32;
global using System.IO;
global using System.Text.RegularExpressions;
using System.Diagnostics;
#nullable disable
namespace YandereSaveEditor
{
    internal static class Program
    {
        //DO NOT FORGET TO UPDATE!!!!!!
        public static readonly string version = "1.8.5";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //do not put any windows forms code above this
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Globals.debugConsole)
            {
                //checks if the debug flag is pulled, if yes, calls a new console window.
                DebugConsole.StartConsole();
            }
            if (!UtilityScript.DirExists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }
            Log.Header(); //write a header.
            Log.Info("Starting Application. Version: " + version);
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            try
            {
                config.DeleteValue("profile");
            }
            catch
            {
                //do nothing
            }
            bool exists = UtilityScript.FileExists("YandereSimulator.exe"); //does not check for JSONs, bot honestly the only way this cuases an issue is when people cuase it to be an issue, there is no way that this breaks unless some smart ass deleted the JSONs they had, even then I can probobly get new ones from a website. 
            bool checkFiles = true; //keep true, this was used for debugging.
            if (!exists & checkFiles == true)
            {
                VerifyAppAge();
                UtilityScript.WriteError("YandereSimulator.exe could not be found in the applications folder, please copy this program to that folder. Including .dlls", "File Not Found");
                Log.FatalError("Unable to locate YandereSimulatr, exiting application.");
                Application.Exit();
            }
            else //since Application.Ext(); is not enough for this app, this will have to do.
            {
                Log.Info("Application checks passed, launching main form.");
                Application.Run(new MainForm());
            };
            //the else statement catches all other results from the check, its not possible for the code bellow this to ever run. unless C# suddenly forgets how to use if.
            //do not put anything bellow this point. wont run.  
        }
        public static void VerifyAppAge()
        {
            string filename = Process.GetCurrentProcess().MainModule.FileName;
            FileInfo yansim = new FileInfo("YandereSimulator.exe");
            FileInfo curexe = new FileInfo(filename);
            if (yansim.LastWriteTime > curexe.LastWriteTime)
            {
                UtilityScript.WriteWarning("YandereSimulator.exe is newer than this application, please update this application to the newest version, as the version you are using may not work correctly with this version of YanSim.", "Outdated Application");
            }
        }
    }
}
