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

namespace week_uyg_2
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


            SqlCommand cmd = new SqlCommand("select * from  product", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            //while (dr.Read())
            //{
            //    dataGridView1.Rows.Add(dr[0], dr[1], dr[2]);
            //}

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Ticari; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection con = new SqlConnection(str);
            con.Open();

            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //MessageBox.Show(id.ToString());
            SqlCommand cmd = new SqlCommand("delete from product  where product_id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

           int adet= cmd.ExecuteNonQuery();
            MessageBox.Show(adet.ToString() + " kayıt silindi");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string str = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Ticari; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection con = new SqlConnection(str);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into product (name,unit_price,cat_id) values(@name,@price,@catid) ", con);

            string name = textBox1.Text;
            double price = Convert.ToDouble(textBox2.Text);
            int catid = Convert.ToInt16(textBox3.Text);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@catid", catid);
            int adet = cmd.ExecuteNonQuery();
            MessageBox.Show(adet.ToString() + " kayıt ekelendi");
            con.Close();
        }
    }
}
