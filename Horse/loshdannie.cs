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
    public partial class loshdannie : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public loshdannie()
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
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Порода", "Порода");
            dataGridView1.Columns.Add("ДатаР", "Дата Рождения");
            dataGridView1.Columns.Add("Пол", "Пол");
            dataGridView1.Columns.Add("Владелец", "Владелец");
            dataGridView1.Columns.Add("Денник", "Денник");
            dataGridView1.Columns.Add("Питание", "Питание");
            dataGridView1.Columns.Add("КгВДень", "КгВДень");
            dataGridView1.Columns.Add("ПроцСух", "% сухого");
            dataGridView1.Columns.Add("ПроцСочн", "% сочного");
            dataGridView1.Columns.Add("ПроцКонц", "% концентированного");
            dataGridView1.Columns.Add("Берейтор", "Берейтор");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Лошадь";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void loshdannie_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();
                textBox9.Text = row.Cells[8].Value.ToString();
                textBox10.Text = row.Cells[9].Value.ToString();
                textBox11.Text = row.Cells[10].Value.ToString();
                textBox12.Text = row.Cells[11].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var Name = textBox1.Text;
            var por = textBox2.Text;
            var datar = textBox3.Text;
            var pol = textBox4.Text;
            var vlad = textBox5.Text;
            var den = textBox6.Text;
            var pitan = textBox7.Text;
            var kgvd = textBox8.Text;
            var procsuh = textBox9.Text;
            var procsoch = textBox10.Text;
            var procconc = textBox11.Text;
            var ber = textBox12.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                dataGridView1.Rows[selectedRowIndex].SetValues(Name, por, datar, pol, vlad, den, pitan, kgvd, procsuh, procsoch, procconc, ber);
                dataGridView1.Rows[selectedRowIndex].Cells[12].Value = RowState.Modified;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dellosh dl = new dellosh();
            dl.ShowDialog();
        }
    }
}
