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
    public partial class LevadiVnos : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public LevadiVnos()
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
            dataBase.openConnection();

            var loshad = textBox1.Text;
            int nomer = Convert.ToInt32(comboBox1.Text);
            var data = dateTimePicker1.Text;
            var vremya = dateTimePicker2.Text;

            var addQuery = $"INSERT INTO Левады(Лошадь, Дата, Время, НомерЛевадЫ) VALUES ('{loshad}','{data}','{vremya}','{nomer}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());

           
                command.ExecuteNonQuery();
                MessageBox.Show("Успех");

            dataBase.closeConnection();
        }

        private void LevadiVnos_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy mm dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm:ss";

            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Имя FROM Лошадь";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                var name = row.Cells[0].Value.ToString();

                textBox1.Text = name;

                dataGridView1.Visible = false;


            }
        }
    }
}
