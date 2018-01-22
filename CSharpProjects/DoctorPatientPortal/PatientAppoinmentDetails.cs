using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorPatientPortal
{
    public partial class PatientAppoinmentDetails : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public PatientAppoinmentDetails()
        {
            InitializeComponent();
        }
        public PatientAppoinmentDetails(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void PatientAppoinmentDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PatientDashBoard(emailID).Show();
            this.Hide();
        }

        private void PatientAppoinmentDetails_Load(object sender, EventArgs e)
        {
            PatientClass.ShowPatientBookingDetails(dataGridView1,PatientClass.GetPatientID(emailID));
        }
    }
}
