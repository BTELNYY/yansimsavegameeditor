using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace YanSimSaveEditor.Forms
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            string url = "https://btelnyy.github.io/yansimsavegameeditor/Website/credits.html";
            WebClient client = new WebClient();
            string credits = client.DownloadString(url);
            creditsTextBox.Text = credits;
        }
    }
}
