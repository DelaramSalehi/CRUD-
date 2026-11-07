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

namespace WindowsFormsApp48
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public void show_data()
        {
            string str_connection = @"Data Source=DESKTOP-G3MUKIA\SQL2022;Initial Catalog=s;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(str_connection);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Table_st", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];

                con.Close();
            }
            catch (Exception e1)
            {
                con.Close();
            }

        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            show_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strcon = @"Data Source=DESKTOP-G3MUKIA\SQL2022;Initial Catalog=s;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(strcon);

            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into Table_st (ID, FirstName, LastName, City)values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", connection);
            int d = cmd.ExecuteNonQuery();
            connection.Close();
            if (d > 0)
            {
                MessageBox.Show("insert Successfully");
            }

            show_data();
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strcon = @"Data Source=DESKTOP-G3MUKIA\SQL2022;Initial Catalog=s;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(strcon);

            connection.Open();

            SqlCommand cmd = new SqlCommand("delete from [dbo].[Table_st] where ID=" + textBox1.Text,connection );
            int d = cmd.ExecuteNonQuery();
            if (d > 0)
            {
                MessageBox.Show(" Successfully");
            }

            show_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strcon = @"Data Source=DESKTOP-G3MUKIA\SQL2022;Initial Catalog=s;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(strcon);

            connection.Open();

            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Table_st] set FirstName= N'"+textBox2.Text+"' where id=" +textBox1.Text , connection);
            //SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[Table_st] set lastName= N'" + textBox3.Text + "' where id=" + textBox1.Text, connection);
            //SqlCommand cmd2 = new SqlCommand("UPDATE [dbo].[Table_st] set city= N'" + textBox4.Text + "' where id=" + textBox1.Text, connection);
            int d = cmd.ExecuteNonQuery();
            if (d > 0)
            {
                MessageBox.Show(" Successfully");
            }
            //int n = cmd1.ExecuteNonQuery();
            //if (n > 0)
            //{
            //    MessageBox.Show(" Successfully");
            //}
            //int a = cmd2.ExecuteNonQuery();
            //if (a > 0)
            //{
            //    MessageBox.Show(" Successfully");
            //}
            show_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex== dataGridView1.Columns["ID"].Index)
            {
                dataGridView1.Sort(dataGridView1.Columns["ID"],ListSortDirection.Descending);
            }
        }
    }
    }

