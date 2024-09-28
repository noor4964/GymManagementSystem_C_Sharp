using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym_Management_System
{
    public partial class Trainer : Form
    {

        private string userId;

        private string trainerId;

        public Trainer(string trainerId) : this()
        {
            InitializeComponent();
            // Store the manager ID passed from the login form
            this.trainerId = trainerId;

            // Set the Manager ID text box or label when form is initialized
            label3.Text = trainerId;
        }
        SqlConnection conn =  new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=\"Gym Management System\";Integrated Security=True;");
        public Trainer()
        {
            InitializeComponent();
        }

        private void sugstBtn_Click(object sender, EventArgs e)
        {

            // Get ID from TextBox
            string id = gymTextBox6.Texts;

            // Get selected day from ComboBox, check if ComboBox has a valid selection
            string selectedDay = gymComboBox1.SelectedItem?.ToString();
            string routineInput = gymTextBox5.Texts; // Routine input from TextBox

            // Log the values to verify
            MessageBox.Show($"Selected Day: {selectedDay}\nRoutine Input: {routineInput}\nID: {id}");

            // Check if the selected day or routine input is null or empty
            if (string.IsNullOrEmpty(selectedDay))
            {
                MessageBox.Show("Please select a valid day from the ComboBox.");
                return;
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }



            if (string.IsNullOrWhiteSpace(routineInput))
            {
                // Show specific error message based on the selected day
                MessageBox.Show($"{selectedDay} routine is missing.");
                return;
            }

            // Determine the column to update based on the selected day, escape special characters like '-'
            string columnToUpdate = "";
            switch (selectedDay)
            {
                case "Day-1":
                    columnToUpdate = "[Day-1]";
                    break;
                case "Day-2":
                    columnToUpdate = "[Day-2]";
                    break;
                case "Day-3":
                    columnToUpdate = "[Day-3]";
                    break;
                case "Day-4":
                    columnToUpdate = "[Day-4]";
                    break;
                default:
                    MessageBox.Show("Invalid selection. Please choose a valid day.");
                    return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // Step 1: Check if the ID already exists in the database
                    string checkQuery = "SELECT COUNT(*) FROM Suggest_Exercise WHERE ID = @ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", id);
                        int recordCount = (int)checkCmd.ExecuteScalar(); // Get the number of matching records

                        if (recordCount == 0)
                        {
                            // Step 2: If no record exists, insert a new row
                            string insertQuery = $"INSERT INTO Suggest_Exercise (ID, {columnToUpdate}) VALUES (@ID, @Routine)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@ID", id);
                                insertCmd.Parameters.AddWithValue("@Routine", routineInput);

                                insertCmd.ExecuteNonQuery();
                                MessageBox.Show($"{selectedDay} routine added successfully!");
                            }
                        }
                        else
                        {
                            // Step 3: If record exists, update the corresponding day's routine
                            string updateQuery = $"UPDATE Suggest_Exercise SET {columnToUpdate} = @Routine WHERE ID = @ID";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@ID", id);
                                updateCmd.Parameters.AddWithValue("@Routine", routineInput);

                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show($"{selectedDay} routine updated successfully!");
                            }
                        }
                    }

                    // Clear the TextBox for the next input only after success
                    gymTextBox5.Texts = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving routine: " + ex.Message);
            }
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            profilePanelTrainer.Visible = true;
            recordsPanelTrainer.Visible = false;
        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanelTrainer.Visible = true;
            memberStatsPanel.Visible = false;
        }

        private void statsBtn_Click(object sender, EventArgs e)
        {
            memberStatsPanel.Visible = true;
            suggestPanel.Visible = false;
        }

        private void suggestbtn_Click(object sender, EventArgs e)
        {
            suggestPanel.Visible = true;

        }
        private void FillChart()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Month, Days FROM Member_Attendance", conn);
            da.Fill(dt);
            attendanceChart.DataSource = dt;


            attendanceChart.Series["Days"].XValueMember = "Month";
            attendanceChart.Series["Days"].YValueMembers = "Days";

            attendanceChart.Titles.Add("Monthly Attendance");
        }

        private void BMIChart()
        {
            //SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Month, BMI FROM BMI_Stats", conn);
            da.Fill(dt);
            bmiChart.DataSource = dt;
            conn.Close();

            bmiChart.Series["BMI"].XValueMember = "Month";
            bmiChart.Series["BMI"].YValueMembers = "BMI";

            bmiChart.Titles.Add("Monthly BMI");
        }
        
        private void Avg_Hour_Chart()
        {
            // SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Month, Time FROM Average_Workout_Hour_Monthly", conn);
            da.Fill(dt);
            avgChart.DataSource = dt;
            conn.Close();

            avgChart.Series["Hours"].XValueMember = "Month";
            avgChart.Series["Hours"].YValueMembers = "Time";

            avgChart.Titles.Add("Avgerage Workout Per Hour Monthly");
        }

        private void BreakDown_Pie_Chart()
        {
            //SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Nutrients, Percentage FROM Nutrion_BreakDown_Members", conn);
            da.Fill(dt);
            pieChart.DataSource = dt;
            conn.Close();

            pieChart.Series["BreakDown"].XValueMember = "Nutrients";
            pieChart.Series["BreakDown"].YValueMembers = "Percentage";
            pieChart.Series["BreakDown"].ChartType = SeriesChartType.Pie;
            pieChart.Series["BreakDown"].IsValueShownAsLabel = true;

            pieChart.Titles.Add("Nutrition Percentage BreakDown");
        }
        private void Trainer_Load(object sender, EventArgs e)
        {
            LoadUserPhoto();
            FillChart();
            BMIChart();
            Avg_Hour_Chart();
            BreakDown_Pie_Chart();
        }

        private void gymComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the TextBox when a new day is selected
            gymTextBox5.Text = "";
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
        // Method to insert the photo into the database

        // Method to automatically load the user photo on login (e.g., when form is loaded)
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
                        // Log the query and parameters for debugging
                        MessageBox.Show($"Inserting/Updating Photo for ID: {userId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
