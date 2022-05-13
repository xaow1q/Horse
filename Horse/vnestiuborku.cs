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
    public partial class vnestiuborku : Form
    {
        DataBase dataBase = new DataBase(); 
        public vnestiuborku()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var mesto = comboBox1.Text;
            var time = dateTimePicker2.Value.ToShortTimeString();
            var date = dateTimePicker1.Value.ToShortDateString();

            var addQuery = $"INSERT INTO ГрафикУборки(Место, Дата, Время) VALUES ('{mesto}','{date}','{time}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Успех!", "Успех!", MessageBoxButtons.OK);

            dataBase.closeConnection();
        }

        private void vnestiuborku_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Time;
        }
    }
}
