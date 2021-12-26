using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace YanSimSaveEditor
{
    public class Upgrade
    {
        public static int checkUpdate()
        {
            try
            {
                string url = "https://btelnyy.github.io/yansimsavegameeditor/Website/version.html";
                WebClient client = new WebClient();
                string web = client.DownloadString(url);
                string[] website = web.Split(' '); //splits the resulting string into a array based on spaces.
                string version = (string)website.GetValue(0);
                int remotever = UtilityScript.ToInteger(version.Replace(".", string.Empty));
                string localver = Program.version;
                int currentver = UtilityScript.ToInteger(localver.Replace(".", string.Empty));
                //WHAT THE FUCK IS GOING ON HERE??!?!?!?!?!?!?!?
                if (remotever > currentver)
                {
                    //outdated client, handle question for user
                    DialogResult result;
                    result = MessageBox.Show("An Update is available, open download?", "Update Available",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //opens the default browser and searches this URL.
                        System.Diagnostics.Process.Start("https://github.com/btelnyy/yansimsavegameeditor/releases");
                        return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (remotever < currentver)
                {
                    //The current version is somehow newer then the remote version, print a warning.
                    UtilityScript.WriteWarning("Public version counter may be outdated, notify developers.", "Version Mismatch");
                    return 3;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception e)
            {
                UtilityScript.WriteError("Unable to check for updates. Check your internet connection, firewall, or if the server is online. Details: \n" + e.ToString(), "Error");
                return 2;
            }
        }
    }
}
