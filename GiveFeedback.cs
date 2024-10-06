using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Form1
{
    public partial class GiveFeedback : Form
    {
        public GiveFeedback()
        {
            InitializeComponent();
        }

        private void GiveFeedback_Load(object sender, EventArgs e)
        {
            this.LoadData();
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string doctorQuery = "SELECT ID, Name FROM Doctor";
                    SqlCommand cmd = new SqlCommand(doctorQuery, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "ID";
                    comboBox2.DataSource = dt;
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }
        private void LoadData()
        {
            string query = "select * from Feedback";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }
            dgvFeedback.AutoGenerateColumns = false;
            dgvFeedback.DataSource = result;
            dgvFeedback.Refresh();
            dgvFeedback.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }
            int DoctorID = (int)comboBox2.SelectedValue;
            string Feedback = rtxtFeedback.Text.Trim();
            if (string.IsNullOrEmpty(Feedback))
            {
                MessageBox.Show("Feedback cannot be empty!");
                return;
            }

            string query = "INSERT INTO Feedback (DoctorID, Feedback) VALUES (@DoctorID, @Feedback)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                    
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                        cmd.Parameters.AddWithValue("@Feedback", Feedback);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Feedback submitted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dgvViewDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvFeedback.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadSingleData(id);
            }
        }

        private void LoadSingleData(string id)
        {
            string query = "select* from Feedback where id = " + id + "";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }

            txtID.Text = result.Rows[0]["id"].ToString();
            rtxtFeedback.Text = result.Rows[0]["Feedback"].ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();


            HomePatient homePatientForm = new HomePatient();
            homePatientForm.ShowDialog();

        }
    }
}
