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
    public partial class ServiceStaff : Form
    {
        public ServiceStaff()
        {
            InitializeComponent();
            Color deepRed = Color.FromArgb(128, 0, 32);
            Color maroon = Color.FromArgb(128, 0, 0);
            Color darkCherry = Color.FromArgb(255,127,127);
            Color black = Color.FromArgb(0, 0, 0);
            Color brickRed = Color.FromArgb(178, 34, 34);
            Color white = Color.FromArgb(255, 255, 255);

            Color blendedColor = BlendColors(maroon, black);

            Color header = BlendColors(darkCherry, brickRed, deepRed);

            recordsPanel.BackColor = white;

            headerBar.BackColor = header;

            serviceStaffRecords.BackgroundColor = white;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            profilePanel.Visible = true;
            recordsPanel.Visible = false;
        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanel.Visible = true;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.FormClosed += (s, ev) => Application.Exit();
            welcomeForm.Show();
            this.Hide();
        }

        private void ServiceStaff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet7.Employee_Salary' table. You can move, or remove it, as needed.
            this.employee_SalaryTableAdapter2.Fill(this.gym_Management_SystemDataSet7.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet5.Employee_Salary' table. You can move, or remove it, as needed.
            //this.employee_SalaryTableAdapter1.Fill(this.gym_Management_SystemDataSet5.Employee_Salary);
            // TODO: This line of code loads data into the 'gym_Management_SystemDataSet.Employee_Salary' table. You can move, or remove it, as needed.
            //this.employee_SalaryTableAdapter.Fill(this.gym_Management_SystemDataSet.Employee_Salary);

        }
    }
}
