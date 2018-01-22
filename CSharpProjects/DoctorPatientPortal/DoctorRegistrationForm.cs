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
    public partial class DoctorRegistrationForm : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public DoctorRegistrationForm()
        {
            InitializeComponent();
            HidePassword();
        }

        public DoctorRegistrationForm(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
            HidePassword();
        }

        private void DoctorRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminDashBoard(emailID).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(passwordText);
            textBoxList.Add(confirmPasswordText);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox7);

            List<CheckBox> checkBoxList = new List<CheckBox>();
            checkBoxList.Add(checkBox1);
            checkBoxList.Add(checkBox2);
            checkBoxList.Add(checkBox3);

            AdminClass.CreateDoctor(textBoxList, comboBox1, checkBoxList, dateTimePicker1/*, pictureBox2*/);
        }

        public void HidePassword()
        {
            passwordText.PasswordChar = '*';
            passwordText.MaxLength = 10;
            confirmPasswordText.PasswordChar = '*';
            confirmPasswordText.MaxLength = 10;
        }

        private void DoctorRegistrationForm_Load(object sender, EventArgs e)
        {
            List<string> bloodGroupList = new List<string>();
            bloodGroupList.Add("A (+ve)");
            bloodGroupList.Add("A (-ve)");
            bloodGroupList.Add("AB (+ve)");
            bloodGroupList.Add("AB (-ve)");
            bloodGroupList.Add("B (+ve)");
            bloodGroupList.Add("B (-ve)");
            bloodGroupList.Add("O (+ve)");
            bloodGroupList.Add("O (ve-)");
            bloodGroupList.Add("Unknown");

            foreach(string bloodGroup in bloodGroupList)
            {
                comboBox1.Items.Add(bloodGroup);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG|*.jpg|PNG|*.png|GIF|*gif";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = ofd.FileName;
                    //pictureBox2.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
