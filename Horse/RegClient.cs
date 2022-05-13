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
    public partial class RegClient : Form
    {
        DataBase dataBase = new DataBase();
        public RegClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Visible = false;
            }
            if (checkBox1.Checked == false)
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Visible = false;
            }
            if (checkBox4.Checked == false)
            {
                checkBox3.Visible = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox4.Visible = false;
            }
            if (checkBox3.Checked == false)
            {
                checkBox4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = textBox1.Text;
            var fam = textBox2.Text;
            var otch = textBox3.Text;
            var datar = textBox4.Text;
            var kategor = comboBox1.Text;
            var namel = textBox5.Text;
            var poroda = textBox7.Text;
            var datarl = textBox6.Text;
            var poll = comboBox2.Text;
            var id = textBox9.Text;


            if (checkBox1.Checked == true && checkBox4.Checked == true)
            {
                var pol = checkBox1.Text;
                var prost = checkBox4.Text;
                var addQuery = $"INSERT INTO Клиент(Имя, Фамилия, Отчество, Пол, ДатаР, Категория, Простой, ИмяЛошади, Порода, ДатаРожЛ, ПолЛ, Идентификатор) VALUES ('{name}','{fam}','{otch}','{pol}','{datar}','{kategor}','{prost}','{namel}','{poroda}','{datarl}', '{poll}','{id}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                //try
                //{
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                //}
                //catch
                //{
                    //MessageBox.Show("Клиент с таким идентификатором уже существует", "Ошибка", MessageBoxButtons.OK);
                //}

            }

            if (checkBox1.Checked == true && checkBox3.Checked == true)
            {
                var pol = checkBox1.Text;
                var prost = checkBox3.Text;
                var addQuery = $"INSERT INTO Клиент(Имя, Фамилия, Отчество, Пол, ДатаР, Категория, Простой, ИмяЛошади, Порода, ДатаРожЛ, ПолЛ, Идентификатор) VALUES ('{name}','{fam}','{otch}','{pol}','{datar}','{kategor}','{prost}','{namel}','{poroda}','{datarl}', '{poll}','{id}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Клиент с таким идентификатором уже существует", "Ошибка", MessageBoxButtons.OK);
                }

            }

            if (checkBox2.Checked == true && checkBox4.Checked == true)
            {
                var pol = checkBox2.Text;
                var prost = checkBox4.Text;
                var addQuery = $"INSERT INTO Клиент(Имя, Фамилия, Отчество, Пол, ДатаР, Категория, Простой, ИмяЛошади, Порода, ДатаРожЛ, ПолЛ, Идентификатор) VALUES ('{name}','{fam}','{otch}','{pol}','{datar}','{kategor}','{prost}','{namel}','{poroda}','{datarl}', '{poll}','{id}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Клиент с таким идентификатором уже существует", "Ошибка", MessageBoxButtons.OK);
                }

            }

            if (checkBox2.Checked == true && checkBox3.Checked == true)
            {
                var pol = checkBox1.Text;
                var prost = checkBox3.Text;
                var addQuery = $"INSERT INTO Клиент(Имя, Фамилия, Отчество, Пол, ДатаР, Категория, Простой, ИмяЛошади, Порода, ДатаРожЛ, ПолЛ, Идентификатор) VALUES ('{name}','{fam}','{otch}','{pol}','{datar}','{kategor}','{prost}','{namel}','{poroda}','{datarl}', '{poll}','{id}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Клиент с таким идентификатором уже существует", "Ошибка", MessageBoxButtons.OK);
                }

            }

            dataBase.closeConnection();
        }
    }
}
