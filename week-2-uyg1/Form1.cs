using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week_2_uyg1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Ticari; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "select * from product";

            SqlCommand cmd = new SqlCommand("select * from  product", con);
            SqlDataReader   dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                // listBox1.Items.Add(dr["name"]);
                //listBox1.Items.Add(dr["product_id"].ToString()+" "+dr["name"].ToString());
                listBox1.Items.Add($" {dr["product_id"]}  {dr["name"]}");
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Ticari; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection con = new SqlConnection(str);
            con.Open();
           

            SqlCommand cmd = new SqlCommand("select * from  product", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2]);    
            }

            con.Close();
        }
    }
}
