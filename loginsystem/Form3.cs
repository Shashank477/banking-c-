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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("update customerdetails set accbal=accbal+'" + textBox2.Text + "' where id='" + textBox1.Text + "'", conn);
            command.ExecuteNonQuery();
            SqlCommand command1 = new SqlCommand("insert into statement(id,particulars,deposit,balance,date) select '" + textBox1.Text + "','By Cash','" + textBox2.Text + "',accbal,getdate() from customerdetails where id='"+textBox1.Text+"'", conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Amount deposited succesfully");
        }

    }
}
