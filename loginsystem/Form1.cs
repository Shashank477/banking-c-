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
using System.Runtime.Remoting.Messaging;
using System.CodeDom;

namespace loginsystem
{
    public partial class Form1 : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("insert into customerdetails values('" + textBox1.Text + "'," + "'" + textBox2.Text + "','" + textBox3.Text + "'," + "'" + textBox4.Text + "','"+textBox9.Text+"','" + textBox5.Text + "','" + textBox6.Text + "','0',getdate())", conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Succesfully inserted");
                /*textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";*/
;                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
                conn.Open();
                SqlCommand command = new SqlCommand("select * from customerdetails where id='"+textBox7.Text+"' and password='"+textBox8.Text+"'", conn);
                command.ExecuteNonQuery();
                SqlDataReader sdr = command.ExecuteReader();
                if(sdr.Read())
                {
                    SetValueForText1 = textBox7.Text;
                    SetValueForText2 = textBox8.Text;
                    var Form2 = new Form2();
                    Form2.Show();
                }
                else
                {
                    MessageBox.Show("Username and password is not correct");
                }
                
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Form3 = new Form3();
            Form3.Show();
        }



       
    }
}
