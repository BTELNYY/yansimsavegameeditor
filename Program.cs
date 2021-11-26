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
            //check if the games directory is set and exists, if not, call set game dir. (open)
            Open SetGameDir = new Open();
            //logic stuff
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            try
            {
                try
                {
                    string result = config.GetValue("gamePath").ToString();
                }
                catch(Exception e)
                {
                    string result = SetGameDir.ShowDialog().ToString();
                    Utility.WriteInfo(result, "Result");
                    config.SetValue("gamePath", result);
                };

                config.Close();
                //if(result.Length < 0)
                //{
                  //  SetGameDir.ShowDialog();
                //}
            }
            catch (Exception e)
            {
                //returns error as string
                Utility.WriteError(e.ToString(), "Error While opening registry key");
            }
            

            Application.Run(new MainForm());
            //Dont put anything Bellow this statment or it will never run.
        }
    }
}
