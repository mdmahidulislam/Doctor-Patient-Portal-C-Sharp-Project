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
    public partial class ViewOrDeleteDoctor : MetroFramework.Forms.MetroForm
    {
        string emailID, userID;
        public ViewOrDeleteDoctor()
        {
            InitializeComponent();
        }

        public ViewOrDeleteDoctor(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void ViewOrDeleteDoctor_Load(object sender, EventArgs e)
        {
            List<Label> labelList = new List<Label>();
            labelList.Add(label9);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            labelList.Add(label8);

            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox7);
            textBoxList.Add(textBox8);
            textBoxList.Add(textBox9);

            DoctorClass.HideOrEnabledDefaultDoctorProfileLabel(labelList, textBoxList, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userID = textBox1.Text;
            List<Label> labelList = new List<Label>();
            labelList.Add(label9);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            labelList.Add(label8);

            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox7);
            textBoxList.Add(textBox8);
            textBoxList.Add(textBox9);

            if (userID == "")
            {
                MessageBox.Show("You must provide an Doctor ID", "Notification");
                DoctorClass.HideOrEnabledDefaultDoctorProfileLabel(labelList, textBoxList, false);
            }
            else
            {
                DoctorClass.SearchDoctor(labelList, textBoxList, userID);
            }
        }

        private void ViewOrDeleteDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool getType = DoctorClass.DeleteDoctor(textBox1.Text);

            if (getType == true)
            {
                List<Label> labelList = new List<Label>();
                labelList.Add(label9);
                labelList.Add(label2);
                labelList.Add(label3);
                labelList.Add(label4);
                labelList.Add(label4);
                labelList.Add(label5);
                labelList.Add(label6);
                labelList.Add(label7);
                labelList.Add(label8);

                List<TextBox> textBoxList = new List<TextBox>();
                textBoxList.Add(textBox2);
                textBoxList.Add(textBox3);
                textBoxList.Add(textBox4);
                textBoxList.Add(textBox5);
                textBoxList.Add(textBox6);
                textBoxList.Add(textBox7);
                textBoxList.Add(textBox8);
                textBoxList.Add(textBox9);

                MessageBox.Show("User deleted successfully", "Query Result");
                DoctorClass.HideOrEnabledDefaultDoctorProfileLabel(labelList, textBoxList, false);
                textBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AdminDashBoard(emailID).Show();
            this.Hide();
        }
    }
}
