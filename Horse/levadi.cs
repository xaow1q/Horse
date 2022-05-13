using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horse
{
    public partial class levadi : Form
    {
        public levadi()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            levadirasp rasp = new levadirasp();
            rasp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LevadiVnos vnos = new LevadiVnos();
            vnos.ShowDialog();
        }
    }
}
