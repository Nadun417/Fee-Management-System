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
    public partial class CompetitionForm : Form
    {
        public CompetitionForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        String query;
        private string currentTrainingPlan = "";

        private void cmbAthleteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAthleteID.SelectedIndex > 0)
            {
                try
                {
                    // Get athlete's current weight and training plan
                    query = "SELECT CurrentWeight, TrainingPlan FROM Athletes WHERE AthleteID='" + cmbAthleteID.SelectedItem.ToString() + "'";
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Make sure to check for null values
                        if (!reader.IsDBNull(0))
                            lblCurrentWeight.Text = reader.GetValue(0).ToString();
                        else
                            lblCurrentWeight.Text = "0";

                        if (!reader.IsDBNull(1))
                            currentTrainingPlan = reader.GetValue(1).ToString();
                        else
                            currentTrainingPlan = "";

                        lblTrainingPlan.Text = currentTrainingPlan; // Set training plan to label
                    }
                    reader.Close(); // Close the reader before proceeding
                    conn.Close();

                    // Handle beginner training plan restrictions
                    bool isBeginner = (currentTrainingPlan.ToLower() == "beginner");

                    // Disable/enable participation controls based on training plan
                    radYes.Enabled = !isBeginner;
                    radNo.Enabled = !isBeginner;
                    numMonthlyEntries.Enabled = !isBeginner;

                    // For beginners, auto-set participation to "No" and entries to 0
                    if (isBeginner)
                    {
                        radNo.Checked = true;
                        numMonthlyEntries.Value = 0;
                    }

                    // Check if this athlete already has a competition entry
                    query = "SELECT COUNT(*) FROM Competitions WHERE AthleteID='" + cmbAthleteID.SelectedItem.ToString() + "'";
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    int entryCount = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();

                    if (entryCount > 0)
                    {
                        // Athlete has existing entry - load their data and switch to update mode
                        LoadAthleteCompetitionData(cmbAthleteID.SelectedItem.ToString());
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        // New athlete entry - reset form for new entry
                        cmbWeightCategory.SelectedIndex = 0;

                        // For non-beginners, reset the radio buttons
                        if (!isBeginner)
                        {
                            radYes.Checked = false;
                            radNo.Checked = false;
                            numMonthlyEntries.Value = 0;
                            numMonthlyEntries.Enabled = false;
                        }

                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                    }
                }
                catch (Exception AthleteErr)
                {
                    MessageBox.Show("Error while loading athlete data..." + Environment.NewLine + AthleteErr);
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            else
            {
                lblCurrentWeight.Text = "";
                lblTrainingPlan.Text = "";
                cmbWeightCategory.SelectedIndex = 0;
                radYes.Checked = false;
                radNo.Checked = false;
                numMonthlyEntries.Value = 0;
                numMonthlyEntries.Enabled = false;
                radYes.Enabled = true;
                radNo.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAthleteID.SelectedIndex == 0 || cmbWeightCategory.SelectedIndex == 0 || (!radYes.Checked && !radNo.Checked))
                {
                    MessageBox.Show("Please select an Athlete ID, Weight Category, and Participation status", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if monthly entries are provided when "Yes" is selected
                if (radYes.Checked && numMonthlyEntries.Value <= 0)
                {
                    MessageBox.Show("Please enter the number of competitions entered this month", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate weight category before proceeding
                double currentWeight = Convert.ToDouble(lblCurrentWeight.Text);
                string weightCategory = cmbWeightCategory.SelectedItem.ToString();
                string weightStatus = IsWithinWeightLimit(currentWeight, weightCategory);

                // Check if the athlete's weight is not within the selected category limit
                if (weightStatus != "Within limit.")
                {
                    MessageBox.Show("Cannot enter competition data: " + weightStatus +
                        "\nPlease select the appropriate weight category for this athlete.",
                        "Weight Category Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the athlete already has an entry
                string checkQuery = "SELECT COUNT(*) FROM Competitions WHERE AthleteID='" + cmbAthleteID.SelectedItem.ToString() + "'";
                conn.Open();
                cmd = new SqlCommand(checkQuery, conn);
                int entryCount = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                if (entryCount > 0)
                {
                    // Athlete already has an entry
                    DialogResult updateExisting = MessageBox.Show("This athlete already has a competition entry. Would you like to update it instead?",
                        "Entry Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (updateExisting == DialogResult.Yes)
                    {
                        // Load existing data and switch to update mode
                        LoadAthleteCompetitionData(cmbAthleteID.SelectedItem.ToString());
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                    }
                    return;
                }

                // Set participation values
                string participation;
                int monthlyEntryCount;

                // For beginners, automatically set to "No" and 0
                if (currentTrainingPlan.ToLower() == "beginner")
                {
                    participation = "No";
                    monthlyEntryCount = 0;
                }
                else
                {
                    participation = radYes.Checked ? "Yes" : "No";
                    monthlyEntryCount = radYes.Checked ? (int)numMonthlyEntries.Value : 0;
                }

                query = "INSERT INTO Competitions(AthleteID, CurrentWeight, WeightCategory, C_participation, MonthlyEntryCount) VALUES('" +
                    cmbAthleteID.SelectedItem.ToString() + "','" +
                    lblCurrentWeight.Text + "','" +
                    cmbWeightCategory.SelectedItem.ToString() + "','" +
                    participation + "','" +
                    monthlyEntryCount + "')";

                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                // Show success message
                MessageBox.Show("Competition entry for Athlete ID: " + cmbAthleteID.SelectedItem.ToString() +
                    " added successfully!" + Environment.NewLine + Environment.NewLine +
                    "Competing in " + cmbWeightCategory.SelectedItem.ToString() + ".",
                    "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear();
            }
            catch (Exception SaveErr)
            {
                MessageBox.Show("Error while saving competition data..." + Environment.NewLine + SaveErr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Clear()
        {
            cmbAthleteID.SelectedIndex = 0;
            lblCurrentWeight.Text = "";
            lblTrainingPlan.Text = "";
            cmbWeightCategory.SelectedIndex = 0;
            radYes.Checked = false;
            radNo.Checked = false;
            numMonthlyEntries.Value = 0;
            numMonthlyEntries.Enabled = false;
            radYes.Enabled = true;
            radNo.Enabled = true;
            currentTrainingPlan = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAthleteID.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select an Athlete ID to delete", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete competition entries for Athlete ID: " +
                    cmbAthleteID.SelectedItem.ToString() + "?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmDelete == DialogResult.Yes)
                {
                    query = "DELETE FROM Competitions WHERE AthleteID='" + cmbAthleteID.SelectedItem.ToString() + "'";
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Competition entries for Athlete ID: " + cmbAthleteID.SelectedItem.ToString() +
                            " deleted successfully!", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();

                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSearch.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No record found to delete.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception DeleteErr)
            {
                MessageBox.Show("Error while deleting competition data..." + Environment.NewLine + DeleteErr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAthleteID.SelectedIndex == 0 || cmbWeightCategory.SelectedIndex == 0 || (!radYes.Checked && !radNo.Checked))
                {
                    MessageBox.Show("Please select an Athlete ID, Weight Category, and Participation status", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if monthly entries are provided when "Yes" is selected for non-beginners
                if (currentTrainingPlan.ToLower() != "beginner" && radYes.Checked && numMonthlyEntries.Value <= 0)
                {
                    MessageBox.Show("Please enter the number of competitions entered this month", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate weight category before proceeding
                double currentWeight = Convert.ToDouble(lblCurrentWeight.Text);
                string weightCategory = cmbWeightCategory.SelectedItem.ToString();
                string weightStatus = IsWithinWeightLimit(currentWeight, weightCategory);

                // Check if the athlete's weight is not within the selected category limit
                if (weightStatus != "Within limit.")
                {
                    MessageBox.Show("Cannot update competition data: " + weightStatus +
                        "\nPlease select the appropriate weight category for this athlete.",
                        "Weight Category Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set participation values
                string participation;
                int monthlyEntryCount;

                // For beginners, automatically set to "No" and 0
                if (currentTrainingPlan.ToLower() == "beginner")
                {
                    participation = "No";
                    monthlyEntryCount = 0;
                }
                else
                {
                    participation = radYes.Checked ? "Yes" : "No";
                    monthlyEntryCount = radYes.Checked ? (int)numMonthlyEntries.Value : 0;
                }

                query = "UPDATE Competitions SET CurrentWeight='" + lblCurrentWeight.Text +
                    "', WeightCategory='" + cmbWeightCategory.SelectedItem.ToString() +
                    "', C_participation='" + participation +
                    "', MonthlyEntryCount='" + monthlyEntryCount +
                    "' WHERE AthleteID='" + cmbAthleteID.SelectedItem.ToString() + "'";

                conn.Open();
                cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                if (result > 0)
                {
                    // Show success message
                    MessageBox.Show("Competition entry for Athlete ID: " + cmbAthleteID.SelectedItem.ToString() +
                        " updated successfully!" + Environment.NewLine + Environment.NewLine +
                        "Competing in " + cmbWeightCategory.SelectedItem.ToString() + ".",
                        "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();

                    // Reset buttons after update
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSearch.Visible = true;
                }
                else
                {
                    MessageBox.Show("No record found to update.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception UpdateErr)
            {
                MessageBox.Show("Error while updating competition data..." + Environment.NewLine + UpdateErr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT AthleteID FROM Athletes";
                conn.Open();
                SqlDa = new SqlDataAdapter(query, conn);
                DataTable tab = new DataTable();
                SqlDa.Fill(tab);
                conn.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbAthleteID.Enabled = true;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSearch.Visible = false;

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
                    Clear();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while searching" + Environment.NewLine + err);
                btnSearch.Visible = true;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void CompetitionForm_Load(object sender, EventArgs e)
        {
            LoadAthleteID();
            cmbAthleteID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWeightCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWeightCategory.SelectedIndex = 0;

            // Initially disable monthly entries input
            numMonthlyEntries.Enabled = false;
        }

        private void LoadAthleteID()
        {
            try
            {
                query = "SELECT AthleteID FROM Athletes";
                conn.Open();
                SqlDa = new SqlDataAdapter(query, conn);
                DataTable dtAthletes = new DataTable();
                SqlDa.Fill(dtAthletes);

                cmbAthleteID.Items.Clear();
                cmbAthleteID.Items.Add("--SELECT--");
                foreach (DataRow row in dtAthletes.Rows)
                {
                    cmbAthleteID.Items.Add(row["AthleteID"]);
                }
                cmbAthleteID.SelectedIndex = 0;
                cmbWeightCategory.SelectedIndex = 0;

                conn.Close();

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSearch.Visible = true;
            }
            catch (Exception LoadErr)
            {
                MessageBox.Show("Error while Loading Data..." + Environment.NewLine + LoadErr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void LoadAthleteCompetitionData(string athleteId)
        {
            try
            {
                query = "SELECT WeightCategory, C_participation, MonthlyEntryCount FROM Competitions WHERE AthleteID='" + athleteId + "'";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cmbWeightCategory.SelectedItem = reader["WeightCategory"].ToString();

                    // Set radio button based on participation value
                    string participation = reader["C_participation"].ToString();

                    // For beginners, keep controls disabled but show correct values
                    bool isBeginner = (currentTrainingPlan.ToLower() == "beginner");

                    if (participation == "Yes")
                    {
                        radYes.Checked = true;
                        numMonthlyEntries.Value = Convert.ToDecimal(reader["MonthlyEntryCount"]);
                        numMonthlyEntries.Enabled = !isBeginner;
                    }
                    else
                    {
                        radNo.Checked = true;
                        numMonthlyEntries.Enabled = false;
                        numMonthlyEntries.Value = 0;
                    }
                }
                reader.Close(); // Explicitly close the reader
                conn.Close();
            }
            catch (Exception loadErr)
            {
                MessageBox.Show("Error while loading competition data..." + Environment.NewLine + loadErr);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private string IsWithinWeightLimit(double currentWeight, string weightCategory)
        {
            switch (weightCategory)
            {
                case "Flyweight (66kg)":
                    return currentWeight <= 66 ? "Within limit." : "Exceeds weight limit!";
                case "Lightweight (73kg)":
                    return (currentWeight > 66 && currentWeight <= 73) ? "Within limit." :
                          (currentWeight <= 66 ? "Exceeds weight limit!" : "Below category minimum!");
                case "Light–Middleweight (81kg)":
                    return (currentWeight > 73 && currentWeight <= 81) ? "Within limit." :
                          (currentWeight <= 73 ? "Exceeds weight limit!" : "Below category minimum!");
                case "Middleweight (90kg)":
                    return (currentWeight > 81 && currentWeight <= 90) ? "Within limit." :
                          (currentWeight <= 81 ? "Exceeds weight limit!" : "Below category minimum!");
                case "Light–Heavyweight (100kg)":
                    return (currentWeight > 90 && currentWeight <= 100) ? "Within limit." :
                          (currentWeight <= 90 ? "Exceeds weight limit!" : "Below category minimum!");
                case "Heavyweight (100+kg)":
                    return currentWeight > 100 ? "Within limit." : "Below category minimum!";
                default:
                    return "Unknown category";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new MenuForm();
            this.Close();
            back.Show();
        }

        // New event handlers for radio buttons
        private void radYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radYes.Checked && currentTrainingPlan.ToLower() != "beginner")
            {
                numMonthlyEntries.Enabled = true;
            }
        }

        private void radNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radNo.Checked)
            {
                numMonthlyEntries.Value = 0;
                numMonthlyEntries.Enabled = false;
            }
        }
    }
}