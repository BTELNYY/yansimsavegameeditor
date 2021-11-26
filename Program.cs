using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            Application.Run(new MainForm());
            //Dont put anything Bellow this statment or it will never run.
        }
    }
}
