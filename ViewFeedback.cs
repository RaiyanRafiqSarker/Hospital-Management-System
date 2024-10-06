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
using System.Xml.Linq;

namespace Form1
{
    public partial class ViewFeedback : Form
    {
        public ViewFeedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";


            string query = "SELECT Id, DoctorID,Feedback FROM Feedback";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    conn.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);


                    DataTable dataTable = new DataTable();


                    adapter.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred: " + ex.Message);
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
