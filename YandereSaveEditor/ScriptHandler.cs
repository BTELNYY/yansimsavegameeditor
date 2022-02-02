using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using YanSimSaveEditor;
namespace YandereSaveEditor
{
    internal class ScriptHandler
    {
        public static void Script(string path)
        {
            StreamReader sw = new StreamReader(path);
            string readdata = sw.ReadToEnd();
            string[] script = { };
            while (!sw.EndOfStream)
            {
                script.Append(sw.ReadLine());
            }
            Log.Info($"Seperated script file {path} into {script.Length} elements");
            ScriptLogic(script);
        }
        private static void ScriptLogic(string[] script)
        {
            //method handles IO for registry and JSON data.


        }
        private static void ScriptStudent(string operation, string id, string? value)
        {
            string profile = ScriptHandler.profile;
            string student = id;
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string studentdead = UtilityScript.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true);
            string studentrep = UtilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
            string kidnapped = UtilityScript.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
            string photo = UtilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
            string dying = UtilityScript.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
            string friend = UtilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
            try
            {
                switch (operation)
                {
                    case "rep":
                        gamereg.SetValue(studentrep, value);
                        break;
                }
            }catch(Exception e)
            {
                UtilityScript.WriteError($"Error occured while parsing script: \n \n {e}", "Error");
            }
        }
        private static string SelectString(string[] array, string pattern)
        {
            //gets list of values
            foreach (string s in array)
            {
                //check if the pattern matches the current position in array, if yes, return the name of the value otherwise try again
                bool result = Regex.IsMatch(s, pattern + @"*"); //regex is my nightmare
                if (result)
                {
                    return s;
                }
                else if (!result)
                {
                    continue;
                }
                //returns null if the loop breaks. cuz yes.
                return null;
            }
            return null;
        }

        private static string? profile { get; set; }
    }
}
