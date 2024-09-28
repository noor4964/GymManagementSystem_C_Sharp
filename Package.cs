using Gym_Management_System.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            //packageOneProceed.Click += new EventHandler(packageOneProceed_Click);

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

        private void packageOneProceed_Click(object sender, EventArgs e)
        {    
            // Bronze Package - 1500/mth
            string amount = "1500";

            // Open the BkashTransaction form and pass the amount
            BKashTransaction bkashForm = new BKashTransaction(amount);
            bkashForm.Show();
            this.Close(); // Completely closes the form

        }




        private void Package_Load(object sender, EventArgs e)
        {


        }

        private void packageTwoProceed_Click(object sender, EventArgs e)
        {
            // Silver Package - 5000 / qtr
            string amount = "5000";

            // Open the BkashTransaction form and pass the amount
            BKashTransaction bkashForm = new BKashTransaction(amount);
            bkashForm.Show();  // Display the form
            this.Close(); // Completely closes the form


        }

        private void packageThreeProceed_Click(object sender, EventArgs e)
        {

            // Silver Package - 5000 / qtr
            string amount = "15000";

            // Open the BkashTransaction form and pass the amount
            BKashTransaction bkashForm = new BKashTransaction(amount);
            bkashForm.Show();  // Display the form
            this.Close(); // Completely closes the form

        }
    }
}
