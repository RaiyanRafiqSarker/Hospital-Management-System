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
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void HomeAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDoctor updateDoctorForm = new UpdateDoctor();
            this.Hide();

            updateDoctorForm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewPatient viewPatientForm = new ViewPatient();
            this.Hide();

            viewPatientForm.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();

            ViewAppointment viewAppointmentForm = new ViewAppointment();
            viewAppointmentForm.ShowDialog();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();

            Homepage homepageForm = new Homepage();
            homepageForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            ViewFeedback viewFeedbackForm = new ViewFeedback();
            viewFeedbackForm.ShowDialog();
        }
    }
}
