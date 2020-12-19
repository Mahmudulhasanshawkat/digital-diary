using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ccc"].ConnectionString);
            connection.Open();
       
            SqlCommand cmd = new SqlCommand("INSERT INTO userr(pass,event,notes,date) VALUES (@pass,@event,@notes,@date)", connection);
            cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@event", textBox2.Text);
            cmd.Parameters.AddWithValue("@notes", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", textBox4.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            MessageBox.Show("Successfully Inserted!!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ccc"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM userr WHERE pass=@pass", connection);
            cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ccc"].ConnectionString);
            connection.Open(); 
            SqlCommand cmd = new SqlCommand("UPDATE userr SET event=@event, notes=@notes,date=@date WHERE pass=@pass", connection);
            cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@event", textBox2.Text);
            cmd.Parameters.AddWithValue("@notes", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", textBox4.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            MessageBox.Show("Successfully Updated!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ccc"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("DELETE userr WHERE pass=@pass", connection);
            cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            MessageBox.Show("Successfully Deleted!!!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ccc"].ConnectionString);
            connection.Open();
           // this.memberTableAdapter.Fill(this.uSER_TABLEDataSet.member);

            SqlCommand cmd = new SqlCommand("SELECT * FROM userr", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
    
}
