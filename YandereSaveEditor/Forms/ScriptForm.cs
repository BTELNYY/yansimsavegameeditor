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

namespace YandereSaveEditor
{
    public partial class ScriptForm : Form
    {
        public ScriptForm()
        {
            InitializeComponent();
        }
        private static string? path;
        private void chooseFile_Click(object sender, EventArgs e)
        {
            path = Utility.OpenFileDialog(".\\", "txt files (*.txt)|*.txt|All files (*.*)|*.*");
            pathTextbox.Text = path;
        }

        private void ScriptForm_Load(object sender, EventArgs e)
        {
            string[] saves = { "1", "2", "3", "11", "12", "13" };
            foreach (string s in saves)
            {
                //checks for every save and sees if its "enabled"
                RegistryKey gamereg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\YandereDev\\YandereSimulator");
                string result = Utility.SelectString("ProfileCreated_" + s + "_", false);
                if (result != null)
                {
                    string value = RegEdit.returnValue(gamereg, result);
                    if (value == "1")
                    {
                        //adds the stuff to the combobox
                        profileCombo.Items.Add(s);
                        Log.Info("Detected and added profile " + s);
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    continue;
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            ScriptHandler.Script(path, profileCombo.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BTELNYY/yansimsavegameeditor/wiki/Scripting-Paramters-and-Usage");
        }
    }
}
