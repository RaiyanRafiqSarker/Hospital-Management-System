using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form1
{
    public partial class ViewPatient : Form
    {
        public ViewPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    
                    string query = "SELECT Id, Name, Mobile, Address, Password FROM Patient";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["Id"].Width = 50;        
                    dataGridView1.Columns["Name"].Width = 150;
                    dataGridView1.Columns["Mobile"].Width = 100;
                    dataGridView1.Columns["Address"].Width = 200;
                    dataGridView1.Columns["Password"].Width = 100;

                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    
                    con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

            HomeAdmin homeAdminForm = new HomeAdmin();
            homeAdminForm.ShowDialog();
        }
    }
}
