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
    public partial class BKashTransaction : Form
    {

        string amount;
        string id;
        string name;

        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Gym Management System;Integrated Security=True;");

        public string Id { get => id; set => id = value; }
        public string Name1 { get => name; set => name = value; }

        public BKashTransaction(string amount) : this()
        {
            this.amount = amount;
        }

        public BKashTransaction(string id, string name) : this()
        {
            this.id = id;
            this.name = name;
        }

        public BKashTransaction()
        {
            //amountTextBox.Enabled = false;
            InitializeComponent();
            //amountTextBox.ReadOnly = false;

        }

        public bool TransactionConfirmed { get; set; } = false; // Default to false
        public string TransactionId { get; set; }

        public void SetTransactionDetails(string employeeId, string amount, DateTime payDate)
        {
            // Display or use the passed data as needed, such as showing the amount on the form
            // Fill the amountTextBox with the amount but leave it editable
            amountTextBox.Texts = amount;
            //amountTextBox.ReadOnly = false; // Ensure the amount is editable if needed
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
        public string GenerateTransactionId()
        {
            // You can use a simple random number generator to generate the transaction ID
            Random random = new Random();
            string transactionId = "TXN-" + random.Next(100000, 999999).ToString(); // Format: TXN-123456
            return transactionId;
        }
        public static string GetCurrentDateInFormat()
        {
            DateTime currentDate = DateTime.Now;

            string formattedDate = currentDate.ToString("yyyy-MM-dd");

            return formattedDate;
        }
       

        private void confirmBtnTrasaction_Click(object sender, EventArgs e)
        {

            string uniqueId = GenerateTransactionId();

            string date = GetCurrentDateInFormat();



            try
            {
                // Perform transaction logic here
                this.TransactionConfirmed = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during transaction: {ex.Message}", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (phoneNumberTextBox.Texts == "" || pinTextBox.Texts == "")
            {
                MessageBox.Show("Either the pin field is empty or the phone number field is!", "SignUp Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Open();

            if (amount == "1500")
            {

                try
                {
                    string querry = "insert into MemberTransactions values('" + "ME-0001" + "','" + uniqueId + "','" + Int32.Parse(amount) + "','" + date + "','" + "Clear" + "','" + "Monthly" + "')";
                    SqlCommand cmd = new SqlCommand(querry, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transactions Done!");
                    phoneNumberTextBox.Texts = "";
                    pinTextBox.Texts = "";
                    amountTextBox.Texts = "";
                    this.Close(); // Completely closes the form

                }
                catch (Exception ex)
                {
                    MessageBox.Show("PLEASE ENTER VALID INPUTS\n" + ex.Message);
                }
  
            }

            if (amount == "5000")
            {

                try
                {
                    string querry = "insert into MemberTransactions values('" + "ME-0001" + "','" + uniqueId + "','" + Int32.Parse(amount) + "','" + date + "','" + "Clear" + "','" + "Silver" + "')";
                    SqlCommand cmd = new SqlCommand(querry, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transactions Done!");
                    phoneNumberTextBox.Texts = "";
                    pinTextBox.Texts = "";
                    amountTextBox.Texts = "";
                    this.Close(); // Completely closes the form


                }
                catch (Exception ex)
                {
                    MessageBox.Show("PLEASE ENTER VALID INPUTS\n" + ex.Message);
                }
       
            }

            if (amount == "15000")
            {

                try
                {
                    string querry = "insert into MemberTransactions values('" + "ME-0001" + "','" + uniqueId + "','" + Int32.Parse(amount) + "','" + date + "','" + "Clear" + "','" + "Gold" + "')";
                    SqlCommand cmd = new SqlCommand(querry, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transactions Done!");
                    phoneNumberTextBox.Texts = "";
                    pinTextBox.Texts = "";
                    amountTextBox.Texts = "";
                    this.Close(); // Completely closes the form


                }
                catch (Exception ex)
                {
                    MessageBox.Show("PLEASE ENTER VALID INPUTS\n" + ex.Message);
                }
               
            }

            conn.Close();



        }
    

        private void amountTextBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void transactionBKPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public static string bkashAmount;
        private void BKashTransaction_Load(object sender, EventArgs e)
        {
            amountTextBox.Text = ManagerForm.amountManager;
            amountTextBox.Text = amount;
            //amountTextBox.Text = Package.pakckageAmount2;
            //amountTextBox.Text = Package.packageAmount3;
        }
    }
}
