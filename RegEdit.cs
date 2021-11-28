using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace YanSimSaveEditor
{
    public class RegEdit
    {
        public static string[] returnValuesList(RegistryKey key)
        {
            //returns an arrey of all the values in a subkey
            string[] result = key.GetValueNames();
            
            return result;
        }
        public static string returnValue(RegistryKey key, string name)
        {
            //returns the value of a key
            try
            {

                string result = key.GetValue(name).ToString();
                
                return result;
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
        public static string editValue(RegistryKey key, int value, string name)
        {
            //edits the value of a key
            try
            {
                key.SetValue(name, value);
                
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
        public static string createValue(RegistryKey key, int value, string name)
        {
            //creates a key
            try
            {
                key.SetValue(name, value);
 
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
        public static string Delete(RegistryKey key, string name)
        {
            //creates a key
            try
            {
                key.DeleteValue(name);

                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
        
        
    }
}
