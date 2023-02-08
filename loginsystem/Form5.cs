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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

     


        void BindData()
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-8UNJ19KT\\SQLEXPRESS02;Initial Catalog=loginsystem;Integrated Security=True");
            SqlCommand command = new SqlCommand(";WITH d(DateCr,d,Id,particulars,withdrawals,deposit,balance) AS (SELECT date, d = CONVERT(DATE, date), Id,particulars, withdrawals, deposit, balance FROM statement) SELECT id,particulars, withdrawals, deposit, balance, DateCr FROM d WHERE id='"+Form1.SetValueForText1+"' ORDER BY DateCr; ", conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var Form2 = new Form2();
            Form2.Show();
        }
    }
}
