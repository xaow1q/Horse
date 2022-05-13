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
    public partial class bazadanonomer : Form
    {
        DataBase dataBase = new DataBase();
        public bazadanonomer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ФИОК", "ФИО клиента");
            dataGridView1.Columns.Add("КолВз", "Кол-во взрослых");
            dataGridView1.Columns.Add("КолДет", "Кол-во детей");
            dataGridView1.Columns.Add("ДатаЗ", "Дата заезда");
            dataGridView1.Columns.Add("ДатаВ", "Дата выхода");
            dataGridView1.Columns.Add("КолДней", "Количество дней");
            dataGridView1.Columns.Add("НомерА", "Номер аппартаментов");
            dataGridView1.Columns.Add("МобНКлиента", "Телефон клиента");
            dataGridView1.Columns.Add("ДопПожелания", "Дополнительные пожелания");
            dataGridView1.Columns.Add("Статус", "Статус");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            int i = Convert.ToInt32(textBox7.Text);
            string query = $"SELECT * FROM БазаБронь WHERE НомерА = '{i}'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void bazadanonomer_Load(object sender, EventArgs e)
        {
            CreateColumns();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }
    }
}
