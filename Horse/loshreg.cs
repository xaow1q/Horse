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
    public partial class loshreg : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public loshreg()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Сотрудник WHERE Должность = 'Берейтор'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Клиент";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetInt32(7), record.GetString(8), RowState.ModifiedRow);

        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetInt32(11), RowState.ModifiedRow);

        }
        private void CreateColumns()
        {

            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("Пол", "Пол");
            dataGridView1.Columns.Add("ДатаР", "ДатаР");
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Занятость", "Занятость");
            dataGridView1.Columns.Add("ТабельныйНомер", "Табельный номер");
            dataGridView1.Columns.Add("Пароль", "Пароль");
            dataGridView1.Columns.Add("IsNew", String.Empty);

            dataGridView2.Columns.Add("Имя", "Имя");
            dataGridView2.Columns.Add("Фамилия", "Фамилия");
            dataGridView2.Columns.Add("Отчество", "Отчество");
            dataGridView2.Columns.Add("Пол", "Пол");
            dataGridView2.Columns.Add("ДатаР", "ДатаР");
            dataGridView2.Columns.Add("Категория", "Категория");
            dataGridView2.Columns.Add("Простой", "Простой");
            dataGridView2.Columns.Add("ИмяЛошади", "Имя лошади");
            dataGridView2.Columns.Add("Порода", "Порода");
            dataGridView2.Columns.Add("ДатаРожЛ", "Дата рождения лошади");
            dataGridView2.Columns.Add("ПолЛ", "Пол Лошади");
            dataGridView2.Columns.Add("Идентификатор", "Идентификатор");
            dataGridView2.Columns.Add("IsNew", String.Empty);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            
            if(textBox5.Text == null)
            {
                textBox5.Text = "Конноспортивный комплекс";
            }

            try
            {
                int percent1 = Convert.ToInt32(textBox6.Text);
                int percent2 = Convert.ToInt32(textBox8.Text);
                int percent3 = Convert.ToInt32(textBox10.Text);
                int percent = percent1 + percent2 + percent3;

                if (percent != 100)
                {
                    MessageBox.Show("Питание выбрано не корректно", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox6.Text = "";
                    this.textBox8.Text = "";
                    this.textBox10.Text = "";

                }

                var name = textBox1.Text;
                var poroda = textBox2.Text;
                var dataR = textBox3.Text;
                var pol = comboBox1.Text;
                var vlad = textBox5.Text;
                var den = textBox12.Text;
                var pit = comboBox3.Text;
                var kgvden = textBox7.Text;
                var ber = textBox4.Text;


               
                var addQuery = $"INSERT INTO Лошадь(Имя, Порода, ДатаР, Пол, Владелец, Денник, Питание, КгВДень, ПроцСух, ПроцСочн, ПроцКонц, Берейтор) VALUES ('{name}','{poroda}','{dataR}','{pol}','{vlad}','{den}','{pit}','{kgvden}','{percent1}','{percent2}','{percent3}','{ber}')";
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
            catch
            {
                MessageBox.Show("Выберите % питания", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dataBase.closeConnection();
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if(!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != '.' && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loshreg_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            RefreshDataGrid2(dataGridView2);
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                var name = row.Cells[0].Value.ToString();
                var fam = row.Cells[1].Value.ToString();
                var otch = row.Cells[2].Value.ToString();

                textBox4.Text = name + ' ' + fam + ' ' + otch;

                dataGridView1.Visible = false;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                var name = row.Cells[0].Value.ToString();
                var fam = row.Cells[1].Value.ToString();
                var otch = row.Cells[2].Value.ToString();

                textBox5.Text = name + ' ' + fam + ' ' + otch;

                dataGridView2.Visible = false;


            }
        }
    }
}
