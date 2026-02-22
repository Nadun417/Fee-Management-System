
namespace KickBlast_Judo
{
    partial class FeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeForm));
            this.cmbAthleteID = new System.Windows.Forms.ComboBox();
            this.lblTF = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCompetitionFee = new System.Windows.Forms.TextBox();
            this.txtCoachingFee = new System.Windows.Forms.TextBox();
            this.txtTrainingFee = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTrainingPlan = new System.Windows.Forms.Label();
            this.lblPCT = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCEntered = new System.Windows.Forms.Label();
            this.btnShowBill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbltrainingFee = new System.Windows.Forms.Label();
            this.lblprivateCoachingFee = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblcompetitionFee = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAthleteID
            // 
            this.cmbAthleteID.FormattingEnabled = true;
            this.cmbAthleteID.Location = new System.Drawing.Point(563, 117);
            this.cmbAthleteID.Name = "cmbAthleteID";
            this.cmbAthleteID.Size = new System.Drawing.Size(191, 29);
            this.cmbAthleteID.TabIndex = 60;
            this.cmbAthleteID.SelectedIndexChanged += new System.EventHandler(this.cmbAthleteID_SelectedIndexChanged);
            // 
            // lblTF
            // 
            this.lblTF.AutoSize = true;
            this.lblTF.Location = new System.Drawing.Point(386, 172);
            this.lblTF.Name = "lblTF";
            this.lblTF.Size = new System.Drawing.Size(103, 21);
            this.lblTF.TabIndex = 57;
            this.lblTF.Text = "Training Fee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 37);
            this.label3.TabIndex = 53;
            this.label3.Text = "MONTHLY FEE CALCULATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 54;
            this.label1.Text = "Athlete ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "Private Coaching Fee";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 57;
            this.label6.Text = "Competition Fee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 573);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 32);
            this.label8.TabIndex = 57;
            this.label8.Text = "Total Cost";
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(1, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(32, 37);
            this.btnBack.TabIndex = 67;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(768, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 38);
            this.btnExit.TabIndex = 66;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(730, 435);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 52);
            this.btnClear.TabIndex = 65;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(630, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 58);
            this.btnSave.TabIndex = 62;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(756, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 33);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCompetitionFee
            // 
            this.txtCompetitionFee.Location = new System.Drawing.Point(563, 277);
            this.txtCompetitionFee.Name = "txtCompetitionFee";
            this.txtCompetitionFee.Size = new System.Drawing.Size(191, 29);
            this.txtCompetitionFee.TabIndex = 90;
            // 
            // txtCoachingFee
            // 
            this.txtCoachingFee.Location = new System.Drawing.Point(563, 224);
            this.txtCoachingFee.Name = "txtCoachingFee";
            this.txtCoachingFee.Size = new System.Drawing.Size(191, 29);
            this.txtCoachingFee.TabIndex = 89;
            // 
            // txtTrainingFee
            // 
            this.txtTrainingFee.Location = new System.Drawing.Point(563, 169);
            this.txtTrainingFee.Name = "txtTrainingFee";
            this.txtTrainingFee.Size = new System.Drawing.Size(191, 29);
            this.txtTrainingFee.TabIndex = 88;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.DarkRed;
            this.btnCalculate.FlatAppearance.BorderSize = 0;
            this.btnCalculate.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnCalculate.Location = new System.Drawing.Point(390, 379);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(106, 33);
            this.btnCalculate.TabIndex = 91;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTotal.Location = new System.Drawing.Point(200, 573);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 32);
            this.lblTotal.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 21);
            this.label7.TabIndex = 92;
            this.label7.Text = "Training Plan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 21);
            this.label9.TabIndex = 93;
            this.label9.Text = "Private Coaching Time (H)";
            // 
            // lblTrainingPlan
            // 
            this.lblTrainingPlan.AutoSize = true;
            this.lblTrainingPlan.BackColor = System.Drawing.Color.IndianRed;
            this.lblTrainingPlan.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTrainingPlan.Location = new System.Drawing.Point(245, 173);
            this.lblTrainingPlan.Name = "lblTrainingPlan";
            this.lblTrainingPlan.Size = new System.Drawing.Size(0, 21);
            this.lblTrainingPlan.TabIndex = 57;
            // 
            // lblPCT
            // 
            this.lblPCT.AutoSize = true;
            this.lblPCT.BackColor = System.Drawing.Color.IndianRed;
            this.lblPCT.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblPCT.Location = new System.Drawing.Point(245, 228);
            this.lblPCT.Name = "lblPCT";
            this.lblPCT.Size = new System.Drawing.Size(0, 21);
            this.lblPCT.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 21);
            this.label12.TabIndex = 94;
            this.label12.Text = "Competitions Entered";
            // 
            // lblCEntered
            // 
            this.lblCEntered.AutoSize = true;
            this.lblCEntered.BackColor = System.Drawing.Color.IndianRed;
            this.lblCEntered.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCEntered.Location = new System.Drawing.Point(245, 281);
            this.lblCEntered.Name = "lblCEntered";
            this.lblCEntered.Size = new System.Drawing.Size(0, 21);
            this.lblCEntered.TabIndex = 95;
            // 
            // btnShowBill
            // 
            this.btnShowBill.BackColor = System.Drawing.Color.DarkRed;
            this.btnShowBill.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnShowBill.Location = new System.Drawing.Point(508, 379);
            this.btnShowBill.Name = "btnShowBill";
            this.btnShowBill.Size = new System.Drawing.Size(106, 33);
            this.btnShowBill.TabIndex = 96;
            this.btnShowBill.Text = "BILL";
            this.btnShowBill.UseVisualStyleBackColor = false;
            this.btnShowBill.Click += new System.EventHandler(this.btnShowBill_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 32);
            this.label2.TabIndex = 97;
            this.label2.Text = "Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 99;
            this.label5.Text = "Training Cost";
            // 
            // lbltrainingFee
            // 
            this.lbltrainingFee.AutoSize = true;
            this.lbltrainingFee.BackColor = System.Drawing.Color.IndianRed;
            this.lbltrainingFee.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbltrainingFee.Location = new System.Drawing.Point(245, 407);
            this.lbltrainingFee.Name = "lbltrainingFee";
            this.lbltrainingFee.Size = new System.Drawing.Size(0, 21);
            this.lbltrainingFee.TabIndex = 98;
            // 
            // lblprivateCoachingFee
            // 
            this.lblprivateCoachingFee.AutoSize = true;
            this.lblprivateCoachingFee.BackColor = System.Drawing.Color.IndianRed;
            this.lblprivateCoachingFee.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblprivateCoachingFee.Location = new System.Drawing.Point(245, 453);
            this.lblprivateCoachingFee.Name = "lblprivateCoachingFee";
            this.lblprivateCoachingFee.Size = new System.Drawing.Size(0, 21);
            this.lblprivateCoachingFee.TabIndex = 98;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 453);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 21);
            this.label13.TabIndex = 99;
            this.label13.Text = "Private Coaching Cost";
            // 
            // lblcompetitionFee
            // 
            this.lblcompetitionFee.AutoSize = true;
            this.lblcompetitionFee.BackColor = System.Drawing.Color.IndianRed;
            this.lblcompetitionFee.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblcompetitionFee.Location = new System.Drawing.Point(245, 499);
            this.lblcompetitionFee.Name = "lblcompetitionFee";
            this.lblcompetitionFee.Size = new System.Drawing.Size(0, 21);
            this.lblcompetitionFee.TabIndex = 98;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 499);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 21);
            this.label15.TabIndex = 99;
            this.label15.Text = "Competition Cost";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(563, 325);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(191, 29);
            this.txtMonth.TabIndex = 101;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(386, 328);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 21);
            this.label16.TabIndex = 100;
            this.label16.Text = "Month";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(346, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 32);
            this.label10.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 359);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 32);
            this.label11.TabIndex = 103;
            this.label11.Text = "Summery";
            // 
            // FeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(816, 628);
            this.ControlBox = false;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblcompetitionFee);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblprivateCoachingFee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbltrainingFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowBill);
            this.Controls.Add(this.lblCEntered);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtCompetitionFee);
            this.Controls.Add(this.txtCoachingFee);
            this.Controls.Add(this.txtTrainingFee);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbAthleteID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPCT);
            this.Controls.Add(this.lblTrainingPlan);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Form";
            this.Load += new System.EventHandler(this.FeeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbAthleteID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCompetitionFee;
        private System.Windows.Forms.TextBox txtCoachingFee;
        private System.Windows.Forms.TextBox txtTrainingFee;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTrainingPlan;
        private System.Windows.Forms.Label lblPCT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCEntered;
        private System.Windows.Forms.Button btnShowBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbltrainingFee;
        private System.Windows.Forms.Label lblprivateCoachingFee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblcompetitionFee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}