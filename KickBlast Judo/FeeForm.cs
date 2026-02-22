using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KickBlast_Judo
{
    public partial class FeeForm : Form
    {
        public FeeForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        string query;
        public static string athleteId;
        public static string trainingPlan;
        public static int privateCoachingHours, competitionsEntered;
        public static double trainingFee, privateCoachingFee, competitionFee, totalFee;
        public static string month;

        private void cmbAthleteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get athlete details from database
            try
            {
                if (cmbAthleteID.SelectedIndex > 0)
                {
                    athleteId = cmbAthleteID.SelectedItem.ToString();

                    // First query to get athlete's training plan and private coaching hours
                    query = "SELECT TrainingPlan, PrivateCoachingHours FROM Athletes WHERE AthleteID = '" + athleteId + "'";

                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    if (r.Read())
                    {
                        trainingPlan = r.GetValue(0).ToString();
                        privateCoachingHours = Convert.ToInt32(r.GetValue(1));

                        // Display training plan and coaching hours
                        lblTrainingPlan.Text = trainingPlan;
                        lblPCT.Text = privateCoachingHours.ToString();
                    }
                    else
                    {
                        ClearLabels();
                        con.Close();
                        return;
                    }
                    r.Close();

                    // Second query to get competition count
                    query = "SELECT ISNULL(MonthlyEntryCount, 0) FROM Competitions WHERE AthleteID = '" + athleteId + "'";
                    cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    competitionsEntered = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    lblCEntered.Text = competitionsEntered.ToString();

                    con.Close();
                }
                else
                {
                    ClearLabels();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Checks for missing inputs before saving
            if (cmbAthleteID.SelectedIndex > 0)
            {
                try
                {
                    // Get month from the text field
                    month = txtMonth.Text.Trim();

                    if (string.IsNullOrEmpty(month))
                    {
                        MessageBox.Show("Please enter a month");
                        txtMonth.Focus();
                        return;
                    }

                    // Check if record already exists
                    query = "SELECT COUNT(*) FROM FeeCalculation WHERE AthleteID = '" + athleteId + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (count > 0)
                    {
                        // Update existing record - Modified to use string concatenation instead of parameters
                        query = "UPDATE FeeCalculation SET TrainingFee = '" + trainingFee +
                                "', PrivateCoachingFee = '" + privateCoachingFee +
                                "', CompetitionFee = '" + competitionFee +
                                "', TotalFee = '" + totalFee +
                                "', Month = '" + month +
                                "' WHERE AthleteID = '" + athleteId + "'";
                    }
                    else
                    {
                        // Insert new record - Modified to use string concatenation instead of parameters
                        query = "INSERT INTO FeeCalculation (AthleteID, TrainingFee, PrivateCoachingFee, CompetitionFee, TotalFee, Month) " +
                                "VALUES ('" + athleteId + "', '" + trainingFee + "', '" + privateCoachingFee +
                                "', '" + competitionFee + "', '" + totalFee + "', '" + month + "')";
                    }

                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Athlete ID: " + athleteId + " fee details successfully SAVED to the database!",
                                    "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while Saving" + Environment.NewLine + err);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select an Athlete ID");
                cmbAthleteID.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbAthleteID.SelectedIndex > 0)
            {
                try
                {
                    athleteId = cmbAthleteID.SelectedItem.ToString();
                    query = "SELECT TrainingFee, PrivateCoachingFee, CompetitionFee, TotalFee " +
                            "FROM FeeCalculation WHERE AthleteID = '" + athleteId + "'";

                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    if (r.Read())
                    {
                        // Get the calculated fees from database
                        trainingFee = Convert.ToDouble(r.GetValue(0));
                        privateCoachingFee = Convert.ToDouble(r.GetValue(1));
                        competitionFee = Convert.ToDouble(r.GetValue(2));
                        totalFee = Convert.ToDouble(r.GetValue(3));
                        

                        // Update the cost labels
                        lbltrainingFee.Text = "Rs. " + trainingFee.ToString("0.00");
                        lblprivateCoachingFee.Text = "Rs. " + privateCoachingFee.ToString("0.00");
                        lblcompetitionFee.Text = "Rs. " + competitionFee.ToString("0.00");
                        lblTotal.Text = "Rs. " + totalFee.ToString("0.00");

                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No fee records found for this athlete. Please calculate the fees first.");
                        ClearLabels();
                    }

                    con.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while searching" + Environment.NewLine + err);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select an Athlete ID");
                cmbAthleteID.Focus();
            }
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Check for missing inputs before calculating
            if (cmbAthleteID.SelectedIndex > 0)
            {
                // Calculate fees based on the formula
                trainingFee = CalculateTrainingFee(trainingPlan);
                privateCoachingFee = 90.50 * privateCoachingHours * 4; // Rs.90.50 per hour × hours × 4 weeks
                competitionFee = 220.0 * competitionsEntered; // Rs.220 per competition
                totalFee = trainingFee + privateCoachingFee + competitionFee;

                // Update the labels with the calculated costs
                lbltrainingFee.Text = "Rs. " + trainingFee.ToString("0.00");
                lblprivateCoachingFee.Text = "Rs. " + privateCoachingFee.ToString("0.00");
                lblcompetitionFee.Text = "Rs. " + competitionFee.ToString("0.00");
                lblTotal.Text = "Rs. " + totalFee.ToString("0.00");

                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Select an Athlete ID");
                cmbAthleteID.Focus();
            }
        }

        private void btnShowBill_Click(object sender, EventArgs e)
        {
            if (cmbAthleteID.SelectedIndex > 0 && !string.IsNullOrEmpty(lblTotal.Text))
            {
                BillForm feeBill = new BillForm();
                feeBill.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select an athlete and calculate fees first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new MenuForm();
            this.Close();
            back.Show();
        }

        private void FeeForm_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false; // Disable the save button until calculation is triggered

            try
            {
                // Get athlete IDs
                query = "SELECT AthleteID FROM Athletes;";
                con.Open();
                SqlDa = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                SqlDa.Fill(tab);

                if (tab.Rows.Count > 0)
                {
                    cmbAthleteID.Items.Clear();
                    cmbAthleteID.Items.Add("--SELECT--");
                    foreach (DataRow line in tab.Rows)
                    {
                        cmbAthleteID.Items.Add(line["AthleteID"]);
                    }
                    cmbAthleteID.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("There is no data in the database");
                }

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while getting data from Athletes table" + Environment.NewLine + err);
                con.Close();
            }
            cmbAthleteID.DropDownStyle = ComboBoxStyle.DropDownList;
            Clear();
        }

        private double CalculateTrainingFee(string plan)
        {
            double weeklyFee = 0;

            // Set weekly fee based on training plan
            switch (plan)
            {
                case "Beginner":
                    weeklyFee = 250.00;
                    break;
                case "Intermediate":
                    weeklyFee = 300.00;
                    break;
                case "Elite":
                    weeklyFee = 350.00;
                    break;
                default:
                    weeklyFee = 0;
                    break;
            }

            return weeklyFee * 4; // 4 weeks in a month
        }

        private void ClearLabels()
        {
            lblTrainingPlan.Text = "";
            lblPCT.Text = "";
            lblCEntered.Text = "";
            lblTotal.Text = "";
        }

        private void Clear()
        {
            // Reset user inputs
            cmbAthleteID.SelectedIndex = 0;
            ClearLabels();
            txtTrainingFee.Text = "";
            txtCoachingFee.Text = "";
            txtCompetitionFee.Text = "";
            txtMonth.Text = ""; // Clear the Month field

            // Clear the cost labels
            lbltrainingFee.Text = "";
            lblprivateCoachingFee.Text = "";
            lblcompetitionFee.Text = "";

            cmbAthleteID.Focus();
            btnSave.Enabled = false;
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
        

    }
}
