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
    public partial class PatientProfile : MetroFramework.Forms.MetroForm
    {
        string emailID;
        
        public PatientProfile()
        {
            InitializeComponent();
        }

        public PatientProfile(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox8);

            PatientClass.PatientProfileUpdate(emailID, groupBox1, comboBox1, dateTimePicker1, textBoxList);
        }

        private void PatientProfile_Load(object sender, EventArgs e)
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox8);

            PatientClass.PatientProfile(emailID, groupBox1, comboBox1, dateTimePicker1, textBoxList);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new PatientDashBoard(emailID).Show();
            this.Hide();
        }

        private void PatientProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
