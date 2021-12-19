using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace YanSimSaveEditor
{
    internal class Update
    {
        public static void checkUpdate()
        {
            try
            {
                string url = "https://btelnyy.github.io/yansimsavegameeditor/";
                WebClient client = new WebClient();
                string web = client.DownloadString(url);
                string[] website = web.Split(' '); //splits the resulting string into a array based on spaces.
                string version = (string)website.GetValue(0);
            }catch(Exception e)
            {
                Utility.WriteError("Unable to check for updates. Check your internet connection, firewall, or if the server is online. Details: \n" + e.ToString(), "Error");
            }
        }
    }
}
