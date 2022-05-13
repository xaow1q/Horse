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
    public partial class Konush : Form
    {
        public Konush()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Konush_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loshreg reg = new loshreg();
            reg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dennik den = new dennik();
            den.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loshdannie losh = new loshdannie();
            losh.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(DataBank.Dolj != "Администратор" && DataBank.Dolj != "Конюх" && DataBank.Dolj != "Берейтор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                uborkadannie dan = new uborkadannie();
                dan.ShowDialog();
            }         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
