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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Image = System.Drawing.Image;

namespace Gym_Management_System
{
    public partial class Member : Form
    {
        string memberID;
        public Member(string memberID) : this()
        {
            InitializeComponent();
            this.memberID = memberID;
            label3.Text = memberID;
        }
        public Member()
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

            headerBarProfile.BackColor = header;
            dietAndRoutineHeader.BackColor = header;
            headerDataPanel.BackColor = header;
            //hearderBarEmployee.BackColor = header;

            panel1.BackColor = header;
            panel2.BackColor = header;

            signUpBtn.BackColor = Color.Transparent;
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

        private void gymRoundedPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            profilePanelMember.Visible = true;
            statsPanel.Visible = false;
            //recordsPanel.Visible = false;
            //salaryPanel.Visible = false;
        }

        private void FillChart()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Month, Days FROM Member_Attendance", conn);
            da.Fill(dt);
            attendanceChart.DataSource = dt;
            conn.Close();

            attendanceChart.Series["Days"].XValueMember = "Month";
            attendanceChart.Series["Days"].YValueMembers = "Days";

            attendanceChart.Titles.Add("Monthly Attendance");
        }

        private void BMIChart()
        {
            SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=\"Gym Management System\";Integrated Security=True;");
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Month, BMI FROM BMI_Stats", conn);
            da.Fill(dt);
            //bmiChart.DataSource = dt;
            conn.Close();

            bmiChart.Series["BMI"].XValueMember = "Month";
            bmiChart.Series["BMI"].YValueMembers = "BMI";

            bmiChart.Titles.Add("Monthly BMI");
        }

        private void Avg_Hour_Chart()
        {
            SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=\"Gym Management System\";Integrated Security=True;");
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
            SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=\"Gym Management System\";Integrated Security=True;");
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



        private void statsBtn_Click(object sender, EventArgs e)
        {
            statsPanel.Visible = true;
            dietAndRoutinePanel.Visible = false;
        }

        private void dietAndRoutineBtn_Click(object sender, EventArgs e)
        {
            dietAndRoutinePanel.Visible = true;
            updateDataPanel.Visible = false;
        }

        private void updateDatabtn_Click(object sender, EventArgs e)
        {
            updateDataPanel.Visible = true;
        }

        private void paymentbtn_Click(object sender, EventArgs e)
        {

            new BKashTransaction().Show();
        }

        private void packageBtn_Click(object sender, EventArgs e)
        {
            new Package().Show();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
           // welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void Member_Load(object sender, EventArgs e)
        {
            LoadUserPhoto();
            FillChart();
            //BMIChart();
            Avg_Hour_Chart();
            BreakDown_Pie_Chart();
            FetchRoutineFromLabel();
        }

        private void gymRoundedPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gymTextBox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {

            // Connection string for your database
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");

            try
            {
                // Open the connection
                conn.Open();

                // SQL query to update specific columns
                string updateQuery = @"UPDATE Sign_Up 
                               SET  
                                   Weight = @Weight, 
                                   Height = @Height, 
                                   Email = @Email, 
                                   Street_Address = @Street_Address, 
                                   Postal_Code = @Postal_Code
                               WHERE Username = @Username";

                // Create SQL command
                SqlCommand cmd = new SqlCommand(updateQuery, conn);

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@Username", nametextBox.Texts); // Assuming you have TextBox controls for input
                                                                             // cmd.Parameters.AddWithValue("@City", gymComboBox1.SelectedItem.ToString()); // Assuming ComboBox for gender
                cmd.Parameters.AddWithValue("@Weight", gymTextBox3.Texts);
                cmd.Parameters.AddWithValue("@Height", gymTextBox2.Texts);
                cmd.Parameters.AddWithValue("@Email", gymTextBox1.Texts);
                cmd.Parameters.AddWithValue("@Street_Address", gymTextBox4.Texts);
                cmd.Parameters.AddWithValue("@Postal_Code", gymTextBox5.Texts);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // Notify the user whether the update was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update failed! Please check the username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }
        /*  private void FetchAndDisplayRoutine(string id)
          {
              // SQL query to fetch Day-1, Day-2, Day-3, Day-4 based on the given ID
              string query = "SELECT [Day-1], [Day-2], [Day-3], [Day-4] FROM Suggest_Exercise WHERE ID = @ID";

              try
              {
                  // Establish a database connection
                  using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                  {
                      conn.Open();

                      // Execute the query to fetch data
                      using (SqlCommand cmd = new SqlCommand(query, conn))
                      {
                          cmd.Parameters.AddWithValue("@ID", id);  // Pass the ID to the query

                          // Execute the reader to fetch data
                          using (SqlDataReader reader = cmd.ExecuteReader())
                          {
                              if (reader.Read()) // Check if any data is returned
                              {
                                  // Fetch values from the respective columns
                                  string day1 = reader["Day-1"] != DBNull.Value ? reader["Day-1"].ToString() : "No routine for Day-1";
                                  string day2 = reader["Day-2"] != DBNull.Value ? reader["Day-2"].ToString() : "No routine for Day-2";
                                  string day3 = reader["Day-3"] != DBNull.Value ? reader["Day-3"].ToString() : "No routine for Day-3";
                                  string day4 = reader["Day-4"] != DBNull.Value ? reader["Day-4"].ToString() : "No routine for Day-4";

                                  // Combine fetched routines into a single string
                                  string routines0 = $"{day1}";
                                  string routines1 = $"{day2}";
                                  string routines2 = $"{day3}";
                                  string routines3 = $"{day4}";
                                  // Display the fetched routines in label23
                                  label23.Text = routines0;
                                  label25.Text = routines1;
                                  label27.Text = routines2;
                                  label29.Text = routines3;
                              }
                              else
                              {
                                  // If no data is found, show a message
                                  MessageBox.Show("No routine found for the given ID.");
                              }
                          }
                      }
                  }
              }
              catch (Exception ex)
              {
                  // Handle any errors during the database interaction
                  MessageBox.Show("Error fetching routines: " + ex.Message);
              }
          }
        */










        private void FetchRoutineFromLabel()
        {
            // Extract the ID from label3
            string id = label3.Text;

            if (!string.IsNullOrEmpty(id))
            {
                // Call the FetchAndDisplayRoutine method with the fetched ID
                FetchAndDisplayRoutine(id);
                FetchAndDisplayDiet(id);
            }
            else
            {
                MessageBox.Show("ID not found in label3.");
            }
        }

        private void FetchAndDisplayRoutine(string id)
        {
            // SQL query to fetch Day-1, Day-2, Day-3, Day-4 based on the given ID
            string query = "SELECT [Day-1], [Day-2], [Day-3], [Day-4] FROM Suggest_Exercise WHERE ID = @ID";

            try
            {
                // Establish a database connection
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // Execute the query to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);  // Pass the ID to the query

                        // Execute the reader to fetch data
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Check if any data is returned
                            {
                                // Fetch values from the respective columns
                                string day1 = reader["Day-1"] != DBNull.Value ? reader["Day-1"].ToString() : "No routine for Day-1";
                                string day2 = reader["Day-2"] != DBNull.Value ? reader["Day-2"].ToString() : "No routine for Day-2";
                                string day3 = reader["Day-3"] != DBNull.Value ? reader["Day-3"].ToString() : "No routine for Day-3";
                                string day4 = reader["Day-4"] != DBNull.Value ? reader["Day-4"].ToString() : "No routine for Day-4";

                                // Combine fetched routines into a single string
                                string routines0 = $"{day1}";
                                string routines1 = $"{day2}";
                                string routines2 = $"{day3}";
                                string routines3 = $"{day4}";

                                // Display the fetched routines in respective labels
                                label23.Text = routines0;
                                label25.Text = routines1;
                                label27.Text = routines2;
                                label29.Text = routines3;
                            }
                            else
                            {
                                // If no data is found, show a message
                                MessageBox.Show("No routine found for the given ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the database interaction
                MessageBox.Show("Error fetching routines: " + ex.Message);
            }
        }

        private void FetchAndDisplayDiet(string id)
        {
            // SQL query to fetch Day-1, Day-2, Day-3, Day-4 based on the given ID
            string query = "SELECT [BreakFast],[Lunch],[Dinner] FROM Suugest_Diet WHERE ID = @ID";

            try
            {
                // Establish a database connection
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // Execute the query to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);  // Pass the ID to the query

                        // Execute the reader to fetch data
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Check if any data is returned
                            {
                                // Fetch values from the respective columns
                                string day1 = reader["Breakfast"] != DBNull.Value ? reader["Breakfast"].ToString() : "No routine for Day-1";
                                string day2 = reader["Lunch"] != DBNull.Value ? reader["Lunch"].ToString() : "No routine for Day-2";
                                string day3 = reader["Dinner"] != DBNull.Value ? reader["Dinner"].ToString() : "No routine for Day-3";
                                //string day4 = reader["Day-4"] != DBNull.Value ? reader["Day-4"].ToString() : "No routine for Day-4";

                                // Combine fetched routines into a single string
                                string routines0 = $"{day1}";
                                string routines1 = $"{day2}";
                                string routines2 = $"{day3}";
                                //string routines3 = $"{day4}";

                                // Display the fetched routines in respective labels
                                label20.Text = routines0;
                                label21.Text = routines1;
                                label22.Text = routines2;
                                //label29.Text = routines3;
                            }
                            else
                            {
                                // If no data is found, show a message
                                MessageBox.Show("No routine found for the given ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the database interaction
                MessageBox.Show("Error fetching routines: " + ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    } }
   
