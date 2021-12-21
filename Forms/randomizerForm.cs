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

namespace YanSimSaveEditor
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
            string profile = utilityScript.getProfile();
            waitForForm waitForForm = new waitForForm();
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            DialogResult result;
            result = MessageBox.Show("Randomize all students? This action cannot be undone without file editing! \n \n Do not terminate until all clear message. (unless you like corruption)", "Randomize all",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (utilityScript.ToInteger(profile) > 3)
                    {
                        File.Copy(utilityScript.GetJSON(), "Eighties1.json", true);
                    }
                    else
                    {
                        File.Copy(utilityScript.GetJSON(), "Students1.json", true);
                    }
                    foreach (int student in students)
                    {
                        //waitForForm = Utility.openWaitForNotification();
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "None", waitForForm);
                        student studentjson = JSONEdit.GetInfo(student);
                        string studentrep = utilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                        string photo = utilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                        string friend = utilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                        string panty = utilityScript.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
                        string reputation = utilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), reputation, waitForForm);
                        if (repCheck.Checked)
                        {
                            regEdit.editValue(gamereg, utilityScript.getRandomInt(-100, 100), reputation);
                        }


                        //Utility.updateWaitForNotification("Student: " + student.ToString(), photo, waitForForm);
                        if (photoCheck.Checked)
                        {
                            regEdit.editValue(gamereg, utilityScript.getRandomInt(0, 3), photo);
                        }


                        //Utility.updateWaitForNotification("Student: " + student.ToString(), friend, waitForForm);
                        if (friendCheck.Checked)
                        {
                            regEdit.editValue(gamereg, utilityScript.getRandomInt(0, 3), friend);
                        }

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), panty, waitForForm);
                        if (pantyCheck.Checked)
                        {
                            regEdit.editValue(gamereg, utilityScript.getRandomInt(0, 3), panty);
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "BreastSize", waitForForm);
                        if (bustCheckbox.Checked)
                        {
                            studentjson.BreastSize = utilityScript.getRandomDouble(0, 2, 0, 9).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Accessory", waitForForm);
                        if (accessoryCheck.Checked)
                        {
                            studentjson.Accessory = utilityScript.getRandomInt(0, 15).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Club", waitForForm);
                        if (clubCheck.Checked)
                        {
                            studentjson.Club = clubs.GetValue(utilityScript.getRandomInt(0, 19)).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Crush", waitForForm);
                        if (crushCheck.Checked)
                        {
                            studentjson.Crush = utilityScript.getRandomInt(0, 101).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Hairstyle", waitForForm);
                        if (hairstyleCheck.Checked)
                        {
                            studentjson.Hairstyle = utilityScript.getRandomInt(0, 201).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Persona", waitForForm);
                        if (personaCheck.Checked)
                        {
                            studentjson.Persona = personas.GetValue(utilityScript.getRandomInt(1, 18)).ToString();
                        }
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Strength", waitForForm);
                        if (strengthCheck.Checked)
                        {
                            studentjson.Strength = strength.GetValue(utilityScript.getRandomInt(0, 10)).ToString();
                        }
                        JSONEdit.WriteInfo(studentjson);
                    }
                    //hide, close it and dispose of the form as we no longer need it.
                    utilityScript.closeWaitForNotification(waitForForm);
                    utilityScript.WriteInfo("Finished, if you wish to go back, delete Students.json within the normal JSON folder and rename Students1.json to Students.json, after this, copy this new file to your JSON folder. this will restore all previous data for the students. Note that profile data cannot be reverted.", "Done");
                }
                catch (Exception ex)
                {
                    utilityScript.WriteError(ex.ToString(), "Error");
                }
            }
            else
            {
                //the question answer was no, therefore return back to the student config screen and do nothing about it.
                utilityScript.WriteInfo("Operation Aborted", "Done.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/P22tFkjTm3");
        }
    }
}
