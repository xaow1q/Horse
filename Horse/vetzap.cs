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
    public partial class vetzap : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public vetzap()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var fio = textBox4.Text;
            var loshad = textBox5.Text;
            var data = dateTimePicker1.Text;
            var vremya = dateTimePicker2.Text;
            var vet = textBox3.Text;

            var addQuery = $"INSERT INTO Ветеринар(ФИОВ, Лошадь, Дата, Время, Ветеринар) VALUES ('{fio}','{loshad}','{data}','{vremya}','{vet}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());

            command.ExecuteNonQuery();
            MessageBox.Show("Успех");

            dataBase.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
        }

        private void vetzap_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy.mm.dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm:ss";
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            CreateColumns2();
            RefreshDataGrid2(dataGridView2);
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Владелец", "Владелец");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("Имя", "Имя");
            dataGridView2.Columns.Add("Фамилия", "Фамилия");
            dataGridView2.Columns.Add("Отчество", "Отчество");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), RowState.ModifiedRow);
        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Имя, Владелец FROM Лошадь";
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

            string query = $"SELECT Имя, Фамилия, Отчество FROM Сотрудник WHERE Должность = 'Ветеринар'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                var name = row.Cells[0].Value.ToString();
                var vlad = row.Cells[1].Value.ToString();

                textBox4.Text = name;
                textBox5.Text = vlad;

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
                var otch = row.Cells[1].Value.ToString();

                textBox3.Text = name + fam + otch;

                dataGridView2.Visible = false;
            }
        }
    }
}
