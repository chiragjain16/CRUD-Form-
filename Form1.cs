using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHIRAGIT\SQLEXPRESS;Initial Catalog=CRUP form;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ut values(@id, @name, @age, @department)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@department", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHIRAGIT\SQLEXPRESS;Initial Catalog=CRUP form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update ut set department=@department, name = @name, age = @age where id = @id;", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@department", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=CHIRAGIT\SQLEXPRESS;Initial Catalog=CRUP form;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("delete ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHIRAGIT\SQLEXPRESS;Initial Catalog=CRUP form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from ut", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            
        
        }
    }
}
