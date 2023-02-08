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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("update customerdetails set accbal=accbal+'" + textBox2.Text + "' where id='" + textBox1.Text + "'", conn);
            command.ExecuteNonQuery();
            SqlCommand command0 = new SqlCommand("update customerdetails set accbal=accbal-'" + textBox2.Text + "' where id='" + Form1.SetValueForText1 + "'", conn);
            command0.ExecuteNonQuery();
            SqlCommand command1 = new SqlCommand("insert into statement(id,particulars,withdrawals,balance,date) select '" + Form1.SetValueForText1 + "','Sent To("+textBox1.Text+")','" + textBox2.Text + "',accbal,getdate() from customerdetails where id='" + Form1.SetValueForText1 + "'", conn);
            command1.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand("insert into statement(id,particulars,deposit,balance,date) select '" + textBox1.Text + "','Recieved From("+Form1.SetValueForText1+")','" + textBox2.Text + "',accbal,getdate() from customerdetails where id='" + textBox1.Text + "'", conn);
            command2.ExecuteNonQuery();
            MessageBox.Show("Amount transfered succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form2 = new Form2();
            Form2.Show();
        }
    }
}
