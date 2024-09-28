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

        SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=\"Gym Management System\";Integrated Security=True;");

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

            // Validate all fields first
            DateTime selectedDate = bunifuDatepicker1.Value;
            string previousDateString = selectedDate.ToShortDateString();
            string currentDateString = DateTime.Now.ToShortDateString();

            DateTime previousDate = DateTime.Parse(previousDateString);
            DateTime currentDate = DateTime.Parse(currentDateString);

            int yearDiff = currentDate.Year - previousDate.Year;

            string passWord = gymTextBox2.Texts.ToString();
            string confirmpassWord = gymTextBox1.Texts.ToString();

            if (!passWord.Equals(confirmpassWord))
            {
                MessageBox.Show("The password is not the same as the confirm password", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (yearDiff < 1)
            {
                MessageBox.Show("The Date of Birth should be at least one year from current time", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string postalString = gymTextBox5.Texts.ToString();
            string weightString = gymTextBox6.Texts.ToString();
            string heightString = gymTextBox7.Texts.ToString();

            string pattern = @"^\d+'\s*\d+\""$";
            if (!Regex.IsMatch(heightString, pattern))
            {
                MessageBox.Show("The height should be in this format, Ex: 5' 8\"", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(weightString, out int num1))
            {
                MessageBox.Show("The weight should be of type number", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(postalString, out int num2))
            {
                MessageBox.Show("The postal code field should be of type number", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gymComboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(nametextBox.Text) || string.IsNullOrEmpty(gymTextBox3.Texts) || string.IsNullOrEmpty(gymTextBox4.Texts) || string.IsNullOrEmpty(gymTextBox5.Texts) || string.IsNullOrEmpty(gymTextBox2.Texts) || string.IsNullOrEmpty(gymTextBox1.Texts) || gymComboBox2.SelectedIndex == -1 || string.IsNullOrEmpty(gymTextBox6.Texts) || string.IsNullOrEmpty(gymTextBox7.Texts))
            {
                MessageBox.Show("One or more fields are empty", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prepare the data for insertion
            string username = nametextBox.Text;
            string gender = gymComboBox2.SelectedItem.ToString();
            string email = gymTextBox3.Texts;
            string streetAddress = gymTextBox4.Texts;
            DateTime dateOfBirth = selectedDate;

            // Database insertion logic
            string insertQuery = @"INSERT INTO Sign_Up 
                           ([Username], [Password], [Confirm_Password], [Gender], [Weight], [Height], [Email], [Street_Address], [Postal_Code], [Date_of_Birth]) 
                           VALUES (@Username, @Password, @ConfirmPassword, @Gender, @Weight, @Height, @Email, @StreetAddress, @PostalCode, @DateOfBirth)";

            using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", passWord);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", confirmpassWord);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Weight", num1);
                        cmd.Parameters.AddWithValue("@Height", heightString);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@StreetAddress", streetAddress);
                        cmd.Parameters.AddWithValue("@PostalCode", num2);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sign Up Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    // Handle unique constraint violation for username
                    if (ex.Number == 2627) // SQL error code for unique constraint violation
                    {
                        MessageBox.Show("This username already exists. Please choose a different one.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Welcome welcome = new Welcome();
                    welcome.FormClosed += (s, ev) => Application.Exit();
                    welcome.Show();
                    this.Hide();
                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            gymTextBox5.Texts = "";
            gymTextBox6.Texts = "";
            gymTextBox7.Texts = "";
            gymTextBox3.Texts = "";
            nametextBox.Text = "";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                nametextBox.Text = "AD-"; // Admin prefix
         
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                nametextBox.Text = "ME-"; // Admin prefix
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end

            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                nametextBox.Text = "MG-"; // Admin prefix
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                nametextBox.Text = "TR-"; // Admin prefix
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end

            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                nametextBox.Text = "NU-"; // Admin prefix
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end

            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                nametextBox.Text = "SS-"; // Admin prefix
                nametextBox.SelectionStart = nametextBox.Text.Length; // Cursor at end

            }

        }

        private void nametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nametextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (nametextBox.SelectionStart < 3)
            {
                nametextBox.SelectionStart = nametextBox.Text.Length; // Move cursor after prefix
            }
        }

        private void nametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && nametextBox.SelectionStart <= 3)
            {
                e.SuppressKeyPress = true; // Prevent deletion of the prefix
            }
        }

        private void nametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nametextBox.SelectionStart < 3 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block input before the prefix
            }
        }

        private void gymTextBox3__TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
