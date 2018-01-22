using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoctorPatientPortal
{
    class AdminClass
    {
        public static void AdminLogin(MainWindowForm mwf, string emailID, string password)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
            Admin ad = null;
            try
            {
                ad = dp.Admins.Single(adml => adml.Email_ID == emailID && adml.Password == password);
            }
            catch (Exception)
            {
                MessageBox.Show("No data found on Database...Try agin.", "Query Result");
            }
            if (ad != null)
            {
                //MessageBox.Show("Login successful...", "Query Result");
                new AdminDashBoard(emailID).Show();
                mwf.Hide();
            }
        }

        public static void CreateDoctor(List<TextBox> textBoxList, ComboBox comboBox, List<CheckBox> checkBoxList, DateTimePicker dateTimePicker1/*, PictureBox photo*/)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            if (textBoxList[0].Text == string.Empty)
            {
                MessageBox.Show("First Name must be filled up", "Notification");
            }
            else if (textBoxList[1].Text == string.Empty)
            {
                MessageBox.Show("Last Name must be filled up", "Notification");
            }
            else if (textBoxList[2].Text == string.Empty)
            {
                MessageBox.Show("Email ID must be filled up", "Notification");
            }
            else if (textBoxList[5].Text == string.Empty)
            {
                MessageBox.Show("Contact number must be filled up", "Notification");
            }
            else if (textBoxList[6].Text == string.Empty)
            {
                MessageBox.Show("Address must be filled up", "Notification");
            }
            else if (textBoxList[3].Text != textBoxList[4].Text)
            {
                MessageBox.Show("Password Mismatched", "Notification");
            }
            else if (textBoxList[3].Text == string.Empty)
            {
                MessageBox.Show("Enter password", "Notification");
            }
            else if (textBoxList[4].Text == string.Empty)
            {
                MessageBox.Show("Enter confirm password", "Notification");
            }
            else if (comboBox.Text == string.Empty)
            {
                MessageBox.Show("Please select Blood Group", "Notification");
            }
            else if ((checkBoxList.ElementAt(0).Checked == true && checkBoxList.ElementAt(1).Checked == true && checkBoxList.ElementAt(2).Checked == true) || (checkBoxList.ElementAt(0).Checked == true && checkBoxList.ElementAt(1).Checked == true) || (checkBoxList.ElementAt(1).Checked == true && checkBoxList.ElementAt(2).Checked == true) || (checkBoxList.ElementAt(0).Checked == true && checkBoxList.ElementAt(2).Checked == true))
            {
                MessageBox.Show("Please select a check box", "Notification");
            }
            else if (checkBoxList.ElementAt(0).Checked == false && checkBoxList.ElementAt(1).Checked == false && checkBoxList.ElementAt(2).Checked == false)
            {
                MessageBox.Show("Please select a gender", "Notification");
            }
            else
            {
                try
                {
                    Doctor d = new Doctor
                    {
                        First_Name = textBoxList[0].Text,
                        Last_Name = textBoxList[1].Text,
                        Email_ID = textBoxList[2].Text,
                        Password = textBoxList[3].Text,
                        Contact_Number = textBoxList[5].Text,
                        Address = textBoxList[6].Text,
                        Blood_Group = comboBox.Text,
                        Birth_Date = dateTimePicker1.Value,
                        //Photo = ConvertFileToByte(photo.ImageLocation)
                    };

                    if (checkBoxList.ElementAt(0).Checked == true && checkBoxList.ElementAt(1).Checked == false && checkBoxList.ElementAt(2).Checked == false)
                    {
                        d.Gender = "Male";
                    }
                    else if (checkBoxList.ElementAt(0).Checked == false && checkBoxList.ElementAt(1).Checked == true && checkBoxList.ElementAt(2).Checked == false)
                    {
                        d.Gender = "Female";
                    }
                    else if (checkBoxList.ElementAt(0).Checked == false && checkBoxList.ElementAt(1).Checked == false && checkBoxList.ElementAt(2).Checked == true)
                    {
                        d.Gender = "Other";
                    }

                    dp.Doctors.InsertOnSubmit(d);
                    dp.SubmitChanges();
                    MessageBox.Show("Doctor added successfully", "Query Result");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registration failed. Try again", "Query Result");
                    MessageBox.Show("Error Type: " + ex.GetType().Name + " " + ex.Message, "Query Result");
                }
            }
        }

        public static byte[] ConvertFileToByte(string path)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(path);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
