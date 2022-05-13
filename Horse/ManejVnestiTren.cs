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
    public partial class ManejVnestiTren : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public ManejVnestiTren()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManejVnestiTren_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy mm dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm:ss";

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            CreateColumns();
            RefreshDataGrid(dataGridView1);
            CreateColumns2();
            RefreshDataGrid2(dataGridView2);
            CreateColumns3();
            RefreshDataGrid3(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

           
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Имя, Фамилия, Отчество FROM Клиент";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

            dataBase.closeConnection();
        }

        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("Имя", "Имя");
            dataGridView2.Columns.Add("Фамилия", "Фамилия");
            dataGridView2.Columns.Add("Отчество", "Отчество");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), RowState.ModifiedRow);
        }

        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Имя, Фамилия, Отчество FROM Сотрудник WHERE Должность = 'Берейтор'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();

            dataBase.closeConnection();
        }

        private void CreateColumns3()
        {
            dataGridView3.Columns.Add("Имя", "Имя");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow3(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), RowState.ModifiedRow);
        }

        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Имя FROM Лошадь";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow3(dgw, reader);
            }
            reader.Close();

            dataBase.closeConnection();
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

                textBox1.Text = name + fam + otch;

                dataGridView1.Visible = false;


            }
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

                textBox2.Text = name + fam + otch;

                dataGridView2.Visible = false;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];

                var name = row.Cells[0].Value.ToString();

                textBox3.Text = name;

                dataGridView3.Visible = false;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
          
                var kli = textBox1.Text;
                var ber = textBox2.Text;
                var dis = comboBox3.Text;
                var data = dateTimePicker1.Text;
                var vremya = dateTimePicker2.Text;
                var loshad = textBox3.Text;

                var addQuery = $"INSERT INTO Тренировка(ФИОКли, ФИОБер, Дисциплина, Дата, Время, Лошадь) VALUES ('{kli}','{ber}','{dis}','{data}','{vremya}','{loshad}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);
                
                

            dataBase.closeConnection();
        }
    }
}
