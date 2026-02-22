using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KickBlast_Judo
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            // Populate the label with fee details from FeeCalculationForm
            iblBill.Text = "Dear Athlete," + Environment.NewLine +
                          "Your this month Fee as below;" + Environment.NewLine +
                          Environment.NewLine +
                          "Athlete ID :" + FeeForm.athleteId + Environment.NewLine +
                          "Training Plan : " + FeeForm.trainingPlan + Environment.NewLine +
                          "Training Fee : Rs." + FeeForm.trainingFee.ToString("0.00") + Environment.NewLine +
                          "Private Coaching Fee : Rs." + FeeForm.privateCoachingFee.ToString("0.00") + Environment.NewLine +
                          "Competition Fee : Rs." + FeeForm.competitionFee.ToString("0.00") + Environment.NewLine +
                          Environment.NewLine +
                          "Month : " + FeeForm.month + Environment.NewLine +
                          "Total Fee : Rs." + FeeForm.totalFee.ToString("0.00") + Environment.NewLine;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirmExit = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmExit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new FeeForm();
            this.Close();
            back.Show();
        }
    }
}
