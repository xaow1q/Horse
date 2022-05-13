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
    public partial class BazaOtd : Form
    {
        public BazaOtd()
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
            bazabron bron = new bazabron();
            bron.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bazarasp rasp = new bazarasp();
            rasp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bazadanonomer nomer = new bazadanonomer();
            nomer.ShowDialog();
        }
    }
}
