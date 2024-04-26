
namespace Gym_Management_System
{
    partial class AttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gymComboBox1 = new Gym_Management_System.CustomControls.GymComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gymTextBox3 = new Gym_Management_System.CustomControls.GymTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gym_Management_System.Properties.Resources.attendance__1_;
            this.pictureBox1.Location = new System.Drawing.Point(173, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 114);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(132, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Attendance";
            // 
            // gymComboBox1
            // 
            this.gymComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.gymComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gymComboBox1.BackColor = System.Drawing.Color.White;
            this.gymComboBox1.BorderColor = System.Drawing.Color.Black;
            this.gymComboBox1.BorderSize = 2;
            this.gymComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gymComboBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.gymComboBox1.IconColor = System.Drawing.Color.Black;
            this.gymComboBox1.Items.AddRange(new object[] {
            "Check-In",
            "Check-Out"});
            this.gymComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.gymComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.gymComboBox1.Location = new System.Drawing.Point(74, 330);
            this.gymComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.gymComboBox1.Name = "gymComboBox1";
            this.gymComboBox1.Padding = new System.Windows.Forms.Padding(2);
            this.gymComboBox1.Size = new System.Drawing.Size(304, 40);
            this.gymComboBox1.TabIndex = 39;
            this.gymComboBox1.Texts = "Select";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Entry Type";
            // 
            // gymTextBox3
            // 
            this.gymTextBox3.BackColor = System.Drawing.SystemColors.Window;
            this.gymTextBox3.BorderColor = System.Drawing.Color.Black;
            this.gymTextBox3.BorderFocusColor = System.Drawing.Color.Red;
            this.gymTextBox3.BorderFocusColor1 = System.Drawing.Color.Red;
            this.gymTextBox3.BorderSize = 2;
            this.gymTextBox3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymTextBox3.IsFocused = false;
            this.gymTextBox3.IsFocused1 = false;
            this.gymTextBox3.Location = new System.Drawing.Point(72, 431);
            this.gymTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gymTextBox3.Multiline = false;
            this.gymTextBox3.Name = "gymTextBox3";
            this.gymTextBox3.Padding = new System.Windows.Forms.Padding(7);
            this.gymTextBox3.PasswordChar = false;
            this.gymTextBox3.Size = new System.Drawing.Size(306, 35);
            this.gymTextBox3.TabIndex = 41;
            this.gymTextBox3.Texts = "";
            this.gymTextBox3.UnderLinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Enter ID";
            // 
            // bunifuThinButton23
            // 
            this.bunifuThinButton23.ActiveBorderThickness = 1;
            this.bunifuThinButton23.ActiveCornerRadius = 20;
            this.bunifuThinButton23.ActiveFillColor = System.Drawing.Color.Black;
            this.bunifuThinButton23.ActiveForecolor = System.Drawing.Color.Red;
            this.bunifuThinButton23.ActiveLineColor = System.Drawing.Color.White;
            this.bunifuThinButton23.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton23.BackgroundImage")));
            this.bunifuThinButton23.ButtonText = "Enter";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.Color.Red;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 20;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.Black;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.Color.Red;
            this.bunifuThinButton23.Location = new System.Drawing.Point(72, 529);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(304, 66);
            this.bunifuThinButton23.TabIndex = 43;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 700);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gymTextBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gymComboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private CustomControls.GymComboBox gymComboBox1;
        private System.Windows.Forms.Label label4;
        private CustomControls.GymTextBox gymTextBox3;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
    }
}