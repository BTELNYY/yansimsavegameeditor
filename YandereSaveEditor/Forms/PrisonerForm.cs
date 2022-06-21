using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YandereSaveEditor
{
    public partial class PrisonerForm : Form
    {
        public PrisonerForm()
        {
            InitializeComponent();
        }

        private void PrisonerForm_Load(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profilecombined = "Profile_" + Utility.GetProfile();
            //awful way to code, but I will optimize the select string method later
            //prisoner 1 fullname (of the value)
            try
            {
                string pris1fn = Utility.SelectString(profilecombined + "_Prisoner1", true);
                string pris2fn = Utility.SelectString(profilecombined + "_Prisoner2", true);
                string pris3fn = Utility.SelectString(profilecombined + "_Prisoner3", true);
                string pris4fn = Utility.SelectString(profilecombined + "_Prisoner4", true);
                string pris5fn = Utility.SelectString(profilecombined + "_Prisoner5", true);
                string pris6fn = Utility.SelectString(profilecombined + "_Prisoner6", true);
                string pris7fn = Utility.SelectString(profilecombined + "_Prisoner7", true);
                string pris8fn = Utility.SelectString(profilecombined + "_Prisoner8", true);
                string pris9fn = Utility.SelectString(profilecombined + "_Prisoner9", true);
                string pris10fn = Utility.SelectString(profilecombined + "_Prisoner10", true);
                //prisoner 1 value
                string pris1v = RegEdit.returnValue(gamereg, pris1fn);
                string pris2v = RegEdit.returnValue(gamereg, pris2fn);
                string pris3v = RegEdit.returnValue(gamereg, pris3fn);
                string pris4v = RegEdit.returnValue(gamereg, pris4fn);
                string pris5v = RegEdit.returnValue(gamereg, pris5fn);
                string pris6v = RegEdit.returnValue(gamereg, pris6fn);
                string pris7v = RegEdit.returnValue(gamereg, pris7fn);
                string pris8v = RegEdit.returnValue(gamereg, pris8fn);
                string pris9v = RegEdit.returnValue(gamereg, pris9fn);
                string pris10v = RegEdit.returnValue(gamereg, pris10fn);
                comboBox1.SelectedIndex = int.Parse(pris1v);
                comboBox2.SelectedIndex = int.Parse(pris2v);
                comboBox3.SelectedIndex = int.Parse(pris3v);
                comboBox4.SelectedIndex = int.Parse(pris4v);
                comboBox5.SelectedIndex = int.Parse(pris5v);
                comboBox6.SelectedIndex = int.Parse(pris6v);
                comboBox7.SelectedIndex = int.Parse(pris7v);
                comboBox8.SelectedIndex = int.Parse(pris8v);
                comboBox9.SelectedIndex = int.Parse(pris9v);
                comboBox10.SelectedIndex = int.Parse(pris10v);

            }
            catch (Exception ex)
            {
                Utility.WriteError("Error loading prisoner config: \n \n" + ex.ToString(), "Error: " + ex.Message);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profilecombined = "Profile_" + Utility.GetProfile();
            try
            {
                string pris1fn = Utility.SelectString(profilecombined + "_Prisoner1", true);
                string pris2fn = Utility.SelectString(profilecombined + "_Prisoner2", true);
                string pris3fn = Utility.SelectString(profilecombined + "_Prisoner3", true);
                string pris4fn = Utility.SelectString(profilecombined + "_Prisoner4", true);
                string pris5fn = Utility.SelectString(profilecombined + "_Prisoner5", true);
                string pris6fn = Utility.SelectString(profilecombined + "_Prisoner6", true);
                string pris7fn = Utility.SelectString(profilecombined + "_Prisoner7", true);
                string pris8fn = Utility.SelectString(profilecombined + "_Prisoner8", true);
                string pris9fn = Utility.SelectString(profilecombined + "_Prisoner9", true);
                string pris10fn = Utility.SelectString(profilecombined + "_Prisoner10", true);
                string prisTotal = Utility.SelectString(profilecombined + "_Prisoners", true);
                RegEdit.editValue(gamereg, comboBox1.SelectedIndex, pris1fn);
                RegEdit.editValue(gamereg, comboBox2.SelectedIndex, pris2fn);
                RegEdit.editValue(gamereg, comboBox3.SelectedIndex, pris3fn);
                RegEdit.editValue(gamereg, comboBox4.SelectedIndex, pris4fn);
                RegEdit.editValue(gamereg, comboBox5.SelectedIndex, pris5fn);
                RegEdit.editValue(gamereg, comboBox6.SelectedIndex, pris6fn);
                RegEdit.editValue(gamereg, comboBox7.SelectedIndex, pris7fn);
                RegEdit.editValue(gamereg, comboBox8.SelectedIndex, pris8fn);
                RegEdit.editValue(gamereg, comboBox9.SelectedIndex, pris9fn);
                RegEdit.editValue(gamereg, comboBox10.SelectedIndex, pris10fn);
                ComboBox[] boxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10 };
                int[] prisonerids = new int[10];
                int total = 0;
                foreach (ComboBox box in boxes)
                {
                    prisonerids[total] = box.SelectedIndex;
                    if (box.SelectedIndex > 0)
                    {
                        total++;
                    }
                }
                RegEdit.editValue(gamereg, total, prisTotal);
                if (UpdatePrisonerNotAtSchool.Checked)
                {
                    foreach(int prisoner in prisonerids)
                    {
                        string knkey = Utility.SelectString(profilecombined + "_StudentKidnapped_" + prisoner, true);
                        RegEdit.editValue(gamereg, 1, knkey);
                    }
                }
                Utility.WriteInfo("Prisoner config saved!", "Done");
                PrisonerForm_Load(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Utility.WriteError("Error applying prisoner config: \n \n" + ex.ToString(), "Error: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReleaseEveryoneButton_Click(object sender, EventArgs e)
        {
            RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
            string profilecombined = "Profile_" + Utility.GetProfile();
            string pris1fn = Utility.SelectString(profilecombined + "_Prisoner1", true);
            string pris2fn = Utility.SelectString(profilecombined + "_Prisoner2", true);
            string pris3fn = Utility.SelectString(profilecombined + "_Prisoner3", true);
            string pris4fn = Utility.SelectString(profilecombined + "_Prisoner4", true);
            string pris5fn = Utility.SelectString(profilecombined + "_Prisoner5", true);
            string pris6fn = Utility.SelectString(profilecombined + "_Prisoner6", true);
            string pris7fn = Utility.SelectString(profilecombined + "_Prisoner7", true);
            string pris8fn = Utility.SelectString(profilecombined + "_Prisoner8", true);
            string pris9fn = Utility.SelectString(profilecombined + "_Prisoner9", true);
            string pris10fn = Utility.SelectString(profilecombined + "_Prisoner10", true);
            string prisTotal = Utility.SelectString(profilecombined + "_Prisoners", true);
            ComboBox[] boxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10 };
            int[] prisonerids = new int[10];
            int total = 0;
            foreach (ComboBox box in boxes)
            {
                prisonerids[total] = box.SelectedIndex;
                if (box.SelectedIndex > 0)
                {
                    total++;
                }
                box.SelectedIndex = 0;
            }
            foreach (int prisoner in prisonerids)
            {
                string knkey = Utility.SelectString(profilecombined + "_StudentKidnapped_" + prisoner, true);
                RegEdit.editValue(gamereg, 0, knkey);
            }
            RegEdit.editValue(gamereg, comboBox1.SelectedIndex, pris1fn);
            RegEdit.editValue(gamereg, comboBox2.SelectedIndex, pris2fn);
            RegEdit.editValue(gamereg, comboBox3.SelectedIndex, pris3fn);
            RegEdit.editValue(gamereg, comboBox4.SelectedIndex, pris4fn);
            RegEdit.editValue(gamereg, comboBox5.SelectedIndex, pris5fn);
            RegEdit.editValue(gamereg, comboBox6.SelectedIndex, pris6fn);
            RegEdit.editValue(gamereg, comboBox7.SelectedIndex, pris7fn);
            RegEdit.editValue(gamereg, comboBox8.SelectedIndex, pris8fn);
            RegEdit.editValue(gamereg, comboBox9.SelectedIndex, pris9fn);
            RegEdit.editValue(gamereg, comboBox10.SelectedIndex, pris10fn);
            RegEdit.editValue(gamereg, 0, prisTotal);
            Utility.WriteInfo("Released Everyone from captivity", "Done");
            PrisonerForm_Load(this, new EventArgs());
        }
    }
}
