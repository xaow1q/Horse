using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Horse
{
    public partial class bazabron : Form
    {
        DataBase dataBase = new DataBase();
        public bazabron()
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
            int days = (dateTimePicker2.Value - dateTimePicker1.Value).Days;
            textBox6.Text = Convert.ToString(days);

            var fiokli = textBox1.Text;
            var kolV = textBox2.Text;
            var kolD = textBox3.Text;
            var dataZ = dateTimePicker1.Text;
            var dataV = dateTimePicker2.Text;
            var nomera = textBox7.Text;
            var phone = textBox8.Text;
            var dop = textBox9.Text;
            var dni = textBox6.Text;

            dataBase.openConnection();

            if(checkBox1.Checked == true)
            {
                var status = checkBox1.Text;
                var query = $"INSERT INTO БазаБронь(ФИОК, КолВз, КолДет, ДатаЗ, ДатаВ, КолДней, НомерА, МобНКлиента, ДопПожелания, Статус) VALUES ('{fiokli}','{kolV}','{kolD}','{dataZ}','{dataV}','{dni}','{nomera}','{phone}','{dop}','{status}')";
                var com = new SqlCommand(query, dataBase.getConnection());

                com.ExecuteNonQuery();
                MessageBox.Show("Успех!");
            }
            if(checkBox2.Checked == true)
            {
                var status = checkBox2.Text;
                var query = $"INSERT INTO БазаБронь(ФИОК, КолВз, КолДет, ДатаЗ, ДатаВ, КолДней, НомерА, МобНКлиента, ДопПожелания, Статус) VALUES ('{fiokli}','{kolV}','{kolD}','{dataZ}','{dataV}','{dni}','{nomera}','{phone}','{dop}','{status}')";
                var com = new SqlCommand(query, dataBase.getConnection());

                com.ExecuteNonQuery();
                MessageBox.Show("Успех!");
            }
           

            dataBase.closeConnection();
        }

        private void bazabron_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy:MM:dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy:MM:dd";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                checkBox2.Visible = false;
            }
            if(checkBox1.Checked == false)
            {
                checkBox2.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Visible = false;
            }
            if (checkBox2.Checked == false)
            {
                checkBox1.Visible = true;
            }
        }
    }
}
