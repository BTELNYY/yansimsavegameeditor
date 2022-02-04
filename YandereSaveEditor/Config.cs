﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace YanSimSaveEditor
{
    internal class Config
    {
        public static string GetValue(string name, string defaultvalue)
        {
            //checks if a value with that name exists, if no, make a new one with a default value
            RegistryKey? reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\btelnyy\\YanSaveEdit");
            if(reg == null)
            {
                //creates a key if the key does not exist already.
                Registry.CurrentUser.CreateSubKey("\\SOFTWARE\\btelnyy\\YanSaveEdit");
            }
            if (!reg.GetValueNames().Contains(name))
            {
                reg.SetValue(name, defaultvalue);
                return defaultvalue;
            }
            else
            {
                if(reg.GetValue(name).ToString() == null)
                {
                    return defaultvalue;
                }
                else
                {
                    return reg.GetValue(name).ToString();
                }
            }
        }
        public static void SetValue(string name, string value)
        {
            //sets a config value
            RegistryKey? reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\btelnyy\\YanSaveEdit");
            if (reg == null)
            {
                //creates a key if the key does not exist already.
                Registry.CurrentUser.CreateSubKey("\\SOFTWARE\\btelnyy\\YanSaveEdit");
            }
            reg.SetValue(name, value);
        }
        public static void DeleteAll()
        {
            //deletes everything from the registry regarding this application, used for uninstalls
            RegistryKey? reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\btelnyy\\");
            reg.DeleteSubKey("YanSaveEdit");
        }
    }
}
