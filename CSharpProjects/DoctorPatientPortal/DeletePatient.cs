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
    public partial class DeletePatient : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public DeletePatient()
        {
            InitializeComponent();
        }
        public DeletePatient(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void DeletePatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminDashBoard(emailID).Show();
            this.Hide();
        }
        private void DeletePatient_Load(object sender, EventArgs e)
        {
            PatientClass.ShowPatientDetails(dataGridView1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DoctorClass.DeletePatient(int.Parse(textBox1.Text));
        }
    }
}
