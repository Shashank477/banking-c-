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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                label3.Text = Form1.SetValueForText1;
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("select firstname,secondname,phone,email,address,id,password,accbal,date from customerdetails where id='" + Form1.SetValueForText1 + "'", conn);
                command.ExecuteNonQuery();
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    label3.Text = sdr.GetString(0);
                    label4.Text = sdr.GetString(1);
                    label6.Text = sdr.GetSqlValue(2).ToString();
                    label8.Text = sdr.GetString(3);
                    label10.Text = sdr.GetString(4);
                    label12.Text = sdr.GetString(5);
                    label14.Text = sdr.GetString(6);
                    label16.Text = sdr.GetSqlValue(7).ToString();
                    label18.Text = sdr.GetDateTime(8).ToString();
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
            this.Close();
            var profileupdate = new profileupdate();
            profileupdate.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form2 = new Form2();
            Form2.Show();
        }
    }
}
