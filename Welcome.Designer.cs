
namespace Gym_Management_System
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.gymToggleButton1 = new Gym_Management_System.CustomControls.GymToggleButton();
            this.gymTextBox2 = new Gym_Management_System.CustomControls.GymTextBox();
            this.gymTextBox1 = new Gym_Management_System.CustomControls.GymTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ImagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(934, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(934, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(1025, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 47);
            this.label6.TabIndex = 5;
            this.label6.Text = "Login";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Gym_Management_System.Properties.Resources.user_interface__2___1_;
            this.pictureBox1.Location = new System.Drawing.Point(992, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Size = new System.Drawing.Size(199, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ImagePanel
            // 
            this.ImagePanel.BackgroundImage = global::Gym_Management_System.Properties.Resources.gym_with_red_light_wall_black_gym_with_weights_weights_911201_3371;
            this.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePanel.Controls.Add(this.label3);
            this.ImagePanel.Controls.Add(this.label2);
            this.ImagePanel.Controls.Add(this.label1);
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ImagePanel.Location = new System.Drawing.Point(0, 0);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(737, 791);
            this.ImagePanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 70);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forge";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 37.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCoral;
            this.label2.Location = new System.Drawing.Point(138, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(562, 74);
            this.label2.TabIndex = 1;
            this.label2.Text = "Muscle Engineers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 210);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build Power,\r\n           Stamina\r\nwith\r\n";
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
            this.bunifuThinButton23.ButtonText = "Login";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.Color.Red;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 20;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.Black;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.Color.Red;
            this.bunifuThinButton23.Location = new System.Drawing.Point(938, 529);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(333, 66);
            this.bunifuThinButton23.TabIndex = 12;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton23.Click += new System.EventHandler(this.bunifuThinButton23_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1342, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 38);
            this.label8.TabIndex = 15;
            this.label8.Text = "Not a Member?\r\n   SignUp Now!\r\n";
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckbox1.BackgroundImage = global::Gym_Management_System.Properties.Resources.view__1_;
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.Transparent;
            this.bunifuCheckbox1.Checked = true;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.Transparent;
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.Black;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(1278, 458);
            this.bunifuCheckbox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 16;
            this.bunifuCheckbox1.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // gymToggleButton1
            // 
            this.gymToggleButton1.Location = new System.Drawing.Point(1366, 124);
            this.gymToggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.gymToggleButton1.Name = "gymToggleButton1";
            this.gymToggleButton1.OffBackColor = System.Drawing.Color.Black;
            this.gymToggleButton1.OffToggleColor = System.Drawing.Color.White;
            this.gymToggleButton1.OnBackColor = System.Drawing.Color.Red;
            this.gymToggleButton1.OnToggleColor = System.Drawing.Color.White;
            this.gymToggleButton1.Size = new System.Drawing.Size(80, 42);
            this.gymToggleButton1.SolidStyle = true;
            this.gymToggleButton1.TabIndex = 13;
            this.gymToggleButton1.UseVisualStyleBackColor = true;
            this.gymToggleButton1.CheckedChanged += new System.EventHandler(this.gymToggleButton1_CheckedChanged);
            // 
            // gymTextBox2
            // 
            this.gymTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.gymTextBox2.BorderColor = System.Drawing.Color.Black;
            this.gymTextBox2.BorderFocusColor = System.Drawing.Color.Red;
            this.gymTextBox2.BorderFocusColor1 = System.Drawing.Color.Red;
            this.gymTextBox2.BorderSize = 3;
            this.gymTextBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymTextBox2.IsFocused = false;
            this.gymTextBox2.IsFocused1 = false;
            this.gymTextBox2.Location = new System.Drawing.Point(938, 452);
            this.gymTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gymTextBox2.Multiline = false;
            this.gymTextBox2.Name = "gymTextBox2";
            this.gymTextBox2.Padding = new System.Windows.Forms.Padding(7);
            this.gymTextBox2.PasswordChar = true;
            this.gymTextBox2.Size = new System.Drawing.Size(333, 35);
            this.gymTextBox2.TabIndex = 10;
            this.gymTextBox2.Texts = "";
            this.gymTextBox2.UnderLinedStyle = false;
            this.gymTextBox2._TextChanged += new System.EventHandler(this.gymTextBox2__TextChanged);
            // 
            // gymTextBox1
            // 
            this.gymTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.gymTextBox1.BorderColor = System.Drawing.Color.Black;
            this.gymTextBox1.BorderFocusColor = System.Drawing.Color.Red;
            this.gymTextBox1.BorderFocusColor1 = System.Drawing.Color.Red;
            this.gymTextBox1.BorderSize = 3;
            this.gymTextBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymTextBox1.IsFocused = false;
            this.gymTextBox1.IsFocused1 = false;
            this.gymTextBox1.Location = new System.Drawing.Point(938, 348);
            this.gymTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gymTextBox1.Multiline = false;
            this.gymTextBox1.Name = "gymTextBox1";
            this.gymTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.gymTextBox1.PasswordChar = false;
            this.gymTextBox1.Size = new System.Drawing.Size(333, 35);
            this.gymTextBox1.TabIndex = 9;
            this.gymTextBox1.Texts = "";
            this.gymTextBox1.UnderLinedStyle = false;
            this.gymTextBox1._TextChanged += new System.EventHandler(this.gymTextBox1__TextChanged_1);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 791);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gymToggleButton1);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gymTextBox2);
            this.Controls.Add(this.gymTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ImagePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ImagePanel.ResumeLayout(false);
            this.ImagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.GymTextBox gymTextBox1;
        private CustomControls.GymTextBox gymTextBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        private CustomControls.GymToggleButton gymToggleButton1;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
    }
}

