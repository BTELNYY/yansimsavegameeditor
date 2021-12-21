﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YanSimSaveEditor
{
    public partial class StudentConfig : Form
    {
        private bool warncorruoption;
        public StudentConfig()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (warncorruoption)
            {
                result = MessageBox.Show("You are trying to save after a load error occured, if you are correcting invalid values, this is ok. if you did not know an error occured, hit No. \n \n Proceed with save Function?", "Possible Corruption",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            try
            {
                //define the things we need
                string profile = utilityScript.getProfile();
                string student = StudentSelect.Text;
                int studentint = utilityScript.ToInteger(student);
                student studentjson = JSONEdit.GetInfo(studentint);
                student studenjsonread = JSONEdit.GetInfo(studentint);
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string studentdead = utilityScript.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true);
                string studentrep = utilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                string kidnapped = utilityScript.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
                string photo = utilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                string dying = utilityScript.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
                string friend = utilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                //lets get ready to rumble!
                regEdit.editValue(gamereg, utilityScript.ToInteger(ReputationTextbox.Text), studentrep);
                regEdit.editValue(gamereg, utilityScript.ConvertBool(DeathCheckbox.Checked), studentdead);
                regEdit.editValue(gamereg, utilityScript.ConvertBool(KidnapChekbox.Checked), kidnapped);
                regEdit.editValue(gamereg, utilityScript.ConvertBool(PhotographedCheckbox.Checked), photo);
                regEdit.editValue(gamereg, utilityScript.ConvertBool(DyingCheckbox.Checked), dying);
                regEdit.editValue(gamereg, utilityScript.ConvertBool(FriendCheckbox.Checked), friend);
                studentjson.Gender = GenderCombobox.SelectedIndex.ToString();
                studentjson.Name = NicknameTextbox.Text;
                studentjson.RealName = RealnameTextbox.Text;
                //something with negative 67 causes an error somewhere here, however I am unable to locate it.
                int club = ClubCombobox.SelectedIndex;
                if (club > 14)
                {
                    int clubvalue = club - 84;
                    studentjson.Club = clubvalue.ToString();
                }
                else
                {
                    studentjson.Club = club.ToString();
                }
                studentjson.Strength = StrengthCombobox.SelectedIndex.ToString();
                studentjson.Crush = CrushTextbox.Text;
                studentjson.BreastSize = BustTextbox.Text;
                studentjson.Info = DescTextbox.Text;
                studentjson.Accessory = AccessoryCombobox.SelectedIndex.ToString();
                studentjson.Hairstyle = HairCombobox.SelectedIndex.ToString();
                int persona = PersonaCombobox.SelectedIndex;
                if (persona == 99)
                {
                    studentjson.Persona = 99.ToString();
                }
                else
                {
                    studentjson.Persona = PersonaCombobox.SelectedIndex.ToString();
                }
                studentjson.Class = ClassTextbox.Text;
                studentjson.Seat = SeatTextbox.Text;

                //actually write the data
                JSONEdit.WriteInfo(studentjson);
                //execute when finished write
                utilityScript.WriteInfo("All Data Written Successfully", "Done");
                ApplyButton_Click(null, null);
            }
            catch (Exception writeerror)
            {
                utilityScript.WriteError(writeerror.ToString(), "Error");
            }

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
                    utilityScript.WriteError("You must select a NPC ID!", "Error");
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
                    string profile = utilityScript.getProfile();
                    RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                    //changes a label
                    idTextbox.Text = student;
                    bool allowpfp;
                    int studentint = utilityScript.ToInteger(student);
                    int profileint = utilityScript.ToInteger(profile);
                    if (studentint > 97)
                    {
                        Portrait.Visible = false;
                        noImageLabel.Text = "No Image Available.";
                        allowpfp = false;
                    }
                    else
                    {
                        Portrait.Visible = true;
                        noImageLabel.Text = "";
                        allowpfp = true;
                    }
                    //checks if it is the last 3 npcs, which dont have a pfp. (ill make a not found later)
                    if (profileint < 4 & allowpfp == true)
                    {
                        string path = @".\YandereSimulator_Data\StreamingAssets\Portraits\";
                        Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
                        string file = path + "Student_" + StudentSelect.SelectedItem + ".png";
                        Portrait.Image = Image.FromFile(file);
                    }
                    else if (profileint > 4 & allowpfp == true)
                    {
                        string path = @".\YandereSimulator_Data\StreamingAssets\Portraits1989\";
                        Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
                        string file = path + "Student_" + StudentSelect.SelectedItem + ".png";
                        Portrait.Image = Image.FromFile(file);
                    }
                    string studentdead = utilityScript.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true); //the _ is needed so my method doesnt shit itself.
                    //above comment fixed, I added a trim statement.
                    string studentdeadvalue = regEdit.returnValue(gamereg, studentdead);
                    //ok so, what the fuck is this code?
                    DeathCheckbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(studentdeadvalue)); 
                    //kidnapped?
                    string kidnapped = utilityScript.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
                    string kidanppedvalue = regEdit.returnValue(gamereg, kidnapped);
                    KidnapChekbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(kidanppedvalue));
                    string photo = utilityScript.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                    string photovalue = regEdit.returnValue(gamereg, photo);
                    PhotographedCheckbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(photovalue));
                    string dying = utilityScript.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
                    string dyingvalue = regEdit.returnValue(gamereg, dying);
                    DeathCheckbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(dyingvalue));
                    string friend = utilityScript.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                    string friendvalue = regEdit.returnValue(gamereg, friend);
                    FriendCheckbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(friendvalue));
                    string panty = utilityScript.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
                    PantyshotCheckbox.Checked = utilityScript.ToBool(utilityScript.ToInteger(regEdit.returnValue(gamereg, panty))); //jesus
                    string reputation = utilityScript.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                    ReputationTextbox.Text = regEdit.returnValue(gamereg, reputation);
                    student studentjson = JSONEdit.GetInfo(StudentSelect.SelectedIndex + 1);
                    //damn.
                    NicknameTextbox.Text = studentjson.Name;
                    RealnameTextbox.Text = studentjson.RealName;
                    DescTextbox.Text = studentjson.Info; //refuses to work I guess.
                    CrushTextbox.Text = studentjson.Crush.ToString(); //I am idiot.
                    GenderCombobox.SelectedIndex = utilityScript.ToInteger(studentjson.Gender);
                    AccessoryCombobox.SelectedIndex = utilityScript.ToInteger(studentjson.Accessory); //pulls the current accessory
                    HairCombobox.SelectedIndex = utilityScript.ToInteger(studentjson.Hairstyle);
                    ClassTextbox.Text = studentjson.Class.ToString();
                    SeatTextbox.Text = studentjson.Seat.ToString();
                    int strength = utilityScript.ToInteger(studentjson.Strength);
                    if(strength > 9)
                    {
                        StrengthCombobox.SelectedIndex = strength - 89;
                    }
                    else
                    {
                        StrengthCombobox.SelectedIndex = utilityScript.ToInteger(studentjson.Strength);
                    }
                    BustTextbox.Text = studentjson.BreastSize.ToString(); //eww. I was debating not allowing
                    //mods to this, decided to keep my prefrences out of the way. (fuck this setting btw)
                    //alex cant count from 0 to 100 appernetly. Now I have to do this bs.
                    //you may be asking, why dont I used the .Text method of these comboboxes?
                    //in short, it looks better when it shows the names of thigns, not just numbers.
                    int club = utilityScript.ToInteger(studentjson.Club);
                    if (club > 15) //check if the club is larger then the last known club
                    {
                        int clubvalue = club - 84;
                        ClubCombobox.SelectedIndex = clubvalue;
                        //perfect offset for the clubs
                    } else
                    {
                        ClubCombobox.SelectedIndex = club;
                    } //alex cant count, so I need to play intergalatic pinball to get this shit to work correctly.
                    int persona = utilityScript.ToInteger(studentjson.Persona);
                    if (persona == 99) //checks if the personsa is 99, if it is, set it as so.
                    {
                        PersonaCombobox.SelectedIndex = 18;
                    }
                    else
                    {
                        PersonaCombobox.SelectedIndex = persona;
                    }
                    SaveButton.Enabled = true;
                }
            }
            catch (Exception loaderror)
            {
                //error handling code, just shows and error before failing.
                utilityScript.WriteError(loaderror.ToString(), "Error");
                SaveButton.Enabled = true;
                warncorruoption = true;

            }
        }

        private void StudentConfig_Load(object sender, EventArgs e)
        {
            //changing this value causes insane lag for some reason.....
            //MaximizeBox = false;
            //prevents people from essentially causing the app to write null values to a student.
            SaveButton.Enabled = false;
        }

        private void ClubCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StrengthTextbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AccessoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            randomizerForm randomizerForm = new randomizerForm();
            randomizerForm.ShowDialog();
        }

        private void PersonaCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}