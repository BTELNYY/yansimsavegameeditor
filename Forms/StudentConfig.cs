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

namespace YanSimSaveEditor
{
    public partial class StudentConfig : Form
    {
        public StudentConfig()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            StudentConfig StudentConfig = new StudentConfig();
            //what even is this bullshit?
            StudentConfig.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudentSelect.SelectedIndex < 0)
                {
                    Utility.WriteError("You must select a NPC ID!", "Error");
                }
                else
                {
                    //while this could be done in a 2d array foreach loop, I am too lazy. it would also do
                    //almost nothing different except how many lines of code this C# file has. Which is kinda a shitty trade.
                    string student = StudentSelect.Text;
                    string[] rivals = { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
                    int index = Array.IndexOf(rivals, StudentSelect.SelectedItem);
                    if (index > -1)
                    {
                        RivalCheckBox.Checked = true;
                    }
                    else
                    {
                        RivalCheckBox.Checked = false;
                    };
                    string profile = Utility.getProfile();
                    RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                    //changes a label
                    idLabel.Text = "ID:" + student;
                    bool allowpfp = false; //enables or disables the ability to show pfps of the student. DEBUG ONLY
                    string[] twentytwentyx = { "1", "2", "3" };
                    int array20 = Array.IndexOf(twentytwentyx, profile);
                    if (array20 > -1 & allowpfp == true)
                    {
                        string path = @".\YandereSimulator_Data\StreamingAssets\Portraits\";
                        Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
                        string file = path + "Student_" + StudentSelect.SelectedItem + ".png";
                        Portrait.Image = Image.FromFile(file);
                    }
                    else if (array20 < -1 & allowpfp == true)
                    {
                        string path = @".\YandereSimulator_Data\StreamingAssets\Portraits1989\";
                        Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
                        string file = path + "Student_" + StudentSelect.SelectedItem + ".png";
                        Portrait.Image = Image.FromFile(file);
                    }
                    string studentdead = Utility.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true); //the _ is needed so my method doesnt shit itself.
                    string studentdeadvalue = RegEdit.returnValue(gamereg, studentdead);
                    if (studentdeadvalue == "1")
                    {
                        DeathCheckbox.Checked = true;
                    }
                    else
                    {
                        DeathCheckbox.Checked = false;
                    }
                    string studentrep = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + StudentSelect.SelectedItem + "_", true);
                    string studentrepvalue = RegEdit.returnValue(gamereg, studentrep);
                    ReputationTextbox.Text = studentrepvalue;
                    //kidnapped?
                    string kidnapped = Utility.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
                    string kidanppedvalue = RegEdit.returnValue(gamereg, kidnapped);
                    if (kidanppedvalue == "1")
                    {
                        KidnapChekbox.Checked = true;
                    }
                    else
                    {
                        KidnapChekbox.Checked = false;
                    }
                    string photo = Utility.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                    string photovalue = RegEdit.returnValue(gamereg, photo);
                    if (photovalue == "1")
                    {
                        PhotographedCheckbox.Checked = true;
                    }
                    else
                    {
                        PhotographedCheckbox.Checked = false;
                    }
                    string dying = Utility.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
                    string dyingvalue = RegEdit.returnValue(gamereg, dying);
                    if (dyingvalue == "0")
                    {
                        DyingCheckbox.Checked = false;
                    }
                    else
                    {
                        DyingCheckbox.Checked = true;
                    }
                    string friend = Utility.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                    string friendvalue = RegEdit.returnValue(gamereg, friend);
                    if (friendvalue == "1")
                    {
                        FriendCheckbox.Checked = true;
                    }
                    else
                    {
                        FriendCheckbox.Checked = false;
                    }

                }
            }
            catch (Exception loaderror)
            {
                Utility.WriteError(loaderror.ToString(), "Error");
            }
        }

        private void StudentConfig_Load(object sender, EventArgs e)
        {
            
        }
    }
}
