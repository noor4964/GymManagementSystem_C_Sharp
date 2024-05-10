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
    public partial class BKashTransaction : Form
    {
        public BKashTransaction()
        {
            //amountTextBox.Enabled = false;
            InitializeComponent();
            amountTextBox.Texts = "5000";
        }

        private void bunifuCheckboxPin_OnChange(object sender, EventArgs e)
        {
            if (!bunifuCheckboxPin.Checked)
            {
                pinTextBox.PasswordChar = false;
            }
            else
            {
                pinTextBox.PasswordChar = true;
            }
        }
    }
}
