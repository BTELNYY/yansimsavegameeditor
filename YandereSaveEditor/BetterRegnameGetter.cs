﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandereSaveEditor
{
    public static class BetterRegnameGetter
    {
        public static IDictionary<string, string> data = new Dictionary<string, string>();
        static RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
        public static void Load()
        {
            List<string> regvalues = RegEdit.returnValuesList(gamereg).ToList();
            try
            {
                foreach(string value in regvalues)
                {
                    int LastUnderscore = value.LastIndexOf("_");
                    string newvalue = value.Remove(LastUnderscore);
                    if (data.ContainsKey(newvalue))
                    {
                        return;
                    }
                    data.Add(newvalue, value);
                }
            }
            catch(Exception ex)
            {
                Utility.WriteError("Error while loading registry keys! \n \n" + ex.ToString(), "Error: " + ex.Message);
                Utility.BetterRegValLoaderHadError = true;
            }
        }
        public static string GetFullName(string KeyName)
        {
            if (!data.ContainsKey(KeyName))
            {
                Log.Warning("Cannot find registry value " + KeyName + "!");
                string value = Utility.SelectValueNameOld(KeyName, true);
                data.Add(KeyName, value);
            }
            return data[KeyName];
        }
    }
}
