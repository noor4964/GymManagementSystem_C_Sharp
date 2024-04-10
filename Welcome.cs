using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gymTextBox1__TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Text Changed");
        }

   
        private void gymTextBox1__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gymTextBox2__TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(gymTextBox1.Texts == "" && gymTextBox2.Texts == "")
            {
                MessageBox.Show("One or more Text Field is empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if(!bunifuCheckbox1.Checked)
            {
                gymTextBox2.PasswordChar = false;
            } else
            {
                gymTextBox2.PasswordChar = true;
            }
        }

        private void gymToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            SignUp signForm = new SignUp();
            signForm.FormClosed += (s, ev) => Application.Exit();
            signForm.Show();
            this.Hide();
        }
    }
}
