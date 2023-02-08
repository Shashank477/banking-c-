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

namespace loginsystem
{
    public partial class profileupdate : Form
    {
        public profileupdate()
        {
            InitializeComponent();
        }

        private void profileupdate_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("select firstname,secondname,phone,email,address,password from customerdetails where id='" + Form1.SetValueForText1 + "'", conn);
                command.ExecuteNonQuery();
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    textBox1.Text = sdr.GetString(0);
                    textBox2.Text = sdr.GetString(1);
                    textBox3.Text = sdr.GetSqlValue(2).ToString();
                    textBox4.Text = sdr.GetString(3);
                    textBox5.Text = sdr.GetString(4);
                    textBox6.Text = sdr.GetString(5);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("update customerdetails set firstname='"+textBox1.Text+"',secondname='"+textBox2.Text+"',phone='"+textBox3.Text+"',email='"+textBox4.Text+"',address='"+textBox5.Text+"',password='"+textBox6.Text+"' where id='"+Form1.SetValueForText1+"'",conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Account details updated successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form6 = new Form6();
            Form6.Show();
        }
    }
}
