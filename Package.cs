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
    public partial class Package : Form
    {

        string id;
        public Package()
        {
            InitializeComponent();
            packageOneProceed.BackColor = Color.Transparent;
            packageTwoProceed.BackColor = Color.Transparent;
            packageThreeProceed.BackColor = Color.Transparent;
        }

        public Package(string id)
        {
            this.id = id;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
