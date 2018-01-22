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
    public partial class DoctorProfile : MetroFramework.Forms.MetroForm
    {
        string emailID;
        List<TextBox> textBoxList = new List<TextBox>();
        public DoctorProfile()
        {
            InitializeComponent();
        }

        public DoctorProfile(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void DoctorProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DoctorProfile_Load(object sender, EventArgs e)
        {
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox8);

            DoctorClass.DoctorProfile(emailID, groupBox1,comboBox1, dateTimePicker1, textBoxList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorClass.DoctorProfileUpdate(emailID, textBoxList, comboBox1, dateTimePicker1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new DoctorDashBoard(emailID, DoctorClass.GetDoctorID(emailID)).Show();
            this.Hide();
        }
    }
}
