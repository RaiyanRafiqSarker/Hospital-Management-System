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
    public partial class HomePatient : Form
    {
        public HomePatient()
        {
            InitializeComponent();
        }

        private void HomePatient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();    

            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                this.Hide();

                Homepage homepageForm = new Homepage();
                homepageForm.ShowDialog();  

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GiveFeedback giveFeedbackForm = new GiveFeedback();
            giveFeedbackForm.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdatePatient updatePatientForm = new UpdatePatient();

            
            updatePatientForm.Show();
            this.Hide();
        }
    }
}
