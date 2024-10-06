using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class UpdateDoctorProfile : Form
    {
        public UpdateDoctorProfile()
        {
            InitializeComponent();
        }

        private void UpdateDoctorProfile_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "select * from Doctor";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong in Load.Please Try Again!");
                return;
            }
            dgvUpdateDoctor.AutoGenerateColumns = false;
            dgvUpdateDoctor.DataSource = result;
            dgvUpdateDoctor.Refresh();
            dgvUpdateDoctor.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDegree.Text = "";
            txtSpeciality.Text = "";
            dgvUpdateDoctor.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.UpdateData();
        }

        private void UpdateData()
        {
           
            string Id = txtId.Text;
            string Name = txtName.Text;
            string Degree = txtDegree.Text;
            string Speciality = txtSpeciality.Text;

            
            if (string.IsNullOrEmpty(Id))
            {
                MessageBox.Show("ID cannot be empty!");
                return;
            }

            
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Name cannot be empty!");
                return;
            }

            
            if (string.IsNullOrEmpty(Degree))
            {
                MessageBox.Show("Degree cannot be empty!");
                return;
            }

            
            if (string.IsNullOrEmpty(Speciality))
            {
                MessageBox.Show("Speciality cannot be empty!");
                return;
            }


            string query = $"UPDATE Doctor SET Name = '"+Name+"', Degree = '"+Degree+"', Speciality = '"+Speciality+"' WHERE Id = "+Id+"";


            var result = DataConnect.ExexuteQyery(query); 

            
            if (!result)
            {
                MessageBox.Show("Something went wrong in Update. Please try again!");
                return;
            }

           
            MessageBox.Show("Update successful!");

            
            this.LoadData();

            
            for (int i = 0; i < dgvUpdateDoctor.Rows.Count; i++)
            {
                
                string selectedId = dgvUpdateDoctor.Rows[i].Cells[0].Value?.ToString();

                
                if (selectedId == Id)
                {
                    dgvUpdateDoctor.ClearSelection(); 
                    dgvUpdateDoctor.Rows[i].Selected = true; 
                    dgvUpdateDoctor.FirstDisplayedScrollingRowIndex = i; 
                    return;
                }
            }
        }



        private void dgvViewPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var cellValue = dgvUpdateDoctor.Rows[e.RowIndex].Cells[0].Value;
                if (cellValue != null)
                {
                    string Id = cellValue.ToString();
                    this.LoadSingleData(Id);
                }
            }
        }
        private void LoadSingleData(string Id)
        {

            if (string.IsNullOrEmpty(Id))
            {
                MessageBox.Show("ID cannot be empty.");
                return;
            }


            string query = $"SELECT * FROM Doctor WHERE Id = {Id}";


            DataTable result = DataConnect.GetData(query);


            if (result == null || result.Rows.Count == 0)
            {
                MessageBox.Show("No data found or something went wrong. Please try again.");
                return;
            }

            txtId.Text = result.Rows[0]["Id"].ToString();
            txtName.Text = result.Rows[0]["Name"].ToString();
            txtDegree.Text = result.Rows[0]["Degree"].ToString();
            txtSpeciality.Text = result.Rows[0]["Speciality"].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();

            HomeDoctor homeDoctorForm = new HomeDoctor();
            homeDoctorForm.ShowDialog();


        }
    }
}
