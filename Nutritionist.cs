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

namespace Gym_Management_System
{
    public partial class Nutritionist : Form
    {
        public Nutritionist()
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

            headerPanelNu.BackColor = header;

            headerNuPanelStats.BackColor = header;

            headerExercisePanel.BackColor = header;

            searchBtn.BackColor = Color.Transparent;

            sugstBtn.BackColor = Color.Transparent;

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

        private void profileBtn_Click(object sender, EventArgs e)
        {
            profilePanelNu.Visible = true;
            recordsPanelNu.Visible = false;
        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanelNu.Visible = true;
            memberStatsPanel.Visible = false;
        }

        private void statsBtn_Click(object sender, EventArgs e)
        {
            memberStatsPanel.Visible = true;
            suggestPanel.Visible = false;
        }

        private void suggestBtn_Click(object sender, EventArgs e)
        {
            suggestPanel.Visible = true;
        }

        private void Nutritionist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet9.Employee_Salary' table. You can move, or remove it, as needed.
            //this.employee_SalaryTableAdapter.Fill(this.gym_Management_SystemDataSet9.Employee_Salary);
            FillChart();
            BMIChart();
            Avg_Hour_Chart();
            BreakDown_Pie_Chart();

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
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");
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
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");
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
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");
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

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }

        private void sugstBtn_Click(object sender, EventArgs e)
        {
            // Get ID from TextBox
            string id = gymTextBox6.Texts;

            // Get selected meal from ComboBox (this replaces the day selection)
            string selectedMeal = gymComboBox1.SelectedItem?.ToString();
            string dietInput = gymTextBox5.Texts; // Diet input from TextBox

            // Log the values to verify
            MessageBox.Show($"Selected Meal: {selectedMeal}\nDiet Input: {dietInput}\nID: {id}");

            // Check if the selected meal or diet input is null or empty
            if (string.IsNullOrEmpty(selectedMeal))
            {
                MessageBox.Show("Please select a valid meal from the ComboBox.");
                return;
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(dietInput))
            {
                // Show specific error message based on the selected meal
                MessageBox.Show($"{selectedMeal} input is missing.");
                return;
            }

            // Determine the column to update based on the selected meal
            string columnToUpdate = "";
            switch (selectedMeal)
            {
                case "Breakfast":
                    columnToUpdate = "[Breakfast]";
                    break;
                case "Lunch":
                    columnToUpdate = "[Lunch]";
                    break;
                case "Dinner":
                    columnToUpdate = "[Dinner]";
                    break;
                default:
                    MessageBox.Show("Invalid selection. Please choose a valid meal.");
                    return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;"))
                {
                    conn.Open();

                    // Step 1: Check if the ID already exists in the database
                    string checkQuery = "SELECT COUNT(*) FROM Suugest_Diet WHERE ID = @ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", id);
                        int recordCount = (int)checkCmd.ExecuteScalar(); // Get the number of matching records

                        if (recordCount == 0)
                        {
                            // Step 2: If no record exists, insert a new row
                            string insertQuery = $"INSERT INTO Suugest_Diet (ID, {columnToUpdate}) VALUES (@ID, @Diet)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@ID", id);
                                insertCmd.Parameters.AddWithValue("@Diet", dietInput);

                                insertCmd.ExecuteNonQuery();
                                MessageBox.Show($"{selectedMeal} diet added successfully!");
                            }
                        }
                        else
                        {
                            // Step 3: If record exists, update the corresponding meal's diet
                            string updateQuery = $"UPDATE Suugest_Diet SET {columnToUpdate} = @Diet WHERE ID = @ID";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@ID", id);
                                updateCmd.Parameters.AddWithValue("@Diet", dietInput);

                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show($"{selectedMeal} diet updated successfully!");
                            }
                        }
                    }

                    // Clear the TextBox for the next input only after success
                    gymTextBox5.Texts = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving diet: " + ex.Message);
            }

        }
    }
}
