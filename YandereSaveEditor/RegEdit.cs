using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;
#nullable disable
namespace YandereSaveEditor
{
    //this works just fine, do not touch it.

    public class RegEdit
    {
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
        //how does this work? good question. I don't know. 
        //welcome to stackoverflow, this works, but how?
        public static void SetCorruptValue(string name, double d)
        {
            string path = "SOFTWARE\\YandereDev\\YandereSimulator\\";
            string valName = name;
            double value = d;
            UIntPtr hKey = UIntPtr.Zero;
            try
            {
                if (RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, 0x20006, out hKey) != 0)
                {
                    Utility.WriteError("Error opening key for registry editing.", "Error");
                }


                int size = 8;
                IntPtr pData = Marshal.AllocHGlobal(size);
                Marshal.WriteInt64(pData, BitConverter.DoubleToInt64Bits(value));
                if (RegSetValueEx(hKey, valName, 0, RegistryValueKind.DWord, pData, size) != 0)
                {
                    Utility.WriteError("Failed to write registry data.", "Error");
                }

            }
            finally
            {
                if (hKey != UIntPtr.Zero)
                {
                    RegCloseKey(hKey);
                }


            }
        }
        public static void SetCorruptValue(string name, float d)
        {
            string path = "SOFTWARE\\YandereDev\\YandereSimulator\\";
            string valName = name;
            double value = d;
            UIntPtr hKey = UIntPtr.Zero;
            try
            {
                if (RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, 0x20006, out hKey) != 0)
                {
                    Utility.WriteError("Error opening key for registry editing.", "Error");
                }


                int size = 8;
                IntPtr pData = Marshal.AllocHGlobal(size);
                Marshal.WriteInt64(pData, BitConverter.DoubleToInt64Bits(value));
                if (RegSetValueEx(hKey, valName, 0, RegistryValueKind.DWord, pData, size) != 0)
                {
                    Utility.WriteError("Failed to write registry data.", "Error");
                }

            }
            finally
            {
                if (hKey != UIntPtr.Zero)
                {
                    RegCloseKey(hKey);
                }


            }
        }
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
                Log.Debug("Getting data for " + name);
                return result;
            }
            catch (Exception e)
            {
                //returns error as string
                Log.Error("Failed during registry operation: " + e.ToString());
                Utility.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
        public static string editValue(RegistryKey key, int value, string name)
        {
            //edits the value of a key
            try
            {
                key.SetValue(name, value);
                Log.Debug("Set value for key " + name + " to " + value.ToString());
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                Utility.WriteError("Failure during registry operation: " + e.ToString(), "Error");
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
                Utility.WriteError("Failure during registry operation: " + e.ToString(), "Error");
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
                Utility.WriteError("Failure during registry operation: " + e.ToString(), "Error");
                return e.ToString();
            }
        }
    }
}
