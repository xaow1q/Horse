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
    public partial class Manej : Form
    {
        public Manej()
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
            Manejraspis rasp = new Manejraspis();
            rasp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManejVnestiTren vnesti = new ManejVnestiTren();
            vnesti.ShowDialog();
        }
    }
}
