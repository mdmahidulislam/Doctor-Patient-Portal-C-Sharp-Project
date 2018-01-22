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
    public partial class MainWindowForm : MetroFramework.Forms.MetroForm
    {
        bool isAdmin=false, isDoctor=false, isPatient=false;
        public bool IsAdmin
        {
            set { this.isAdmin = value; }
            get { return this.isAdmin; }
        }
        public bool IsDoctor
        {
            set { this.isDoctor = value; }
            get { return this.isDoctor; }
        }
        public bool IsPatient
        {
            set { this.isPatient = value; }
            get { return this.isPatient; }
        }
        public MainWindowForm()
        {
            InitializeComponent();

            passwordText.PasswordChar = '*';
            passwordText.MaxLength = 10;

            timer1.Start();
        }
        //public MainWindowForm(string valueOfEmailID)
        //{
        //    InitializeComponent();
        //    passwordText.PasswordChar = '*';
        //    passwordText.MaxLength = 10;
        //}

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "?")
            {
                label6.Text = "Max character length 10";
            }
            else
            {
                label6.Text = "?";
            }
        }
        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            List<string> userList = new List<string>();
            userList.Add("Admin");
            userList.Add("Doctor");
            userList.Add("Patient");

            foreach (string user in userList)
            {
                comboBox1.Items.Add(user);
            }

            textBox1.Clear();
            passwordText.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PatientRegistrationForm().Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label8.Text = "Current Date and Time: " + dt.ToString();
        }

        private void MainWindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CheckUserTypeClass.CheckIsAdminMethod(this, textBox1, passwordText/*,isAdmin*/);
            /*isDoctor = */CheckUserTypeClass.CheckIsDoctorMethod(this, textBox1, passwordText);
            /*isPatient = */CheckUserTypeClass.CheckIsPatientMethod(this, textBox1, passwordText);

            //MessageBox.Show(isAdmin.ToString() + " " + isDoctor.ToString() + " " + isPatient.ToString());


            if (isAdmin == true && isDoctor == false && isPatient == false)
            {
                AdminClass.AdminLogin(this, textBox1.Text, passwordText.Text);
            }
            else if (isAdmin == false && isDoctor == true && isPatient == false)
            {
                DoctorClass.DoctorLogIn(this, textBox1.Text, passwordText.Text);
            }
            else if (isAdmin == false && isDoctor == false && isPatient == true)
            {
                PatientClass.PatientLogIn(this, textBox1.Text, passwordText.Text);
            }
            else
            {
                MessageBox.Show("Login failed...", "Query Result");
            }
        }
    }
}
