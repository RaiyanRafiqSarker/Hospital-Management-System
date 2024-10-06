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

namespace Form1
{
    public partial class ViewAppointment : Form
    {
        public ViewAppointment()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";


            string query = "SELECT Id, Catagory,PatientName FROM Appointment";


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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

    
            Form previousForm = this.Owner;

            if (previousForm is HomeDoctor)
            {
                
                HomeDoctor homeDoctorForm = new HomeDoctor();
                homeDoctorForm.ShowDialog();
            }
            else if (previousForm is HomeAdmin)
            {
                
                HomeAdmin homeAdminForm = new HomeAdmin();
                homeAdminForm.ShowDialog();
            }
            
        }
    }
}
