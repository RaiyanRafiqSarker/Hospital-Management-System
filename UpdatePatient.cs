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
    public partial class UpdatePatient : Form
    {
        public UpdatePatient()
        {
            InitializeComponent();
        }

        private void UpdatePatient_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "select * from Patient";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }
            dgvViewPatient.AutoGenerateColumns = false;
            dgvViewPatient.DataSource = result;
            dgvViewPatient.Refresh();
            dgvViewPatient.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        } 
        private void NewData()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtMobile.Text = "";
            dgvViewPatient.ClearSelection();
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
            string Mobile = txtMobile.Text;

           
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

            if (string.IsNullOrEmpty(Mobile))
            {
                MessageBox.Show("Mobile cannot be empty!");
                return;
            }

           
            var query = $"UPDATE Patient SET Name = '{Name}', Mobile = {Mobile} WHERE Id = {Id}";

           
            var result = DataConnect.ExexuteQyery(query);

           
            if (result == false)
            {
                MessageBox.Show("Something went wrong. Please try again!");
                return;
            }

            MessageBox.Show("Success");
            this.LoadData();


            for (int i = 0; i < dgvViewPatient.Rows.Count; i++)
            {
                string selectedId = dgvViewPatient.Rows[i].Cells[0].Value.ToString();
                if (selectedId == Id)
                {
                    dgvViewPatient.Rows[i].Selected = true;
                    return;
                }
            }
        }


        private void dgvViewPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
             
                var cellValue = dgvViewPatient.Rows[e.RowIndex].Cells[0].Value;
                if (cellValue != null)
                {
                    string Id = cellValue.ToString();
                    this.LoadSingleData(Id);
                }
            }
        }

        private void LoadSingleData(string Id)
        {
            string query = "select* from Patient where Id = " + Id + "";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }

            txtId.Text = result.Rows[0]["Id"].ToString();
            txtName.Text = result.Rows[0]["Name"].ToString();
            txtMobile.Text = result.Rows[0]["Mobile"].ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();


            HomePatient homePatientForm = new HomePatient();
            homePatientForm.ShowDialog();
        }
    }



}
