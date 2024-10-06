using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form1
{
    public partial class ViewDoctor : Form
    {
        public ViewDoctor()
        {
            InitializeComponent();
        }

        private void ViewDoctor_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadDoctorData()
        {
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                   
                    con.Open();

                
                    string query = "SELECT Id, Name, Degree, Speciality, Salary, Password FROM Doctor";

                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

  
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["Id"].Width = 50;
                    dataGridView1.Columns["Name"].Width = 150;
                    dataGridView1.Columns["Degree"].Width = 100;
                    dataGridView1.Columns["Speciality"].Width = 100;
                    dataGridView1.Columns["Salary"].Width = 100;   
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDoctorData();
        }
    }
}
