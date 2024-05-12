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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Color deepRed = Color.FromArgb(128, 0, 32);
            Color maroon = Color.FromArgb(128, 0, 0);
            Color darkCherry = Color.FromArgb(255, 127, 127);
            Color black = Color.FromArgb(0, 0, 0);
            Color brickRed = Color.FromArgb(178, 34, 34);
            Color white = Color.FromArgb(255, 255, 255);

            Color header = BlendColors(darkCherry, brickRed, deepRed);

            headerBar.BackColor = header;
            headerBarSalary.BackColor = header;
            headerBarFees.BackColor = header;
            hearderBarEmployee.BackColor = header;
            headerAdminPanel.BackColor = header;

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

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet13.Employee_Salary' table. You can move, or remove it, as needed.
            this.employee_SalaryTableAdapter1.Fill(this.gym_Management_SystemDataSet13.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet12.MemberTransactions' table. You can move, or remove it, as needed.
            this.memberTransactionsTableAdapter1.Fill(this.gym_Management_SystemDataSet12.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet11.MemberTransactions' table. You can move, or remove it, as needed.
            this.memberTransactionsTableAdapter.Fill(this.gym_Management_SystemDataSet11.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet10.Employee_Salary' table. You can move, or remove it, as needed.
            this.employee_SalaryTableAdapter.Fill(this.gym_Management_SystemDataSet10.Employee_Salary);
            FillChart();
            BMIChart();
            Avg_Hour_Chart();
            BreakDown_Pie_Chart();

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

        private void profileBtn_Click(object sender, EventArgs e)
        {
         profilePanelAdmin.Visible = true;
          recordsPanel.Visible = false;
        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
             recordsPanel.Visible = true;
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
            statsPanel.Visible = false;
        }

        private void statsBtn_Click(object sender, EventArgs e)
        {
            statsPanel.Visible = true;
        }

        // profilePanelAdmin
        // salaryPanel
        // recordsPanel
        // feesPanel
    }
}
