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
        //DO NOT FORGET TO UPDATE!!!!!!
        public static string version = "1.6.1";
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
            //checks if YandereSimulator is in the same folder as the application
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");
            try
            {
                config.DeleteValue("profile");
            }
            catch
            {
                //do nothing
            }
            bool exists = utilityScript.FileExists("YandereSimulator.exe");
            bool checkFiles = true; //change this to true once we are done rigging UI
            //JSONEdit.GetInfo(1);
            //enable later.
            if (!exists & checkFiles==true)
            {
                utilityScript.WriteError("YandereSimulator.exe could not be found in the applications folder, please copy this program to that folder. Including .dlls", "File Not Found");
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
