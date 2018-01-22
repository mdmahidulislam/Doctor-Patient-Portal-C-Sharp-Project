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
    public partial class AdminDashBoard : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        public AdminDashBoard(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void DashBoardOfAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.Admins where a.Email_ID == emailID select a;

            List<Label> labelList = new List<Label>();
            labelList.Add(label1);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            labelList.Add(label8);
            labelList.Add(firstNameDB);
            labelList.Add(LastNameDB);
            labelList.Add(emailIdDB);
            labelList.Add(passwordDB);
            labelList.Add(contactNumberDB);
            labelList.Add(addressDB);
            labelList.Add(bloodGroupDB);
            labelList.Add(birthDateDB);
            labelList.Add(userID);
            labelList.Add(clearText);

            VisibilityOfLabel(labelList, true);

            labelList[8].Text = x.FirstOrDefault().First_Name;
            labelList[9].Text = x.FirstOrDefault().Last_Name;
            labelList[10].Text = x.FirstOrDefault().Email_ID;
            labelList[11].Text = x.FirstOrDefault().Password;
            labelList[12].Text = x.FirstOrDefault().Contact_Number;
            labelList[13].Text = x.FirstOrDefault().Address;
            labelList[14].Text = x.FirstOrDefault().Blood_Group;
            labelList[15].Text = ((x.FirstOrDefault().Birth_Date).ToShortDateString()).ToString();
            labelList[16].Text = "Admin ID: " + (x.FirstOrDefault().Id).ToString();
        }

        public static void VisibilityOfLabel(List<Label> labelList, bool value)
        {
            foreach(Label label in labelList)
            {
                label.Visible = value;
            }
        }

        private void DashBoardOfAdmin_Load(object sender, EventArgs e)
        {
            List<Label> labelList = new List<Label>();
            labelList.Add(label1);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            labelList.Add(label8);
            labelList.Add(firstNameDB);
            labelList.Add(LastNameDB);
            labelList.Add(emailIdDB);
            labelList.Add(passwordDB);
            labelList.Add(contactNumberDB);
            labelList.Add(addressDB);
            labelList.Add(bloodGroupDB);
            labelList.Add(birthDateDB);
            labelList.Add(clearText);

            foreach(Label label in labelList)
            {
                label.Visible = false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            List<Label> labelList = new List<Label>();
            labelList.Add(label1);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            labelList.Add(label8);
            labelList.Add(firstNameDB);
            labelList.Add(LastNameDB);
            labelList.Add(emailIdDB);
            labelList.Add(passwordDB);
            labelList.Add(contactNumberDB);
            labelList.Add(addressDB);
            labelList.Add(bloodGroupDB);
            labelList.Add(birthDateDB);
            labelList.Add(userID);
            labelList.Add(clearText);

            foreach (Label label in labelList)
            {
                label.Visible = false;
            }

            VisibilityOfLabel(labelList, false);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DoctorRegistrationForm(emailID).Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ViewOrDeleteDoctor(emailID).Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AdminProfileUpdate(emailID).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainWindowForm().Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DeletePatient(emailID).Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CreateAdmin(emailID).Show();
            this.Hide();
        }
    }
}
