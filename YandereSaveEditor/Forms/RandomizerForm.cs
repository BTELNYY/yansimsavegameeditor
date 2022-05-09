using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
#nullable disable
namespace YandereSaveEditor
{
    public partial class randomizerForm : Form
    {
        public randomizerForm()
        {
            InitializeComponent();
        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            //works with the random function to fill values with randomness......
            //this affects all values except the death checkbox, name, realname, desc, class and seat
            int[] students = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 }; //HOLY FUCKING JESUS KILL ME NOW
            int[] clubs = { 0, 1, 2, 3, 4, 5, 6, 7, 9, 9, 10, 11, 12, 13, 14, 99, 100, 101, 102 };
            int[] personas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 99 };
            int[] strength = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 99 };
            string profile = UtilityScript.GetProfile();
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            DialogResult result;
            result = MessageBox.Show("Randomize all students? This action cannot be undone without file editing! \n \n Do not terminate until all clear message. (unless you like corruption)", "Randomize all",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                randomizerForm form = new randomizerForm();
                form.Refresh();

                try
                {
                    try
                    {
                        if (UtilityScript.ToInteger(profile) > 3)
                        {
                            File.Copy(UtilityScript.GetJSON(), "Eighties-BACKUP.json", false);
                            Log.Debug("Copied Eighties JSON.");
                        }
                        else
                        {
                            File.Copy(UtilityScript.GetJSON(), "Students-BACKUP.json", false);
                            Log.Debug("Copied Students JSON.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("An error occured during randomizer backup process: " + ex.ToString());
                        //do nothing
                        //this prevents the files from being overwritten again, allowing the user to return to originals.
                    }
                    foreach (int student in students)
                    {
                        student studentjson = JSONEdit.GetInfo(student);
                        string studentrep = UtilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                        string photo = UtilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                        string friend = UtilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                        string panty = UtilityScript.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
                        string reputation = UtilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);


                        //I have become the thing I swore to destroy......


                        if (repCheck.Checked)
                        {
                            RegEdit.editValue(gamereg, UtilityScript.GetRandomInt(-100, 100), reputation);
                        }


                        if (photoCheck.Checked)
                        {
                            RegEdit.editValue(gamereg, UtilityScript.GetRandomInt(0, 3), photo);
                        }


                        if (friendCheck.Checked)
                        {
                            RegEdit.editValue(gamereg, UtilityScript.GetRandomInt(0, 3), friend);
                        }

                        if (pantyCheck.Checked)
                        {
                            RegEdit.editValue(gamereg, UtilityScript.GetRandomInt(0, 3), panty);
                        }

                        if (bustCheckbox.Checked)
                        {
                            studentjson.BreastSize = UtilityScript.GetRandomDouble(0, 2, 0, 9).ToString();
                        }

                        if (accessoryCheck.Checked)
                        {
                            studentjson.Accessory = UtilityScript.GetRandomInt(0, 15).ToString();
                        }
 
                        if (clubCheck.Checked)
                        {
                            studentjson.Club = clubs.GetValue(UtilityScript.GetRandomInt(0, 19)).ToString();
                        }
 
                        if (crushCheck.Checked)
                        {
                            studentjson.Crush = UtilityScript.GetRandomInt(0, 101).ToString();
                        }
     
                        if (hairstyleCheck.Checked)
                        {
                            studentjson.Hairstyle = UtilityScript.GetRandomInt(0, 201).ToString();
                        }

                        if (personaCheck.Checked)
                        {
                            studentjson.Persona = personas.GetValue(UtilityScript.GetRandomInt(1, 18)).ToString();
                        }

                        if (strengthCheck.Checked)
                        {
                            studentjson.Strength = strength.GetValue(UtilityScript.GetRandomInt(0, 10)).ToString();
                        }
                        JSONEdit.WriteInfo(studentjson);
                        progressBar.Value = student;
                        Log.Debug("Randomizing students. Current Student: " + student.ToString());
                    }
                    //hide, close it and dispose of the form as we no longer need it.
                    UtilityScript.WriteInfo("Finished, if you wish to go back, delete Students.json within the normal JSON folder and rename Students-BACKUP.json to Students.json, after this, copy this new file to your JSON folder. this will restore all previous data for the students (Same goes for Eighties, but the file name is Eighties-BACKUP.json). Note that profile data cannot be reverted.", "Done");
                }
                catch (Exception ex)
                {
                    Log.Error("Error occured during randomize process: " + ex.ToString());
                    UtilityScript.WriteError(ex.ToString(), "Error");
                }
            }
            else
            {
                //the question answer was no, therefore return back to the randomizer config screen and do nothing about it.
                Log.Info("User cancelled randomizer process.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/P22tFkjTm3");
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BTELNYY/yansimsavegameeditor");
        }
    }
}
