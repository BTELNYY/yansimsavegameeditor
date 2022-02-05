using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YanSimSaveEditor
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
                    element.Items.Add("0 - Dislikes");
                    element.Items.Add("1 - Nuetral");
                    element.Items.Add("2 - Likes");
                    string student = Globals.student;
                    string topicid = counter.ToString();
                    string value = JSONEdit.GetTopicValue(student, topicid);
                    element.SelectedIndex = int.Parse(value);
                    counter++;
                }
            }catch(Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), "Error");
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
