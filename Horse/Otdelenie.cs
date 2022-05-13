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
    public partial class Otdelenie : Form
    {
        DataBase dataBase = new DataBase();
        
        public Otdelenie()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label5.Text != "Администратор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Admin adminform = new Admin();
                this.Hide();
                adminform.ShowDialog();
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Otdelenie_Load(object sender, EventArgs e)
        {
            label3.Text = DataBank.Login;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            label5.Text = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
            DataBank.Dolj = label5.Text;


        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Должность", "Д");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), RowState.ModifiedRow);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"SELECT Должность FROM Сотрудник WHERE ТабельныйНомер = '{label3.Text}'";
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (label5.Text != "Администратор" && label5.Text != "Конюх" && label5.Text != "Берейтор" && label5.Text != "Коваль" && label5.Text != "Ветеринар")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Konush koni = new Konush();
                koni.ShowDialog();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Конюх" && label5.Text != "Берейтор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Manej man = new Manej();
                man.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Конюх" && label5.Text != "Берейтор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                levadi lev = new levadi();
                lev.ShowDialog();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Шорник" && label5.Text != "Конюх")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amunchik amun = new amunchik();
                amun.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Коваль" && label5.Text != "Берейтор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koval koval = new koval();
                koval.ShowDialog();
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Ветеринар" && label5.Text != "Берейтор")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                veterinar vet = new veterinar();
                vet.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label5.Text != "Администратор" && label5.Text != "Администратор базы отдыха")
            {
                MessageBox.Show("У вас нет доступа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BazaOtd baza = new BazaOtd();
                baza.ShowDialog();
            }
                
        }
    }
}
