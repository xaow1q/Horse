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
    public partial class dennik : Form
    {
        DataBase dataBase = new DataBase();
        public dennik()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void dennik_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateColumn()
        {
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Порода", "Порода");
            dataGridView1.Columns.Add("ДатаР", "ДатаР");
            dataGridView1.Columns.Add("Пол", "Пол");
            dataGridView1.Columns.Add("Владелец", "Владелец");
            dataGridView1.Columns.Add("Денник", "Денник");
            dataGridView1.Columns.Add("Питание", "Питание");
            dataGridView1.Columns.Add("КгВДень", "КгВДень");
            dataGridView1.Columns.Add("ПроцСух", "ПроцСух");
            dataGridView1.Columns.Add("ПроцСочн", "ПроцСочн");
            dataGridView1.Columns.Add("ПроцКонц", "ПроцКонц");
            dataGridView1.Columns.Add("Берейтор", "Берейтор");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Лошадь WHERE Денник = '{textBox1.Text}'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), RowState.ModifiedRow);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateColumn();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
        }
    }
}
