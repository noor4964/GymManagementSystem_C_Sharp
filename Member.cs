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
    public partial class Member : Form
    {
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
            SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
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
            SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
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
            SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
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
            SqlConnection conn = new SqlConnection("Data Source=NAVEDPC;Initial Catalog=Gym_Management_System;Integrated Security=True");
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
            welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Member_Load(object sender, EventArgs e)
        {
            FillChart();
            BMIChart();
            Avg_Hour_Chart();
            BreakDown_Pie_Chart();
        }

        private void gymRoundedPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gymTextBox4__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
