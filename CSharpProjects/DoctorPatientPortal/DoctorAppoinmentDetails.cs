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
    public partial class DoctorAppoinmentDetails : MetroFramework.Forms.MetroForm
    {
        string emailID;
        int drID;
        public DoctorAppoinmentDetails()
        {
            InitializeComponent();
        }

        public DoctorAppoinmentDetails(string emailID, int drID)
        {
            InitializeComponent();
            this.emailID = emailID;
            this.drID = drID;
        }

        private void DoctorBookingHistory_Load(object sender, EventArgs e)
        {
            DoctorClass.ShowDoctorBookingHistory(dataGridView1, drID);
        }

        private void DoctorBookingHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DoctorDashBoard(emailID, drID).Show();
            this.Hide();
        }
    }
}
