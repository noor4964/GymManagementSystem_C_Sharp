using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym_Management_System
{
    public partial class Welcome : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");
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
            if (string.IsNullOrEmpty(gymTextBox1.Texts) || string.IsNullOrEmpty(gymTextBox2.Texts))
            {
                MessageBox.Show("One or more Text Field is empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT Username, Password FROM Sign_Up WHERE Username=@Username AND Password=@Password";

            using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@Username", gymTextBox1.Texts);
                        cmd.Parameters.AddWithValue("@Password", gymTextBox2.Texts);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read()) // Login success
                        {
                            string username = gymTextBox1.Texts;

                            if (username.StartsWith("ME-"))
                            {
                                //LoadUserPhoto(username);
                                //MessageBox.Show("Welcome Member!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Redirect to Member interface
                                Member member = new Member(username);
                                member.Show();
                                this.Hide();
                            }
                            else if (username.StartsWith("AD-"))
                            {
                                MessageBox.Show("Welcome Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Redirect to Admin interface
                            }
                            else if (username.StartsWith("MG-"))
                            {
                                //MessageBox.Show("Welcome Manager!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ManagerForm manager = new ManagerForm(username);
                                manager.Show();
                                this.Hide();

                                // Redirect to Manager interface
                            }
                            else if (username.StartsWith("TR-"))
                            {
                                //MessageBox.Show("Welcome Trainer!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Redirect to Trainer interface
                                Trainer trainer = new Trainer(username);
                                trainer.Show();
                                this.Hide();
                            }
                            else if (username.StartsWith("SS-"))
                            {
                                //MessageBox.Show("Welcome Service Staff!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Redirect to Service Staff interface
                            }
                            else if (username.StartsWith("NU-"))
                            {
                                //MessageBox.Show("Welcome Nutritionist!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Redirect to Nutritionist interface
                            }
                            else
                            {
                                MessageBox.Show("Invalid Role Prefix!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else // Login failed
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            gymTextBox2.PasswordChar = !bunifuCheckbox1.Checked;
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
