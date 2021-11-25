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

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Open Open = new Open();
            Open.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //apply some cool config
        }
    }
}
