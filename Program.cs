using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YanSimSaveEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //do not put any windows forms code above this
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //checks if YandereSimulator is in the same folder as the application
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            try
            {
                config.DeleteValue("profile");
            }
            catch(Exception e)
            {
                //do nothing since its ok if this breaks.
            }
            bool exists = Utility.FileExists("YandereSimulator.exe");
            bool checkFiles = false; //change this to true once we are done rigging UI
            //JSONEdit.GetInfo(1);
            //enable later.
            if (!exists & checkFiles==true)
            {
                Utility.WriteError("YandereSimulator.exe could not be found in the applications folder, please copy this program to that folder. Including .dlls", "File Not Found");
                Application.Exit();
            }
            else //had to make it else otherwise the form would still show.
            {
                Application.Run(new MainForm());
            }
            //Dont put anything Bellow this statment or it will never run.
        }
    }
}
