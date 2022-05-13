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
    public partial class delKlient : Form
    {
        DataBase dataBase = new DataBase();
        public delKlient()
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

            int id;
            try
            {
                if (int.TryParse(textBox1.Text, out id))
                {
                    var addQuery = $"DELETE FROM Клиент WHERE Идентификатор = '{id}'";

                    var command = new SqlCommand(addQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Идентификатор должен быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
    }
}
