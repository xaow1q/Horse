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
    public partial class ammuvnesti : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public ammuvnesti()
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
            if (textBox2.Text == "")
            {
                textBox2.Text = "Конноспортивный комплекс";
            }
            var fio = textBox2.Text;
            var vida = comboBox2.Text;
            var dis = comboBox3.Text;
            var datap = dateTimePicker1.Text;
            var nomero = numericUpDown1.Value;

            var addquery = $"INSERT INTO Аммуниция(ФИОВладельца, ВидА, Дисциплина, ДатаП, НомерО) VALUES ('{fio}','{vida}','{dis}','{datap}','{nomero}')";
            var command = new SqlCommand(addquery, dataBase.getConnection());

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Успех");
            }
            catch
            {

            }

        }

        private void ammuvnesti_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy mm dd";
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

            string query = $"SELECT Имя FROM Сотрудник";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
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

                textBox2.Text = name;

                dataGridView1.Visible = false;

            }
        }
    }
}
