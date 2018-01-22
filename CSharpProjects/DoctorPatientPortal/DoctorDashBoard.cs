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
    public partial class DoctorDashBoard : MetroFramework.Forms.MetroForm
    {
        string emailID;
        int drId;
        public DoctorDashBoard()
        {
            InitializeComponent();
        }

        public DoctorDashBoard(string emailID, int drId)
        {
            InitializeComponent();
            this.emailID = emailID;

            drId = DoctorClass.GetDoctorID(emailID);
            this.drId = drId;

            //MessageBox.Show(drId.ToString());
        }

        private void DoctorDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainWindowForm().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorClass.DoctorAvailableTimeSetToDB(emailID, comboBox1.Text, comboBox2.Text, DoctorClass.GetDoctorID(emailID));
        }

        private void DoctorDashBoard_Load(object sender, EventArgs e)
        {

            int drID = DoctorClass.GetDoctorID(emailID);

            groupBox2.Text = "Dr. ID: " + drId.ToString();

            List<string> timeList1 = new List<string>();
            timeList1.Add("8:00 AM");
            timeList1.Add("9:00 AM");
            timeList1.Add("10:00 AM");
            timeList1.Add("11:00 PM");
            timeList1.Add("12:00 PM");
            timeList1.Add("1:00 PM");
            timeList1.Add("2:00 PM");
            timeList1.Add("3:00 PM");
            timeList1.Add("4:00 PM");
            timeList1.Add("5:00 PM");
            timeList1.Add("6:00 PM");

            List<string> timeList2 = new List<string>();
            timeList2.Add("12:00 AM");
            timeList2.Add("1:00 AM");
            timeList2.Add("2:00 AM");
            timeList2.Add("3:00 PM");
            timeList2.Add("4:00 PM");
            timeList2.Add("5:00 PM");
            timeList2.Add("6:00 PM");
            timeList2.Add("7:00 PM");
            timeList2.Add("8:00 PM");
            timeList2.Add("9:00 PM");

            DoctorClass.DoctorAvailableTimeSet(timeList1, timeList2, comboBox1, comboBox2);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DoctorAppoinmentDetails(emailID, drId).Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DoctorProfile(emailID).Show();
            this.Hide();
        }
    }
}
