using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorPatientPortal
{
    class CheckUserTypeClass
    {
        public static void CheckIsAdminMethod(MainWindowForm mwf, TextBox textBox1, TextBox textBox2/*, bool isAdmin*/)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Admin ad = null;
            try
            {
                ad = dp.Admins.FirstOrDefault(adl => adl.Email_ID == textBox1.Text && adl.Password == textBox2.Text);
            }
            catch (Exception) { mwf.IsAdmin = false; }
            if (ad != null) { mwf.IsAdmin = true; }
        }

        public static void CheckIsDoctorMethod(MainWindowForm mwf, TextBox textBox1, TextBox textBox2)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Doctor d = null;
            try
            {
                d = dp.Doctors.FirstOrDefault(dl => dl.Email_ID == textBox1.Text && dl.Password == textBox2.Text);
            }
            catch (Exception) { mwf.IsDoctor = false; }
            if (d != null) { mwf.IsDoctor = true; }
        }

        public static void CheckIsPatientMethod(MainWindowForm mwf, TextBox textBox1, TextBox textBox2)
        {
            DoctorPatientDataContext dp = new DoctorPatientDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arwin\documents\visual studio 2015\Projects\CSharpProjects\DoctorPatientPortal\DoctorPatient.mdf;Integrated Security=True;Connect Timeout=30");

            Patient p = null;
            try
            {
                p = dp.Patients.FirstOrDefault(pl => pl.Email_ID == textBox1.Text && pl.Password == textBox2.Text);
            }
            catch (Exception) { mwf.IsPatient = false; }
            if (p != null) { mwf.IsPatient = true; }
        }
    }
}
