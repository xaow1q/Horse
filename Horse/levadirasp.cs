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
    public partial class levadirasp : Form
    {
        DataBase dataBase = new DataBase();
        public levadirasp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void CreateColumn()
         {

            dataGridView1.Columns.Add("НомерЛевады", "Номер Левады");
            dataGridView1.Columns.Add("Время", "Время");
            dataGridView1.Columns.Add("Дата", "Дата");
            dataGridView1.Columns.Add("Лошадь", "Лошадь");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT НомерЛевады, Время, Дата, Лошадь FROM Левады";
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

        private void levadirasp_Load(object sender, EventArgs e)
        {
            CreateColumn();
            RefreshDataGrid(dataGridView1);
        }
    }
}
