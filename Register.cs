using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";

       
            string Name = NametextBox2.Text;
            int Mobile = int.Parse(MobiletextBox3.Text);
            string Address = AddresstextBox4.Text;
            string Password = PasswordtextBox5.Text;

           
            string query = "INSERT INTO Patient (Name, Mobile, Address, Password) VALUES (@Name, @Mobile, @Address, @Password)";

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                   
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Mobile", Mobile);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        
                        cmd.ExecuteNonQuery();

                        
                        MessageBox.Show("Data inserted successfully!");
                    }
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();

            Homepage homepageForm = new Homepage();
            homepageForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NametextBox2.Text = "";
            MobiletextBox3.Text = "";
            AddresstextBox4.Text = "";
            PasswordtextBox5.Text = "";
            
        }
    }
}
