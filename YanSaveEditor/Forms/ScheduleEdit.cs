using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YanSimSaveEditor
{
    public partial class ScheduleEdit : Form
    {
        public ScheduleEdit()
        {
            InitializeComponent();
        }

        private void ScheduleEdit_Load(object sender, EventArgs e)
        {
            UtilityScript.WriteWarning("Using this function as of this version is not recommended! while no problems occur, you must have knowledge of Yandere Simulator in order to use this. ", "Warning");
            string student = UtilityScript.GetStudent();
            studentLabel.Text = "Current Student: " + student;
            student studentjson = JSONEdit.GetInfo(UtilityScript.ToInteger(student));
            string[] time = UtilityScript.SeperateIntoArray(studentjson.ScheduleTime, '_');
            string[] destination = UtilityScript.SeperateIntoArray(studentjson.ScheduleDestination, '_');
            string[] action = UtilityScript.SeperateIntoArray(studentjson.ScheduleAction, '_');
            object[] timetext = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            object[] desttext = { textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
            object[] actiontext = { textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30 };
            int timec = time.Count();
            int destc = destination.Count();
            int actionc = action.Count();
            int counter = 0;
            //for every textbox try to apply the text which we get from the json files.
            foreach (TextBox element in timetext)
            {
                try
                {
                    element.Text = time[counter];
                }
                catch (Exception ex)
                {
                    Log.Warning("error catch while setting textboxes in Schedule editor: " + ex.ToString());
                }
                counter++;
            }
            counter = 0;
            foreach (TextBox element in desttext)
            {
                try
                {
                    element.Text = destination[counter];
                }
                catch (Exception ex)
                {
                    Log.Warning("error catch while setting textboxes in Schedule editor: " + ex.ToString());
                }
                counter++;
            }
            counter = 0;
            foreach (TextBox element in actiontext)
            {
                try
                {
                    element.Text = action[counter];
                }
                catch (Exception ex)
                {
                    Log.Warning("error catch while setting textboxes in Schedule editor: " + ex.ToString());
                }
                counter++;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string student = UtilityScript.GetStudent();
            student studentjson = JSONEdit.GetInfo(UtilityScript.ToInteger(student));
            object[] timetext = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            object[] desttext = { textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
            object[] actiontext = { textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30 };
            string time = "";
            string destination = "";
            string action = "";
            foreach (TextBox element in timetext)
            {
                try
                {
                    time += element.Text + "_";
                }
                catch(Exception ex)
                {
                    Log.Warning("Error while exporting Schedule string: " + ex.ToString());
                }
            }
            time += time.Trim('_');
            foreach (TextBox element in desttext)
            {
                try
                {
                    destination += element.Text + "_";
                }
                catch (Exception ex)
                {
                    Log.Warning("Error while exporting Schedule string: " + ex.ToString());
                }
            }
            destination += destination.Trim('_');
            foreach (TextBox element in actiontext)
            {
                try
                {
                    action += element.Text + "_";
                }
                catch (Exception ex)
                {
                    Log.Warning("Error while exporting Schedule string: " + ex.ToString());
                }
            }
            action += action.Trim('_');
            studentjson.ScheduleTime = time;
            studentjson.ScheduleDestination = destination;
            studentjson.ScheduleAction = action;
            JSONEdit.WriteInfo(studentjson);
        }
    }
}
