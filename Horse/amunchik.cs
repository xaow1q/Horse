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
    public partial class amunchik : Form
    {
        public amunchik()
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
            ammuvnesti vnes = new ammuvnesti();
            vnes.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ammudan dan = new ammudan();
            dan.ShowDialog();
        }
    }
}
