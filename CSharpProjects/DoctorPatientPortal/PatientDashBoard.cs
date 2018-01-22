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
    public partial class PatientDashBoard : MetroFramework.Forms.MetroForm
    {
        string emailID;
        public PatientDashBoard()
        {
            InitializeComponent();
        }

        public PatientDashBoard(string emailID)
        {
            InitializeComponent();
            this.emailID = emailID;
        }

        private void PatientDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainWindowForm().Show();
            this.Hide();
        }

        private void PatientDashBoard_Load(object sender, EventArgs e)
        {
            PatientClass.GetAllDoctorsId(dataGridView2);
            PatientClass.GetTimeList(comboBox1);
            PatientClass.GetDoctorsAvailableTime(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientClass.SearchDoctorsAvailabeTimeByPatient(textBox1, dataGridView1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PatientProfile(emailID).Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PatientAppoinmentDetails(emailID).Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //PatientClass.PatientBooking(dataGridView1, PatientClass.GetPatientID(emailID));
            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            //textBox3.Text =  dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //i = (int)dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value;

            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();

            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bool result = DoctorClass.DrIdValidOrNot(int.Parse(textBox1.Text));
            if (result == true)
            {
                PatientClass.BookDoctorByPatient(int.Parse(textBox1.Text), PatientClass.GetPatientID(emailID), comboBox1);
            }else
            {
                MessageBox.Show("Try with correct id from the list", "Query Result");
            }
        }
    }
}
