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
    public partial class ManagerForm : Form
    {
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
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet4.Employee_Salary' table. You can move, or remove it, as needed.
            this.employee_SalaryTableAdapter1.Fill(this.gym_Management_SystemDataSet4.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet3.MemberTransactions' table. You can move, or remove it, as needed.
            this.memberTransactionsTableAdapter2.Fill(this.gym_Management_SystemDataSet3.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet2.MemberTransactions' table. You can move, or remove it, as needed.
            //this.memberTransactionsTableAdapter1.Fill(this.gym_Management_SystemDataSet2.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet1.MemberTransactions' table. You can move, or remove it, as needed.
            //this.memberTransactionsTableAdapter.Fill(this.gym_Management_SystemDataSet1.MemberTransactions);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet.Employee_Salary' table. You can move, or remove it, as needed.
            //this.employee_SalaryTableAdapter.Fill(this.gym_Management_SystemDataSet.Employee_Salary);

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
    }
}
