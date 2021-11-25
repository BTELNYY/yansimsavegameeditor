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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Utility.CreateLog("Closing Application");
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utility.CreateLog("MainForm Loaded");
        }

        private void githublink_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //link to github open in default browser
        }

        private void Studentconfigbutton_Click(object sender, EventArgs e)
        {
            StudentConfig StudentConfig = new StudentConfig();
            MainForm MainForm = new MainForm();
            //what even is this bullshit?
            MainForm.Close();
            StudentConfig.ShowDialog();
        }

        private void GameconfigButton_Click(object sender, EventArgs e)
        {
            GameConfig GameConfig = new GameConfig();
            GameConfig.ShowDialog();
        }

        private void AdvancedconfigButton_Click(object sender, EventArgs e)
        {
            //waiting for loaf
        }

        private void ChangeGameDirButton_Click(object sender, EventArgs e)
        {
            //open the change dir dialog
            Open SelectGameDir = new Open();
            SelectGameDir.ShowDialog();
        }
    }
}
