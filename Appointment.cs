using PMS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    public partial class Appointment : Form
    {
        Functions con;
        public Appointment()
        {
            InitializeComponent();
            con=new Functions();
            GetDoctor();
        }
        private void GetDoctor()
        {
            string Query = "SELECT * FROM Doctor";
            DataTable dt = con.GetData(Query);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dt;
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            LoadDoctorData();
        }

        private void LoadDoctorData()
        {
            
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";

            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    
                    con.Open();

                    
                    string doctorQuery = "SELECT DoctorID, DoctorName FROM Doctors";
                    SqlCommand cmd = new SqlCommand(doctorQuery, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    
                    comboBox1.DisplayMember = "DoctorName";  
                    comboBox1.ValueMember = "DoctorID";   
                    comboBox1.DataSource = dt;           
                }
                catch (SqlException excep)
                {
                   
                    MessageBox.Show(excep.Message);
                }
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";

           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                  
                    con.Open();

                   
                    string insertQuery = "INSERT INTO Appointment(Catagory, DoctorID, Date, Time, PatientName) " +
                                         "VALUES(@Catagory, @DoctorID, @Date, @Time, @PatientName);";

                 
                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    
                    cmd.Parameters.AddWithValue("@Catagory", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PatientName", textBox7.Text);

  
                    cmd.ExecuteNonQuery();

 
                    string fetchMaxIdQuery = "SELECT MAX(Id) FROM Appointment;";
                    SqlCommand cmd1 = new SqlCommand(fetchMaxIdQuery, con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Inserted Appointment Information Successfully.");

                       
                        textBox2.Text = "";
                        dateTimePicker1.Value = DateTime.Now; 
                        comboBox1.SelectedIndex = -1;          
                        textBox5.Text = "";
                        textBox7.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    
                    MessageBox.Show(excep.Message);
                }
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;  
            comboBox1.SelectedIndex = -1;      
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void Appointment_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

            
            HomePatient homePatientForm = new HomePatient();
            homePatientForm.ShowDialog();
        }
    }
}
