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
using System.Runtime.InteropServices.WindowsRuntime;

namespace loginsystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void info()
        {
            try
            {
                label3.Text = Form1.SetValueForText1;
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("select firstname,secondname,accbal from customerdetails where id='" + Form1.SetValueForText1 + "'", conn);
                command.ExecuteNonQuery();
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    label3.Text = sdr.GetString(0);
                    label4.Text = sdr.GetString(1);
                    label6.Text = sdr.GetSqlValue(2).ToString();
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            info();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form4 = new Form4();
            Form4.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form5 = new Form5();
            Form5.Show();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            info();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form6 = new Form6();
            Form6.Show();
        }
    }
}
