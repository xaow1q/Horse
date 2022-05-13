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
   
    public partial class admindanniesotr : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public admindanniesotr()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("Пол", "Пол");
            dataGridView1.Columns.Add("ДатаР", "ДатаР");
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Занятость", "Занятость");
            dataGridView1.Columns.Add("ТабельныйНомер", "Табельный номер");
            dataGridView1.Columns.Add("Пароль", "Пароль");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            
                dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetInt32(7), record.GetString(8), RowState.ModifiedRow);

           
            //dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), RowState.ModifiedRow);
           
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT * FROM Сотрудник";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void admindanniesotr_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var Name = textBox1.Text;
            var fam = textBox2.Text;
            var otch = textBox3.Text;
            var pol = textBox4.Text;
            var datar = textBox5.Text;
            var dolj = textBox6.Text;
            var zan = textBox7.Text;
            var tn = textBox8.Text;
            var pass = textBox9.Text;
           

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                dataGridView1.Rows[selectedRowIndex].SetValues(Name, fam, otch, pol, datar, dolj, zan, tn, pass);
                dataGridView1.Rows[selectedRowIndex].Cells[9].Value = RowState.Modified;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {

                try
                {
                    var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;
                    if (rowState == RowState.Existed)
                        continue;

                    if (rowState == RowState.Modified)
                    {
                        var Name = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        var fam = dataGridView1.Rows[index].Cells[1].Value.ToString();
                        var otch = dataGridView1.Rows[index].Cells[2].Value.ToString();
                        var pol = dataGridView1.Rows[index].Cells[3].Value.ToString();
                        var datar = dataGridView1.Rows[index].Cells[4].Value.ToString();
                        var kat = dataGridView1.Rows[index].Cells[5].Value.ToString();
                        var prost = dataGridView1.Rows[index].Cells[6].Value.ToString();
                        var namel = dataGridView1.Rows[index].Cells[7].Value.ToString();
                        var poroda = dataGridView1.Rows[index].Cells[8].Value.ToString();
                       


                        var changeQuery = $"UPDATE Сотрудник set Имя = '{Name}', Фамилия = '{fam}', Отчество = '{otch}', Пол = '{pol}', ДатаР = '{datar}', Должность = '{kat}', Занятость = '{prost}', Пароль = '{poroda}' where ТабельныйНомер = '{namel}'";

                        var command = new SqlCommand(changeQuery, dataBase.getConnection());
                        command.ExecuteNonQuery();
                    }

                    
                }
                catch
                {

                }

            }
            MessageBox.Show("Успех");
            dataBase.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delsotr ds = new delsotr();
            ds.ShowDialog();
        }
    }
}
