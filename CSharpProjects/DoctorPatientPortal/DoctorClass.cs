using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorPatientPortal
{
    class DoctorClass
    {
        public static void HideOrEnabledDefaultDoctorProfileLabel(List<Label> labelList, List<TextBox> textBoxList, bool falseOrTrue)
        {
            foreach (Label label in labelList)
            {
                label.Visible = falseOrTrue;
            }

            foreach (TextBox textBox in textBoxList)
            {
                textBox.Visible = falseOrTrue;
                textBox.Clear();
            }
        }

        public static int GetDoctorID(string emailID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
            var x = from a in dp.Doctors where a.Email_ID == emailID select a;
            int drId = x.FirstOrDefault().Id;
            return drId;
        }

        public static void SearchDoctor(List<Label> labelList, List<TextBox> textBoxList, string userID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var StringQuery = from a in dp.Doctors where a.Id == int.Parse(userID) select a;

                foreach (TextBox textBox in textBoxList)
                {
                    textBox.Enabled = false;
                }

                HideOrEnabledDefaultDoctorProfileLabel(labelList, textBoxList, true);
                textBoxList[0].Text = StringQuery.FirstOrDefault().First_Name;
                textBoxList[1].Text = StringQuery.FirstOrDefault().Last_Name;
                textBoxList[2].Text = StringQuery.FirstOrDefault().Email_ID;
                textBoxList[3].Text = StringQuery.FirstOrDefault().Password;
                textBoxList[4].Text = StringQuery.FirstOrDefault().Contact_Number;
                textBoxList[5].Text = StringQuery.FirstOrDefault().Address;
                textBoxList[6].Text = StringQuery.FirstOrDefault().Blood_Group;
                textBoxList[7].Text = (StringQuery.FirstOrDefault().Birth_Date).ToShortDateString();
                MessageBox.Show("Doctor found", "Query Result");
            }
            catch (Exception)
            {
                foreach (Label label in labelList)
                {
                    label.Visible = false;
                }
                foreach (TextBox textBox in textBoxList)
                {
                    textBox.Visible = false;
                    textBox.Clear();
                }
                MessageBox.Show("No data found on the database...", "Query Result");
            }
        }

        public static bool DeleteDoctor(string userID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                Doctor d = dp.Doctors.FirstOrDefault(dl => dl.Id.Equals(userID));

                dp.Doctors.DeleteOnSubmit(d);
                dp.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("No data found on the database...", "Query Result");
                return false;
            }
        }

        public static void DoctorLogIn(MainWindowForm mwf, string emailID, string password)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Doctor d = null;
            try
            {
                d = dp.Doctors.Single(ptl => ptl.Email_ID == emailID && ptl.Password == password);
            }
            catch (Exception)
            {
                MessageBox.Show("No data found on Database...Try agin.", "Query Result");
            }
            if (d != null)
            {
                //MessageBox.Show("Login successful...", "Query Result");
                new DoctorDashBoard(emailID, d.Id).Show();
                mwf.Hide();
            }
        }

        public static void DoctorAvailableTimeSet(List<string> timeList1, List<string> timeList2, ComboBox comboBox1, ComboBox comboBox2)
        {
            foreach (string time in timeList1)
            {
                comboBox1.Items.Add(time);
            }

            foreach (string time in timeList2)
            {
                comboBox2.Items.Add(time);
            }
        }

        public static void DoctorAvailableTimeSetToDB(string emailID, string fromTime, string toTime, int drID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            List<string> fromTimeList = new List<string>();
            fromTimeList.Add("8:00 AM");
            fromTimeList.Add("9:00 AM");
            fromTimeList.Add("10:00 AM");
            fromTimeList.Add("11:00 AM");
            fromTimeList.Add("12:00 PM");
            fromTimeList.Add("1:00 PM");
            fromTimeList.Add("2:00 PM");
            fromTimeList.Add("3:00 PM");
            fromTimeList.Add("4:00 PM");
            fromTimeList.Add("5:00 PM");
            fromTimeList.Add("6:00 PM");

            List<string> toTimeList = new List<string>();
            toTimeList.Add("12:00 PM");
            toTimeList.Add("1:00 PM");
            toTimeList.Add("2:00 PM");
            toTimeList.Add("3:00 PM");
            toTimeList.Add("4:00 PM");
            toTimeList.Add("5:00 PM");
            toTimeList.Add("6:00 PM");
            toTimeList.Add("7:00 PM");
            toTimeList.Add("8:00 PM");
            toTimeList.Add("9:00 PM");

            string[] arrayList = new string[11];
            int i = 0, l = 0;
            foreach (string f in fromTimeList)
            {
                arrayList[i] = f;
                i++;
            }

            for (int j = 0; j < arrayList.Length; j++)
            {
                if (arrayList[j] == fromTime)
                {
                    l = j;
                }
            }
            for (int m = 0; m < l; m++)
            {
                arrayList[m] = "";
            }

            //new area 2

            string[] arrayList2 = new string[10];
            int i2 = 0, l2 = 0;
            foreach (string f in toTimeList)
            {
                arrayList2[i2] = f;
                i2++;
            }

            for (int kk = 0; kk < arrayList2.Length; kk++)
            {
                if (arrayList2[kk] == arrayList[arrayList.Length - 1])
                {
                    l2 = arrayList2[kk].Length;
                }
            }

            for (int m = 0; m < l2; m++)
            {
                arrayList2[m] = "";
            }

            int s1 = 0;
            for (int s = 0; s < arrayList2.Length; s++)
            {
                if (arrayList2[s] == toTime)
                {
                    s1 = s;
                }
            }

            for (int s3 = arrayList2.Length-1; s3 > s1; s3--)
            {
                arrayList2[s3] = "";
            }
            string dt;
            DoctorAvailable ad = null;
            try
            {
                ad = new DoctorAvailable();

                ad.DoctorId = drID;
                ad.CurrentDateTime = dt = DateTime.Now.AddDays(1).ToShortDateString();
                ad.FromTime1 = arrayList[0];
                ad.FromTime2 = arrayList[1];
                ad.FromTime3 = arrayList[2];
                ad.FromTime4 = arrayList[3];
                ad.FromTime5 = arrayList[4];
                ad.FromTime6 = arrayList[5];
                ad.FromTime7 = arrayList[6];
                ad.FromTime8 = arrayList[7];
                ad.FromTime9 = arrayList[8];
                ad.FromTime10 = arrayList[9];
                ad.FromTime11 = arrayList[10];

                ad.ToTime1 = arrayList2[0];
                ad.ToTime2 = arrayList2[1];
                ad.ToTime3 = arrayList2[2];
                ad.ToTime4 = arrayList2[3];
                ad.ToTime5 = arrayList2[4];
                ad.ToTime6 = arrayList2[5];
                ad.ToTime7 = arrayList2[6];
                ad.ToTime8 = arrayList2[7];
                ad.ToTime9 = arrayList2[8];
                ad.ToTime10 = arrayList2[9];

                dp.DoctorAvailables.InsertOnSubmit(ad);
                dp.SubmitChanges();
                MessageBox.Show("Available time set successfully...", "Query Result");

            }
            catch (Exception ex)
            {
                MessageBox.Show("c1" + ex.GetType().Name + ex.Message, "Query Result");
            }
        }

        public static void ShowDoctorBookingHistory(DataGridView dataGridView, int drID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                var x = from a in dp.DoctorBookings where a.DrId == drID select a;

                dataGridView.DataSource = x.ToList();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.GetType().Name + ", " + ex.Message,"Query Result");
            }
        }

        public static void DoctorProfile(string emailID, GroupBox groupBox1,ComboBox comboBox1, DateTimePicker dateTimePicker1, List<TextBox> textBoxList)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                var x = from a in dp.Doctors
                        where a.Email_ID == emailID
                        select a;

                //Admin ad = dp.Admins.Single(adml => adml.Email_ID == emailID);

                groupBox1.Text = "User ID: " + Convert.ToString(x.FirstOrDefault().Id);

                textBoxList[0].Text = x.FirstOrDefault().First_Name;
                textBoxList[1].Text = x.FirstOrDefault().Last_Name;
                textBoxList[2].Text = x.FirstOrDefault().Email_ID;
                textBoxList[3].Text = x.FirstOrDefault().Password;
                textBoxList[4].Text = x.FirstOrDefault().Contact_Number;
                textBoxList[5].Text = x.FirstOrDefault().Address;
                comboBox1.Text = x.FirstOrDefault().Blood_Group;
                textBoxList[6].Text = x.FirstOrDefault().Gender;
                dateTimePicker1.Text = Convert.ToString(x.FirstOrDefault().Birth_Date);
                //byte[] img;

                //img = (byte[])(ad.Photo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
            }

        }

        public static void DoctorProfileUpdate(string emailID, List<TextBox> textBoxList, ComboBox comboBox1, DateTimePicker dateTimePicker1)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                Doctor dr = dp.Doctors.FirstOrDefault(drl => drl.Email_ID.Equals(emailID)); //Email must be from constructor value
                dr.First_Name = textBoxList[0].Text;
                dr.Last_Name = textBoxList[1].Text;
                dr.Password = textBoxList[3].Text;
                dr.Contact_Number = textBoxList[4].Text;
                dr.Address = textBoxList[5].Text;
                dr.Blood_Group = comboBox1.Text;
                dr.Gender = textBoxList[6].Text;
                dr.Birth_Date = dateTimePicker1.Value;

                dp.SubmitChanges();

                MessageBox.Show("Dr. information updated", "Result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name + ", " + ex.Message);
            }
        }

        public static bool DrIdValidOrNot(int drId)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Doctor d = null;
            try
            {
                d = dp.Doctors.Single(ptl => ptl.Id == drId);
                return true;
            }
            catch (Exception) { return false; }
        }

        public static void DeletePatient(int PatientID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                Patient p = dp.Patients.FirstOrDefault(dl => dl.Id.Equals(PatientID));

                dp.Patients.DeleteOnSubmit(p);
                dp.SubmitChanges();
                MessageBox.Show("Patient Deleted", "Query Result");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found on the database..." + ex.GetType().Name + ex.Message, "Query Result");
            }
        }
    }
}
