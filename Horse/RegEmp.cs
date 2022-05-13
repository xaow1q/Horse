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
    public partial class RegEmp : Form
    {
        DataBase dataBase = new DataBase();
        public RegEmp()
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

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

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = textBox1.Text;
            var fam = textBox2.Text;
            var otch = textBox3.Text;
            var data = textBox4.Text;
            var dolj = comboBox1.Text;
            var zan = comboBox2.Text;
            var tabn = textBox7.Text;
            var parol = textBox8.Text;
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                var pol = checkBox1.Text;
                var addQuery = $"INSERT INTO Сотрудник(Имя, Фамилия, Отчество, Пол, ДатаР, Должность, Занятость, ТабельныйНомер, Пароль) VALUES ('{name}','{fam}','{otch}','{pol}','{data}','{dolj}','{zan}','{tabn}','{parol}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Сотрудник с таким табельным номером уже существует", "Ошибка", MessageBoxButtons.OK);
                }
               
            }
            if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                var pol = checkBox2.Text;
                var addQuery = $"INSERT INTO Сотрудник(Имя, Фамилия, Отчество, Пол, ДатаР, Должность, Занятость, ТабельныйНомер, Пароль) VALUES ('{name}','{fam}','{otch}','{pol}','{data}','{dolj}','{zan}','{tabn}','{parol}' )";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Сотрудник с таким табельным номером уже существует", "Ошибка", MessageBoxButtons.OK);
                }
            }


        }
    }
}
