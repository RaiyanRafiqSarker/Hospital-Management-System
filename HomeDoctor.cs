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
    public partial class HomeDoctor : Form
    {
        public HomeDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();

                ViewAppointment viewAppointmentForm = new ViewAppointment();
                viewAppointmentForm.ShowDialog();
                

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();

            Homepage homepageForm = new Homepage();
            homepageForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            UpdateDoctorProfile updateDoctorProfileForm = new UpdateDoctorProfile();
            updateDoctorProfileForm.ShowDialog();
            

        }
    }
}
