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
    public partial class CreateAdmin : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public CreateAdmin()
        {
            InitializeComponent();
        }

        public CreateAdmin(string emailID)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            passwordText.MaxLength = 10;
            confirmPasswordText.PasswordChar = '*';
            confirmPasswordText.MaxLength = 10;
            this.emailID = emailID;
        }

        private void CreateAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            if (textBox1.Text == "")
            {
                MessageBox.Show("First Name must be filled up", "Notification");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Last Name must be filled up", "Notification");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Email id must be filled up", "Notification");
            }
            else if (passwordText.Text == "")
            {
                MessageBox.Show("Password text must be filled up", "Notification");
            }
            else if (confirmPasswordText.Text == "")
            {
                MessageBox.Show("Confirm password text must be filled up", "Notification");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please provide a contact number", "Notification");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Address must be filled up", "Notification");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select blood group", "Notification");
            }
            else if (passwordText.Text != confirmPasswordText.Text)
            {
                MessageBox.Show("Password mismatched", "Notification");
            }
            else
            {
                try
                {
                    Admin pt = new Admin
                    {
                        First_Name = textBox1.Text,
                        Last_Name = textBox2.Text,
                        Email_ID = textBox3.Text,
                        Password = passwordText.Text,
                        Contact_Number = textBox6.Text,
                        Address = textBox7.Text,
                        Blood_Group = comboBox1.Text,
                        Birth_Date = dateTimePicker1.Value,
                        //Photo = ConvertFileToByte(pictureBox2.ImageLocation)
                    };

                    List<CheckBox> listOfCheckBox = new List<CheckBox>();
                    listOfCheckBox.Add(checkBox1);
                    listOfCheckBox.Add(checkBox2);
                    listOfCheckBox.Add(checkBox3);

                    if (listOfCheckBox[0].Checked == true && listOfCheckBox[1].Checked == false && listOfCheckBox[2].Checked == false)
                    {
                        pt.Gender = "Male";
                    }
                    else if (listOfCheckBox[0].Checked == false && listOfCheckBox[1].Checked == true && listOfCheckBox[2].Checked == false)
                    {
                        pt.Gender = "Female";
                    }
                    else if (listOfCheckBox[0].Checked == false && listOfCheckBox[1].Checked == false && listOfCheckBox[2].Checked == true)
                    {
                        pt.Gender = "Other";
                    }

                    dp.Admins.InsertOnSubmit(pt);
                    dp.SubmitChanges();
                    label12.Text = "Information successfully updated";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetType().Name + ", " + ex.Message, "Query Result");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminDashBoard(emailID).Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

            foreach (string bloodGroup in bloodGroupList)
            {
                comboBox1.Items.Add(bloodGroup);
            }
        }
    }
}
