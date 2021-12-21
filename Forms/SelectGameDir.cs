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
    public partial class Open : Form
    {
        public Open()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                //string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Open Open = new Open();
            Open.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open Open = new Open();
            RegistryKey config = Registry.CurrentUser.CreateSubKey("SOFTWARE\\btelnyy\\YanSaveEdit");;
            try
            {
                string jsonpath = textBox1.Text + "YandereSimulator_Data\\StreamingAssets\\JSON\\";
                string jsonpath2020 = textBox1.Text + "YandereSimulator_Data\\StreamingAssets\\JSON\\Students.json";
                bool exists = utilityScript.FileExists(jsonpath2020);
                if (!exists)
                {
                    utilityScript.WriteError("Students.json was not found in " + jsonpath + ",make sure it exists.", "Error");
                    Application.Exit();

                }
                string jsonpath1980 = textBox1.Text + "YandereSimulator_Data\\StreamingAssets\\JSON\\Eighties.json";
                bool exists80 = utilityScript.FileExists(jsonpath1980);
                if (!exists)
                {
                    utilityScript.WriteError("Eighties.json was not found in " + jsonpath + ",make sure it exists.", "Error");
                    Application.Exit();

                }
                config.SetValue("gamePath", textBox1.Text);
                config.SetValue("jsonPath1980", jsonpath1980);
                config.SetValue("jsonPath2020", jsonpath2020);
                config.Close();
                utilityScript.WriteInfo("Configuration Set Succesfully with no errors.", "Success");
                Open.Close();
            }
            catch (Exception e1)
            {
                //returns error as string
                utilityScript.WriteError(e1.ToString(), "Error");
            }
        }
    }
}
