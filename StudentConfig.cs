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
            string path = @".\YandereSimulator_Data\StreamingAssets\Portraits\";
            Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
            string file = path + "Student_" + StudentSelect.SelectedItem + ".png";
            Portrait.Image = Image.FromFile(file);
        }

        private void StudentConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
