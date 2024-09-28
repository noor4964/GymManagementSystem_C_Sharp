using Gym_Management_System.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Gym_Management_System
{
    public partial class ManagerForm : Form
    {
        private string managerID;
        public static string amountManager;

        public ManagerForm(string managerID):this()
        {
            InitializeComponent();
            // Store the manager ID passed from the login form
            this.managerID = managerID;

            // Set the Manager ID text box or label when form is initialized
            label3.Text = managerID;
        }
        public ManagerForm()
        {
            InitializeComponent();
            Color deepRed = Color.FromArgb(128, 0, 32);
            Color maroon = Color.FromArgb(128, 0, 0);
            Color darkCherry = Color.FromArgb(255, 127, 127);
            Color black = Color.FromArgb(0, 0, 0);
            Color brickRed = Color.FromArgb(178, 34, 34);
            Color white = Color.FromArgb(255, 255, 255);

            Color blendedColor = BlendColors(maroon, black);

            Color header = BlendColors(darkCherry, brickRed, deepRed);

            headerBar.BackColor = header;
            headerBarSalary.BackColor = header;
            headerBarFees.BackColor = header;
            hearderBarEmployee.BackColor = header;

            panel1.BackColor = header;
            panel2.BackColor = header;
        }

        private Color BlendColors(params Color[] colors)
        {
            int r = 0, g = 0, b = 0, a = 0;

            foreach (Color color in colors)
            {
                r += color.R;
                g += color.G;
                b += color.B;
                a += color.A;
            }

            int count = colors.Length;
            return Color.FromArgb(a / count, r / count, g / count, b / count);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            profilePanelManager.Visible = true;
            recordsPanel.Visible = false;
            salaryPanel.Visible = false;

        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanel.Visible = true;
            profilePanelManager.Visible = false;
            salaryPanel.Visible = false;
        }

        private void salaryBtn_Click(object sender, EventArgs e)
        {
            salaryPanel.Visible = true;
            feesPanel.Visible = false;
        }

        private void memberFeebtn_Click(object sender, EventArgs e)
        {
            feesPanel.Visible = true;
            employeePanel.Visible = false;
        }

        private void addEmployeebtn_Click(object sender, EventArgs e)
        {
            employeePanel.Visible = true;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }




        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadUserPhoto();
            gymTextBox1.Text = BKashTransaction.bkashAmount;
           


            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet15.Employee_Salary' table. You can move, or remove it, as needed.
           // this.employee_SalaryTableAdapter2.Fill(this.gym_Management_SystemDataSet15.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet14.MemberTransactions' table. You can move, or remove it, as needed.
            //this.memberTransactionsTableAdapter3.Fill(this.gym_Management_SystemDataSet14.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet4.Employee_Salary' table. You can move, or remove it, as needed.
            ////this.employee_SalaryTableAdapter1.Fill(this.gym_Management_SystemDataSet4.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet3.MemberTransactions' table. You can move, or remove it, as needed.
            /////this.memberTransactionsTableAdapter2.Fill(this.gym_Management_SystemDataSet3.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet2.MemberTransactions' table. You can move, or remove it, as needed.
            //this.memberTransactionsTableAdapter1.Fill(this.gym_Management_SystemDataSet2.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet1.MemberTransactions' table. You can move, or remove it, as needed.
            //this.memberTransactionsTableAdapter.Fill(this.gym_Management_SystemDataSet1.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet.Employee_Salary' table. You can move, or remove it, as needed.
            //this.employee_SalaryTableAdapter.Fill(this.gym_Management_SystemDataSet.Employee_Salary);

            // Dynamically set the Manager ID in the text field or label
            if (!string.IsNullOrEmpty(managerID))
            {
                label3.Text = managerID;  // Set Manager ID in text box
            }
            else
            {
                MessageBox.Show("Manager ID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
         
        }

        private void headerBarSalary_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void gymTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void gymComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Get values from the input fields
            DateTime selectedDate = Age.Value; // Assuming Age is a DateTimePicker
            string username = textBox1.Text; // Username
            string password = gymTextBox7.Text; // Password
            string confirmPassword = gymTextBox2.Text; // Confirm Password
            string email = gymTextBox5.Text; // Email
            string streetAddress = gymTextBox6.Text; // Street Address
            string salary = gymTextBox4.Text; // Salary as string



            // Check if Password and Confirm Password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure date of birth is valid (you might want to add your validation logic here)

            // Define the SQL connection string (replace with your actual connection string)
            string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;";

            // SQL query to insert a new employee record into the Sign_Up table
            string query = "INSERT INTO Sign_Up (Username, Password, Confirm_Password, Email, Street_Address, Date_of_Birth) " +
                           "VALUES (@Username, @Password, @ConfirmPassword, @Email, @Street_Address, @Date_of_Birth)";

            // Create the SQL connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // You might want to hash the password for security
                    command.Parameters.AddWithValue("@ConfirmPassword", confirmPassword);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Street_Address", streetAddress);
                    command.Parameters.AddWithValue("@Date_of_Birth", selectedDate);
                   // command.Parameters.AddWithValue("@Salary", salary);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int result = command.ExecuteNonQuery();

                        // Check if the insertion was successful
                        if (result > 0)
                        {
                            MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, clear the input fields after successful insertion
                            // ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Error adding employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL-specific errors
                        MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Handle any other errors that may occur
                        MessageBox.Show($"Error: {ex.Message}", "General Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        // Optional: Method to clear input fields after successful insertion
        /*private void ClearInputFields()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxEmail.Clear();
            textBoxAge.Clear();
            textBoxAddress.Clear();
            textBoxSalary.Clear();
        }*/



























        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton31.Checked)
            {
                textBox1.Text = "TR-"; // Admin prefix

                textBox1.SelectionStart = nametextBox.Text.Length; // Cursor at end
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton41.Checked)
            {
                textBox1.Text = "NU-"; // Admin prefix

                textBox1.SelectionStart = nametextBox.Text.Length; // Cursor at end
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton61.Checked)
            {
                textBox1.Text = "SS-"; // Admin prefix

                textBox1.SelectionStart = nametextBox.Text.Length; // Cursor at end
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.SelectionStart < 3)
            {
                textBox1.SelectionStart = nametextBox.Text.Length; // Move cursor after prefix
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && textBox1.SelectionStart <= 3)
            {
                e.SuppressKeyPress = true; // Prevent deletion of the prefix
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox1.SelectionStart < 3 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block input before the prefix
            }
        }

        private void employeeBorder_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InsertSalaryTransaction(string employeeId, string transactionId, string amount, string status, DateTime payDate)
        {
            // Assuming you are using ADO.NET for database connection
            string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"; // Update with your connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO employee_Salary (Employee_ID, Transaction_ID, Salary, Status, Pay_Date) " +
                               "VALUES (@EmployeeId, @TransactionId, @Salary, @Status, @PayDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@TransactionId", transactionId);
                    command.Parameters.AddWithValue("@Salary", amount);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@PayDate", payDate);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Salary transaction inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Transaction ID generate
        public string GenerateTransactionId()
        {
            // You can use a simple random number generator to generate the transaction ID
            Random random = new Random();
            string transactionId = "TXN-" + random.Next(100000, 999999).ToString(); // Format: TXN-123456
            return transactionId;
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            

            // Get the selected Employee ID, Employee Type, Date from DatePicker, and Amount as string
            string employeeId = nametextBox.Texts; // Assuming you have a TextBox for Employee ID
            string employeeType = gymComboBox1.SelectedItem.ToString(); // Assuming you have a ComboBox for Employee Type
            DateTime payDate = bunifuDatepicker1.Value; // Assuming you have a DateTimePicker
            string amountText = gymTextBox1.Texts; // Get the amount as a string

            // Ensure that the amountText is not empty before proceeding
            if (!string.IsNullOrWhiteSpace(amountText))
            {
                // Navigate to Bkash Transaction Form
                amountManager = gymTextBox1.Text;

                BKashTransaction bkashForm = new BKashTransaction();

                // Pass the data to the Bkash Transaction Form
                bkashForm.SetTransactionDetails(employeeId, amountText, payDate);

                // Show the Bkash Transaction Form
                bkashForm.ShowDialog(); // Modal dialog to wait for user action

                // Assuming the Bkash form will set the transaction ID and status after confirming the transaction
                if (bkashForm.TransactionConfirmed)
                {
                    string transactionId = GenerateTransactionId(); // Generate the transaction ID
                    string status = "Completed"; // You can customize the status

                    // Insert the transaction details into employee_Salary table
                    InsertSalaryTransaction(employeeId, transactionId, amountText, status, payDate);
                }
                else
                {
                    MessageBox.Show("Transaction was not completed.", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a salary amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void employeePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InsertPhotoToDatabase(object userId, byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserPhoto (ID, Photo) VALUES (@ID, @Photo)", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", userId);
                    cmd.Parameters.AddWithValue("@Photo", imageBytes);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void LoadUserPhoto(int userId)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Photo FROM UserPhoto WHERE UserID = @UserID", conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    byte[] imageBytes = (byte[])cmd.ExecuteScalar();

                    if (imageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }

        // Method to insert or update the photo in the UserPhoto table
        private void InsertPhotoToDatabase(string userId, byte[] imageBytes)
        {
            try
            {
                // Remove '#' from userId if needed
                userId = userId.Replace("#", "");

                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // Check if the user already has a photo in the database
                    string query = @"
                        IF EXISTS (SELECT 1 FROM UserPhoto WHERE ID = @ID)
                        BEGIN
                            UPDATE UserPhoto SET Photo = @Photo WHERE ID = @ID
                        END
                        ELSE
                        BEGIN
                            INSERT INTO UserPhoto (ID, Photo) VALUES (@ID, @Photo)
                        END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set the parameters
                        cmd.Parameters.AddWithValue("@Photo", imageBytes);
                        cmd.Parameters.AddWithValue("@ID", userId);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Photo uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Photo upload failed. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to upload photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Method to load the user photo after login
        private void LoadUserPhoto()
        {
            try
            {
                // Extract the ID from label3 (e.g., #TE-245)
                string userId = label3.Text.Replace("#", "");

                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // SQL command to retrieve the photo from the database
                    string query = "SELECT Photo FROM UserPhoto WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set the user ID parameter
                        cmd.Parameters.AddWithValue("@ID", userId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Check if the photo is not null
                            if (reader["Photo"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["Photo"];

                                // Convert byte array to memory stream and load the image in PictureBox
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No picture found for this user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User photo not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)| *.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    // Load the selected image into PictureBox
                    pictureBox1.ImageLocation = imageLocation;

                    // Convert the image to byte array
                    byte[] imageBytes = File.ReadAllBytes(imageLocation);

                    // Extract the ID from label3 (e.g., #TE-245)
                    string userId = label3.Text;

                    // Insert the image into the database
                    InsertPhotoToDatabase(userId, imageBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
