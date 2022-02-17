using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#nullable disable
namespace YandereSaveEditor
{
    public partial class TopicEditor : Form
    {
        public TopicEditor()
        {
            InitializeComponent();
        }

        private void TopicEditor_Load(object sender, EventArgs e)
        {
            try
            {
                object[] comboboxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20, comboBox21, comboBox22, comboBox23, comboBox24, comboBox25 };
                int counter = 1;
                foreach (ComboBox element in comboboxes)
                {
                    //I am too lazy to add these values in each combobox, so Ill do it on execute
                    if (!element.Items.Contains("0 - Dislikes"))
                        element.Items.Add("0 - Dislikes");
                    if (!element.Items.Contains("1 - Nuetral"))
                        element.Items.Add("1 - Nuetral");
                    if (!element.Items.Contains("2 - Likes"))
                        element.Items.Add("2 - Likes");
                    string student = Globals.student;
                    string topicid = counter.ToString();
                    //while this method should not be used, I am using it cuz it makes it really easy to get valid data from the JSON
                    string value = JSONEdit.GetTopicValue(student, topicid);
                    element.SelectedIndex = int.Parse(value);
                    counter++;
                }
            }catch(Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), "Error");
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                topic topic = JSONEdit.GetTopic(Convert.ToInt32(Globals.student));
                //I am sure there is a better way to code this, I have tried a while and foreach loop but they do not seem to work.
                topic.one = comboBox1.SelectedIndex.ToString();
                topic.two = comboBox2.SelectedIndex.ToString();
                topic.three = comboBox3.SelectedIndex.ToString();
                topic.four = comboBox4.SelectedIndex.ToString();
                topic.five = comboBox5.SelectedIndex.ToString();
                topic.six = comboBox6.SelectedIndex.ToString();
                topic.seven = comboBox7.SelectedIndex.ToString();
                topic.eight = comboBox8.SelectedIndex.ToString();
                topic.nine = comboBox9.SelectedIndex.ToString();
                topic.ten = comboBox10.SelectedIndex.ToString();
                topic.eleven = comboBox11.SelectedIndex.ToString();
                topic.twelve = comboBox12.SelectedIndex.ToString();
                topic.thirteen = comboBox13.SelectedIndex.ToString();
                topic.fourteen = comboBox14.SelectedIndex.ToString();
                topic.fifteen = comboBox15.SelectedIndex.ToString();
                topic.sixteen = comboBox16.SelectedIndex.ToString();
                topic.seventeen = comboBox17.SelectedIndex.ToString();
                topic.eighteen = comboBox18.SelectedIndex.ToString();
                topic.nineteen = comboBox19.SelectedIndex.ToString();
                topic.twenty = comboBox20.SelectedIndex.ToString();
                topic.twentyone = comboBox21.SelectedIndex.ToString();
                topic.twentytwo = comboBox22.SelectedIndex.ToString();
                topic.twentythree = comboBox23.SelectedIndex.ToString();
                topic.twentyfour = comboBox24.SelectedIndex.ToString();
                topic.twentyfive = comboBox25.SelectedIndex.ToString();
                JSONEdit.SetTopic(topic);
                TopicEditor_Load(null, null);
                UtilityScript.WriteInfo("Finished writing JSON data", "Done");
            }
            catch (Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), ex.Message);
            }
        }
    }
}
