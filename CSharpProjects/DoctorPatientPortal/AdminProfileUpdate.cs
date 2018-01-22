using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoctorPatientPortal
{
    public partial class AdminProfileUpdate : MetroFramework.Forms.MetroForm
    {
        DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
        string emailID;
        public AdminProfileUpdate()
        {
            InitializeComponent();
        }
        public AdminProfileUpdate(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new AdminDashBoard(emailID).Show();
            this.Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                var x = from a in dp.Admins
                        where a.Email_ID == emailID
                        select a;

                //Admin ad = dp.Admins.Single(adml => adml.Email_ID == emailID);

                groupBox1.Text = "User ID: " + Convert.ToString(x.FirstOrDefault().Id);

                textBox1.Text = x.FirstOrDefault().First_Name;
                textBox2.Text = x.FirstOrDefault().Last_Name;
                textBox3.Text = x.FirstOrDefault().Email_ID;
                textBox4.Text = x.FirstOrDefault().Password;
                textBox5.Text = x.FirstOrDefault().Contact_Number;
                textBox6.Text = x.FirstOrDefault().Address;
                comboBox1.Text = x.FirstOrDefault().Blood_Group;
                textBox8.Text = x.FirstOrDefault().Gender;
                dateTimePicker1.Text = Convert.ToString(x.FirstOrDefault().Birth_Date);
                //byte[] img;

                //img = (byte[])(ad.Photo);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
            }
        }

        private Image ConvertByteToImage(byte[] photo)
        {
            //Image newImage;

            //using (MemoryStream ms = new MemoryStream(photo, 0, photo.Length))
            //{
            //    ms.Write(photo, 0, photo.Length);
            //    newImage = Image.FromStream(ms, true);
            //}
            //return newImage;
            using (MemoryStream ms = new MemoryStream(photo))
            {
                return Image.FromStream(ms);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Admin ad = dp.Admins.FirstOrDefault(adml => adml.Email_ID.Equals(emailID)); //Email must be from constructor value
                ad.First_Name = textBox1.Text;
                ad.Last_Name = textBox2.Text;
                ad.Password = textBox4.Text;
                ad.Contact_Number = textBox5.Text;
                ad.Address = textBox6.Text;
                ad.Blood_Group = comboBox1.Text;
                ad.Gender = textBox8.Text;
                ad.Birth_Date = dateTimePicker1.Value;

                dp.SubmitChanges();
                MessageBox.Show("Information updated", "Result");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
            }
        }
    }
}
