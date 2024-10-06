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
    public partial class UpdateDoctor : Form
    {
        public UpdateDoctor()
        {
            InitializeComponent();
        }

        private void UpdateDoctor_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            string query = "select * from Doctor";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }
            dgvViewDoctor.AutoGenerateColumns = false;
            dgvViewDoctor.DataSource = result;
            dgvViewDoctor.Refresh();
            dgvViewDoctor.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDegree.Text = "";
            txtSpeciality.Text = "";
            txtSalary.Text = "";
            txtPassword.Text = "";
            dgvViewDoctor.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }

        private void DeleteData()
        {
            string id = txtID.Text;

            if (id == "")
            {
                MessageBox.Show("Please select a row first");
                return;
            }

            var userResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);

            if (userResult == DialogResult.No)
            {
                return;
            }


            var query = "delete from Doctor where id = " + id + "";
            var result = DataConnect.ExexuteQyery(query);

            if (result == false)
            {
                MessageBox.Show("Somthing Went Wrong.Pleasr try again!");
                return;
            }
            MessageBox.Show("Deleted");
            this.LoadData();
            this.NewData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void SaveData()
        {
            string id = txtID.Text;
            string Name = txtName.Text;
            string Degree = txtDegree.Text;
            string Speciality = txtSpeciality.Text;
            string Salary = txtSalary.Text;
            string Password = txtPassword.Text;

            if (txtID.Text == "")
            {
                var query = "insert into Doctor (Name,Degree,Speciality,Salary,Password) output inserted.Id values('" + Name + "','" + Degree + "','" + Speciality + "'," + Salary + "," + Password + ")";
                var result = DataConnect.GetData(query);
                if (result == null)
                {
                    MessageBox.Show("Somthing Went Wrong.Pleasr try again!");
                    return;
                }

                txtID.Text = result.Rows[0]["ID"].ToString();
            }
            else
            {
                var query = "UPDATE Doctor SET Name = '" + Name + "', Degree = '" + Degree + "', Speciality = '" + Speciality + "', Salary = " + Salary + ", Password = '" + Password + "' WHERE Id = " + id + "";
                var result = DataConnect.ExexuteQyery(query);

                if (result == false)
                {
                    MessageBox.Show("Somthing Went Wrong.Pleasr try again!");
                    return;
                }
                MessageBox.Show("Success");
            }

            this.LoadData();

            for (int i = 0; i < dgvViewDoctor.Rows.Count; i++)
            {
                string selectedID = dgvViewDoctor.Rows[i].Cells[0].Value.ToString();
                if (selectedID == txtID.Text)
                {
                    dgvViewDoctor.Rows[i].Selected = true;
                    return;
                }
            }
        }

        private void dgvViewDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvViewDoctor.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadSingleData(id);
            }
        }
        private void LoadSingleData(string id)
        {
            string query = "select* from Doctor where id = " + id + "";
            DataTable result = DataConnect.GetData(query);

            if (result == null)
            {
                MessageBox.Show("Somthing Went Wrong.Please Try Again!");
                return;
            }

            txtID.Text = result.Rows[0]["id"].ToString();
            txtName.Text = result.Rows[0]["Name"].ToString();
            txtDegree.Text = result.Rows[0]["Degree"].ToString();
            txtSpeciality.Text = result.Rows[0]["Speciality"].ToString();
            txtSalary.Text = result.Rows[0]["Salary"].ToString();
            txtPassword.Text = result.Rows[0]["Password"].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

            HomeAdmin homeAdminForm = new HomeAdmin();
            homeAdminForm.ShowDialog();
        }
    }
}
