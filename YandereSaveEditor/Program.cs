using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace YanSimSaveEditor
{
    internal static class Program
    {
        //DO NOT FORGET TO UPDATE!!!!!!
        public static readonly string version = "1.6.6";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            /*
            ben summary.
            "//" is a comment statement, everything after that on the same line will not be exectued, meant for humans.
            calling a function can be done by refrencing the class and the method within it
            EX: Utility.WriteError("Test", "Test") would display a error stating test, test. 
            the to things within the brackets () and qoutes "" and seperated by a coma , are arguments.
            Visual studio will kindly tell you when you are calling a method with invalid arguments, however we do have methods for converting data types. a very useful one is .ToString(), this allows you to convert almost anything into a string, granted its not a custom object.
            The Utility.cs has plenty of convertion methods for you to use.
            How a method looks.
            public static string test(string test){ the "public static string" means that anyone can access the method from anywhere in the file (public) static means that it only runs when called, and string means it returns a string when called. the "string test" mean that the method takes a string as an input, and internally uses the name "test" to refrence that input. "test" does not need to be used by you to call the method, any vairaible will do.
                here would be the code, if you have any
                
                because you used "string" when defining the method, your method MUST return a string, and only a string.
                return test;
            }

            calling a non-static method reqiues an extra line of code:
            say test is not a static class
            I cant do test.nonstatic, as its not a static method, instead I do:
            test nonstatic = new test(); the first test is the "data type", this simply means that nonstatic is non-static method. the second is a vairable name which you can use to then call the class by
            the last test is needed as a class call, it means make a new instance of this class for you to use.
            you can now do:
            test.nonstatic(); without issue. 


            */
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
    }
}
