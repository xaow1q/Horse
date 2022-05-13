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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegEmp reg = new RegEmp();
            reg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegClient client = new RegClient();
            client.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otdelenie otdel = new Otdelenie();
            otdel.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admindannieclienta a = new admindannieclienta();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admindanniesotr a = new admindanniesotr();
            a.ShowDialog();
        }
    }
}
