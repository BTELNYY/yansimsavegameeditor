using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
#nullable disable
namespace YandereSaveEditor
{
    public class Upgrade
    {
        public static int checkUpdate()
        {
            try
            {
                Log.Info("Checking for updates");
                string url = "https://btelnyy.github.io/yansimsavegameeditor/Website/version.html";
                //oh stfu about obselete, this was fine in fremework 4.8, its gonna work now.
                WebClient client = new WebClient();
                string web = client.DownloadString(url);
                string[] website = web.Split(' '); //splits the resulting string into a array based on spaces.
                string version = (string)website.GetValue(0);
                int remotever = Utility.ToInteger(version.Replace(".", string.Empty));
                string localver = Program.version;
                int currentver = Utility.ToInteger(localver.Replace(".", string.Empty));
                if (remotever > currentver)
                {
                    //outdated client, handle question for user
                    DialogResult result;
                    result = MessageBox.Show("An Update is available, open download?", "Update Available",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    Log.Info("Update is ready, requesting user to update.");
                    if (result == DialogResult.Yes)
                    {
                        //opens the default browser and searches this URL.
                        System.Diagnostics.Process.Start("https://github.com/btelnyy/yansimsavegameeditor/releases");
                        Log.Info("User opened update webpage.");
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
                    Log.Warning("Public version counter may be outdated or wrong, contact developers.");
                    Utility.WriteWarning("Public version counter may be outdated, notify developers.", "Version Mismatch");
                    return 3;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception e)
            {
                Log.Error("Failed to connect to server: " + e.ToString());
                Utility.WriteError("Unable to check for updates. Check your internet connection, firewall, or if the server is online. Details: \n" + e.ToString(), "Error");
                return 2;
            }
        }
    }
}
