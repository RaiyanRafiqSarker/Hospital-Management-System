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
using Form1;

namespace Form1

{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Visible = true;
             
            this.Visible=false;

        }


        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "admin" || textBox2.Text == "admin")
                {
                    MessageBox.Show("You are logged in successfully..");
                    this.Visible = false;
                    HomeAdmin obj1 = new HomeAdmin();
                    obj1.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "--Select--";
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password.");
                }
                HomeAdmin user = new HomeAdmin();
                user.Visible = true;
                this.Visible = false;
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False");
                con.Open();
                string str = "SELECT Name FROM Doctor WHERE Name = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Visible = false;
                    HomeDoctor obj2 = new HomeDoctor();
                    obj2.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "--Select--";
                }
                else
                {
                    MessageBox.Show("Invalid username and Password.");
                }
                HomeDoctor user = new HomeDoctor();
                user.Visible = true;
                this.Visible = false;
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False");
                con.Open();
                string str = "SELECT Name FROM Patient WHERE Name = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Visible = false;
                    HomePatient obj2 = new HomePatient();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "--Select--";
                }
                else
                {
                    MessageBox.Show("Invalid username and Password.");
                }
                HomePatient user = new HomePatient();
                user.Visible = true;
                this.Visible = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
