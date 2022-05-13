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
    public partial class dellosh : Form
    {
        DataBase dataBase = new DataBase();
        public dellosh()
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

            var name = textBox1.Text;
            try
            {
                
                    var addQuery = $"DELETE FROM Лошадь WHERE Имя = '{name}'";

                    var command = new SqlCommand(addQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
               
            }
            catch
            {
                MessageBox.Show("Невозможно удалить строку из-за вторичного ключа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

            }
            dataBase.closeConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
