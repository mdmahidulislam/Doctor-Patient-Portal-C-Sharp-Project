using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DoctorPatientPortal
{
    class PatientClass
    {
        public static void PatientLogIn(MainWindowForm mwf, string emailID, string password)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Patient pt = null;
            try
            {
                pt = dp.Patients.Single(ptl => ptl.Email_ID == emailID && ptl.Password == password);
            }
            catch (Exception)
            {
                MessageBox.Show("No data found on Database...Try agin.", "Query Result");
            }
            if (pt != null)
            {
                //MessageBox.Show("Login successful...", "Query Result");
                new PatientDashBoard(emailID).Show();
                mwf.Hide();
            }
        }

        public static void SearchDoctorsAvailabeTimeByPatient(TextBox textBox, DataGridView dataGridView)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
            DoctorAvailable da = null;
            try
            {
                da = dp.DoctorAvailables.FirstOrDefault(dal => dal.DoctorId == int.Parse(textBox.Text)); /*&& dal.CurrentDateTime==DateTime.Now.AddDays(1)*/
            }catch(Exception ex)
            {
                MessageBox.Show(ex.GetType().Name + ", " + ex.Message, "Query Result");
            }

            if (da != null)
            {
                //DateTime dateResult = DateTime.ParseExact(DateTime.Now.AddDays(1).ToShortDateString(), "dd/mmm/yy", CultureInfo.InvariantCulture);

                var x = from a in dp.DoctorAvailables where da.DoctorId == int.Parse(textBox.Text) /*&& da.CurrentDateTime == DateTime.Now.AddDays(1).ToShortDateString()*/ select a;
                dataGridView.DataSource = x.ToList();
                MessageBox.Show("Doctor Available Time Found", "Query Result");
                //MessageBox.Show((DateTime.ParseExact(DateTime.Now.AddDays(1).ToString(),"dd-mm-yy")).ToString());
            }
            if (da == null)
            {
                MessageBox.Show("Doctor Availabe time not found. Try with another id", "Query Result");
                dataGridView.DataSource = null;
                textBox.Clear();
            }
        }

        public static void PatientProfile(string emailID, GroupBox groupBox1,ComboBox comboBox1, DateTimePicker dateTimePicker1,List<TextBox> textBoxList)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                var x = from a in dp.Patients
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
                MessageBox.Show(ex.GetType().Name,"Exception Type");
            }
        }

        public static void PatientProfileUpdate(string emailID, GroupBox groupBox1, ComboBox comboBox1, DateTimePicker dateTimePicker1, List<TextBox> textBoxList)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                Patient ad = dp.Patients.FirstOrDefault(adml => adml.Email_ID.Equals(emailID)); //Email must be from constructor value
                ad.First_Name = textBoxList[0].Text;
                ad.Last_Name = textBoxList[1].Text;
                ad.Password = textBoxList[3].Text;
                ad.Contact_Number = textBoxList[4].Text;
                ad.Address = textBoxList[5].Text;
                ad.Blood_Group = comboBox1.Text;
                ad.Gender = textBoxList[6].Text;
                ad.Birth_Date = dateTimePicker1.Value;

                dp.SubmitChanges();
                MessageBox.Show("Information updated", "Result");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name, "Error Type");
            }
        }

        public static void ShowPatientBookingDetails(DataGridView dataGridView1, int PId)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.DoctorBookings where a.PId == PId select a;

            dataGridView1.DataSource = x.ToList();
        }

        public static int GetPatientID(string emailID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.Patients where a.Email_ID == emailID select a.Id;

            return x.FirstOrDefault();
        }

        public static void PatientBooking(DataGridView dataGridView1, int patientID)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            
        }

        public static void GetAllDoctorsId(DataGridView dataGridView2)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.Doctors select new { a.Id, a.First_Name };

            dataGridView2.DataSource = x.ToList();
        }

        public static void GetTimeList(ComboBox combobox1)
        {
            List<string> timeList = new List<string>();
            timeList.Add("8:00 AM");
            timeList.Add("9:00 AM");
            timeList.Add("10:00 AM");
            timeList.Add("11:00 AM");
            timeList.Add("12:00 PM");
            timeList.Add("1:00 AM");
            timeList.Add("2:00 AM");
            timeList.Add("3:00 AM");
            timeList.Add("4:00 AM");
            timeList.Add("5:00 AM");
            timeList.Add("6:00 AM");
            timeList.Add("7:00 AM");
            timeList.Add("8:00 AM");
            timeList.Add("9:00 AM");

            foreach (string time in timeList)
            {
                combobox1.Items.Add(time);
            }
        }

        public static void BookDoctorByPatient(int doctorId, int patientID, ComboBox comboBox)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            DoctorBooking db = null;
            try
            {
                db = new DoctorBooking()
                {
                    DrId = doctorId,
                    PId = patientID,
                    BookingTime = comboBox.Text,
                    BookingDate = DateTime.Now.AddDays(1).ToShortDateString()
                };

                dp.DoctorBookings.InsertOnSubmit(db);
                dp.SubmitChanges();

                MessageBox.Show("Booked successfully","Query Result");

            }catch(Exception)
            {
                MessageBox.Show("Failed to set the time", "Query Result");
            }
        }

        public static void GetDoctorsAvailableTime(DataGridView dataGridView1)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.DoctorAvailables select new { a.DoctorId, a.FromTime1, a.FromTime2, a.FromTime3, a.FromTime4, a.FromTime5, a.FromTime6, a.FromTime7, a.FromTime8, a.FromTime9, a.FromTime10, a.FromTime11, a.ToTime1, a.ToTime2, a.ToTime3, a.ToTime4, a.ToTime5, a.ToTime6, a.ToTime7, a.ToTime8, a.ToTime9, a.ToTime10, a.CurrentDateTime};

            dataGridView1.DataSource = x.ToList();
        }

        public static void ShowPatientDetails(DataGridView dataGridView1)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            var x = from a in dp.Patients select new { a.Id, a.First_Name, a.Last_Name };

            dataGridView1.DataSource = x.ToList();
        }
    }
}
