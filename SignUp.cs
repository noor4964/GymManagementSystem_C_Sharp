using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Gym_Management_System
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            signUpBtn.BackColor = Color.Transparent;
        }

        SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void gymTextBox3__TextChanged(object sender, EventArgs e)
        {

        }

        private void gymTextBox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox1.Checked)
            {
                gymTextBox1.PasswordChar = false;
            }
            else
            {
                gymTextBox1.PasswordChar = true;
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckbox2.Checked)
            {
                gymTextBox2.PasswordChar = false;
            }
            else
            {
                gymTextBox2.PasswordChar = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gymTextBox2__TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nametextBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void gymTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gymToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.FormClosed += (s, ev) => Application.Exit(); 
            welcomeForm.Show();
            this.Hide();
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {

        }

        private void gymTextBox6__TextChanged(object sender, EventArgs e)
        {

        }

        private void gymTextBox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = bunifuDatepicker1.Value;
            string previousDateString = selectedDate.ToShortDateString();
            string currentDateString = DateTime.Now.ToShortDateString();

            DateTime previousDate = DateTime.Parse(previousDateString);
            DateTime currentDate = DateTime.Parse(currentDateString);

            int yearDiff = currentDate.Year - previousDate.Year;

            string passWord = gymTextBox2.Texts.ToString();
            string confirmpassWord = gymTextBox1.Texts.ToString();

            if(!passWord.Equals(confirmpassWord))
            {
               MessageBox.Show("The password is not same as confirm password", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (yearDiff < 1)
            {
                MessageBox.Show("The Date of Birth should be atleast one year from current time", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string postalString = gymTextBox5.Texts.ToString();
            string weightString = gymTextBox6.Texts.ToString();
            string heightString = gymTextBox7.Texts.ToString();

            string pattern = @"^\d+'\s*\d+\""$";

            if(!Regex.IsMatch(heightString, pattern))
            {
                MessageBox.Show("The height should be in this format, Ex: 5' 8\"", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!int.TryParse(weightString, out int num1))
            {
                MessageBox.Show("The weight should be of type number", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!int.TryParse(postalString, out int num2))
            {
                MessageBox.Show("The postal code field should be of type number", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (gymComboBox1.SelectedIndex == -1 && nametextBox.Texts == "" && gymTextBox3.Texts == "" && gymTextBox4.Texts == "" && gymTextBox5.Texts == "" && gymTextBox2.Texts == "" && gymTextBox1.Texts == "" && gymComboBox2.SelectedIndex == -1 && gymTextBox6.Texts == "" && gymTextBox7.Texts == "")
            {
                MessageBox.Show("One or More field is empty", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime now = DateTime.Now;

            



            // More logic to enter the data in database
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            gymTextBox5.Texts = "";
            gymTextBox6.Texts = "";
            gymTextBox7.Texts = "";
            gymTextBox3.Texts = "";
            nametextBox.Texts = "";
            gymTextBox4.Texts = "";
            gymTextBox2.Texts = "";
            gymTextBox1.Texts = "";
            gymComboBox1.SelectedIndex = -1;
            gymComboBox2.SelectedIndex = -1;
            bunifuDatepicker1.Value = DateTime.Now;
        }


        private void gymComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

       
    }
}
