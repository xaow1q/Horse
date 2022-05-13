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
    public partial class koval : Form
    {
        public koval()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kovalrasp rasp = new kovalrasp();
            rasp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kovalzapis zapis = new kovalzapis();
            zapis.ShowDialog();
        }
    }
}
