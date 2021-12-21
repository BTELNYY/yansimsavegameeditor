using System;
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
        public StudentConfig()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //define the things we need
                string profile = Utility.getProfile();
                string student = StudentSelect.Text;
                int studentint = Utility.ToInteger(student);
                student studentjson = JSONEdit.GetInfo(studentint);
                student studenjsonread = JSONEdit.GetInfo(studentint);
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string studentdead = Utility.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true);
                string studentrep = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                string kidnapped = Utility.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
                string photo = Utility.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                string dying = Utility.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
                string friend = Utility.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                //lets get ready to rumble!
                RegEdit.editValue(gamereg, Utility.ToInteger(ReputationTextbox.Text), studentrep);
                RegEdit.editValue(gamereg, Utility.ConvertBool(DeathCheckbox.Checked), studentdead);
                RegEdit.editValue(gamereg, Utility.ConvertBool(KidnapChekbox.Checked), kidnapped);
                RegEdit.editValue(gamereg, Utility.ConvertBool(PhotographedCheckbox.Checked), photo);
                RegEdit.editValue(gamereg, Utility.ConvertBool(DyingCheckbox.Checked), dying);
                RegEdit.editValue(gamereg, Utility.ConvertBool(FriendCheckbox.Checked), friend);
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
                Utility.WriteInfo("All Data Written Successfully", "Done");
                ApplyButton_Click(null, null);
            }
            catch (Exception writeerror)
            {
                Utility.WriteError(writeerror.ToString(), "Error");
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
                    idTextbox.Text = student;
                    bool allowpfp;
                    int studentint = Utility.ToInteger(student);
                    int profileint = Utility.ToInteger(profile);
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
                    string studentdead = Utility.SelectString("Profile_" + profile + "_StudentDead_" + student + "_", true); //the _ is needed so my method doesnt shit itself.
                    //above comment fixed, I added a trim statement.
                    string studentdeadvalue = RegEdit.returnValue(gamereg, studentdead);
                    //ok so, what the fuck is this code?
                    DeathCheckbox.Checked = Utility.ToBool(Utility.ToInteger(studentdeadvalue)); 
                    //kidnapped?
                    string kidnapped = Utility.SelectString("Profile_" + profile + "_StudentKidnapped_" + student + "_", true);
                    string kidanppedvalue = RegEdit.returnValue(gamereg, kidnapped);
                    KidnapChekbox.Checked = Utility.ToBool(Utility.ToInteger(kidanppedvalue));
                    string photo = Utility.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                    string photovalue = RegEdit.returnValue(gamereg, photo);
                    PhotographedCheckbox.Checked = Utility.ToBool(Utility.ToInteger(photovalue));
                    string dying = Utility.SelectString("Profile_" + profile + "_StudentDying_" + student + "_", true);
                    string dyingvalue = RegEdit.returnValue(gamereg, dying);
                    DeathCheckbox.Checked = Utility.ToBool(Utility.ToInteger(dyingvalue));
                    string friend = Utility.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                    string friendvalue = RegEdit.returnValue(gamereg, friend);
                    FriendCheckbox.Checked = Utility.ToBool(Utility.ToInteger(friendvalue));
                    string panty = Utility.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
                    PantyshotCheckbox.Checked = Utility.ToBool(Utility.ToInteger(RegEdit.returnValue(gamereg, panty))); //jesus
                    string reputation = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                    ReputationTextbox.Text = RegEdit.returnValue(gamereg, reputation);
                    student studentjson = JSONEdit.GetInfo(StudentSelect.SelectedIndex + 1);
                    //damn.
                    NicknameTextbox.Text = studentjson.Name;
                    RealnameTextbox.Text = studentjson.RealName;
                    DescTextbox.Text = studentjson.Info; //refuses to work I guess.
                    CrushTextbox.Text = studentjson.Crush.ToString(); //I am idiot.
                    GenderCombobox.SelectedIndex = Utility.ToInteger(studentjson.Gender);
                    AccessoryCombobox.SelectedIndex = Utility.ToInteger(studentjson.Accessory); //pulls the current accessory
                    HairCombobox.SelectedIndex = Utility.ToInteger(studentjson.Hairstyle);
                    ClassTextbox.Text = studentjson.Class.ToString();
                    SeatTextbox.Text = studentjson.Seat.ToString();
                    int strength = Utility.ToInteger(studentjson.Strength);
                    if(strength > 9)
                    {
                        StrengthCombobox.SelectedIndex = strength - 89;
                    }
                    else
                    {
                        StrengthCombobox.SelectedIndex = Utility.ToInteger(studentjson.Strength);
                    }
                    BustTextbox.Text = studentjson.BreastSize.ToString(); //eww. I was debating not allowing
                    //mods to this, decided to keep my prefrences out of the way. (fuck this setting btw)
                    //alex cant count from 0 to 100 appernetly. Now I have to do this bs.
                    //you may be asking, why dont I used the .Text method of these comboboxes?
                    //in short, it looks better when it shows the names of thigns, not just numbers.
                    int club = Utility.ToInteger(studentjson.Club);
                    if (club > 14) //check if the club is larger then the last known club
                    {
                        int clubvalue = club - 84;
                        ClubCombobox.SelectedIndex = clubvalue;
                        //perfect offset for the clubs
                    } else
                    {
                        ClubCombobox.SelectedIndex = club;
                    } //alex cant count, so I need to play intergalatic pinball to get this shit to work correctly.
                    int persona = Utility.ToInteger(studentjson.Persona);
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
                Utility.WriteError(loaderror.ToString(), "Error");
                return;
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
            //works with the random function to fill values with randomness......
            //this affects all values except the death checkbox, name, realname, desc, class and seat
            int[] students = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 }; //HOLY FUCKING JESUS KILL ME NOW
            int[] clubs = { 0, 1, 2, 3, 4, 5, 6, 7, 9, 9, 10, 11, 12, 13, 14, 99, 100, 101, 102 };
            int[] personas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 99 };
            int[] strength = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 99 };
            string profile = Utility.getProfile();
            waitForForm waitForForm = new waitForForm();
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            DialogResult result;
            result = MessageBox.Show("Randomize all students? This action cannot be undone without file editing! \n Do not terminate until all clear message. (unless you like corruption)", "Randomize all",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (Utility.ToInteger(profile) > 3)
                    {
                        File.Copy(Utility.GetJSON(), "Eighties1.json", true);
                    }
                    else
                    {
                        File.Copy(Utility.GetJSON(), "Students1.json", true);
                    }
                    foreach (int student in students)
                    {
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "None");
                        student studentjson = JSONEdit.GetInfo(student);
                        string studentrep = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);
                        string photo = Utility.SelectString("Profile_" + profile + "_StudentPhotographed_" + student + "_", true);
                        string friend = Utility.SelectString("Profile_" + profile + "_StudentFriend_" + student + "_", true);
                        string panty = Utility.SelectString("Profile_" + profile + "_PantyShot_" + student + "_", true);
                        string reputation = Utility.SelectString("Profile_" + profile + "_StudentReputation_" + student + "_", true);

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), reputation);
                        RegEdit.editValue(gamereg, Utility.getRandomInt(-100, 100), reputation);

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), photo);
                        RegEdit.editValue(gamereg, Utility.getRandomInt(0, 3), photo);
                        
                        //Utility.updateWaitForNotification("Student: " + student.ToString(), friend);
                        RegEdit.editValue(gamereg, Utility.getRandomInt(0, 3), friend);

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), panty);
                        RegEdit.editValue(gamereg, Utility.getRandomInt(0, 3), panty);

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "BreastSize");
                        studentjson.BreastSize = Utility.getRandomDouble(0, 2, 0, 9).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Accessory");
                        studentjson.Accessory = Utility.getRandomInt(0, 15).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Club");
                        studentjson.Club = clubs.GetValue(Utility.getRandomInt(0, 19)).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Crush");
                        studentjson.Crush = Utility.getRandomInt(0, 101).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Hairstyle");
                        studentjson.Hairstyle = Utility.getRandomInt(0, 201).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Persona");
                        studentjson.Persona = personas.GetValue(Utility.getRandomInt(1, 18)).ToString();

                        //Utility.updateWaitForNotification("Student: " + student.ToString(), "Strength");
                        studentjson.Strength = strength.GetValue(Utility.getRandomInt(0, 10)).ToString();
                        JSONEdit.WriteInfo(studentjson);
                    }
                    //hide, close it and dispose of the form as we no longer need it.
                    Utility.closeWaitForNotification();
                    Utility.WriteInfo("Finished, if you wish to go back, delete Students.json within the normal JSON folder and rename Students1.json to Students.json, after this, copy this new file to your JSON folder. this will restore all previous data for the students. Note that profile data cannot be reverted.", "Done");
                }
                catch (Exception ex)
                {
                    Utility.WriteError(ex.ToString(), "Error");
                }
            }
            else
            {
                //the question answer was no, therefore return back to the student config screen and do nothing about it.
                Utility.WriteInfo("Operation Aborted", "Done.");
            }
        }
    }
}
