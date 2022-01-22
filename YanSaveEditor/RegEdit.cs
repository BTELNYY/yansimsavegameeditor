using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace YanSimSaveEditor
{
    //this works just fine, do not touch it.
    public class RegEdit
    {
        public static string[] returnValuesList(RegistryKey key)
        {
            //returns an arrey of all the values in a subkey
            string[] result = key.GetValueNames();
            Log.Debug("Returning all values for registry key " + key.ToString());
            return result;
        }
        public static string returnValue(RegistryKey key, string name)
        {
            //returns the value of a key
            try
            {

                string result = key.GetValue(name).ToString();
                Log.Debug("Getting data for " + name);
                return result;
            }
            catch (Exception e)
            {
                //returns error as string
                Log.Error("Failed during registry operation: " + e.ToString());
                UtilityScript.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
        public static string editValue(RegistryKey key, int value, string name)
        {
            //edits the value of a key
            try
            {
                key.SetValue(name, value);
                Log.Debug("Set value for key " + name);
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                UtilityScript.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
        public static string createValue(RegistryKey key, int value, string name)
        {
            //creates a key
            try
            {
                key.SetValue(name, value);
                Log.Debug("Created a new registry value: " + name);
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                UtilityScript.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
        public static string Delete(RegistryKey key, string name)
        {
            //creates a key
            try
            {
                key.DeleteValue(name);
                Log.Debug("Deleted registry value " + name);
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                Log.Error("Failure during registry operation: " + e.ToString());
                UtilityScript.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
    }
}
