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

    public partial class Auth : Form
    {
        
        DataBase dataBase = new DataBase();

        public Auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void buttonVhod_Click(object sender, EventArgs e)
        {
            var tabelnomer = textBox1.Text;
            var password = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"select ТабельныйНомер, Пароль, Должность FROM Сотрудник WHERE ТабельныйНомер = '{tabelnomer}' and Пароль = '{password}'";
            

            
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
          
            

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Успешный вход!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Otdelenie otdel = new Otdelenie();
                otdel.Owner = this;
                this.Hide();
                DataBank.Login = textBox1.Text;
                otdel.ShowDialog();
                }
             else
             {
                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            label4.Text = textBox1.Text;
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 50;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }
    }
}
