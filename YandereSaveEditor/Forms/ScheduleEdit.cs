using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
#nullable disable
namespace YandereSaveEditor
{
    public partial class ScheduleEdit : Form
    {
        public ScheduleEdit()
        {
            InitializeComponent();
        }

        private void ScheduleEdit_Load(object sender, EventArgs e)
        {
            if (sender != null && e != null)
            {
                Utility.WriteWarning("Using this function as of this version is not recommended! while no problems occur, you must have knowledge of Yandere Simulator in order to use this. ", "Warning");
            }
            string student = Utility.GetStudent();
            studentLabel.Text = "Current Student: " + student;
            student studentjson = JSONEdit.GetInfo(Utility.ToInteger(student));
            string[] time = Utility.SeperateIntoArray(studentjson.ScheduleTime, '_');
            string[] destination = Utility.SeperateIntoArray(studentjson.ScheduleDestination, '_');
            string[] action = Utility.SeperateIntoArray(studentjson.ScheduleAction, '_');
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
            timeFText.Text = studentjson.ScheduleTime;
            destFText.Text = studentjson.ScheduleDestination;
            actionFText.Text = studentjson.ScheduleAction;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string student = Utility.GetStudent();
            student studentjson = JSONEdit.GetInfo(Utility.ToInteger(student));
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
            timeFText.Text = studentjson.ScheduleTime;
            destFText.Text = studentjson.ScheduleDestination;
            actionFText.Text = studentjson.ScheduleAction;
            Utility.WriteInfo("All data written successfully", "Done");
            Log.Info("Written all schedule data successfully unless otherwise stated above");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            string student = Utility.GetStudent();
            student studentjson = JSONEdit.GetInfo(Utility.ToInteger(student));
            studentjson.ScheduleTime = timeFText.Text;
            studentjson.ScheduleDestination = destFText.Text;
            studentjson.ScheduleAction = actionFText.Text;
            JSONEdit.WriteInfo(studentjson);
            ScheduleEdit_Load(null, null);
        }
    }
}
