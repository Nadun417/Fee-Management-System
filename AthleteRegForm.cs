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
    public partial class AthleteRegForm : Form
    {
        public AthleteRegForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        int serialNo;
        String gen, athleteId, query;

        private void Clear()
        {
            UniqueNumberGenerator();
            cmbAthleteID.Enabled = false;
            txtAthleteName.Text = "";
            txtNIC.Text = "";
            dtpDOB.Value = DateTime.Now;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtContactNo.Text = "";
            txtAddress.Text = "";
            cmbTrainingPlan.SelectedIndex = -1;
            txtCurrentWeight.Text = "";
            nudPHours.Value = 1; 
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            cmbTrainingPlan.SelectedIndex = 0;
        }

        private void UniqueNumberGenerator() // generates serial number for the database and Athlete ID
        {
            try
            {
                serialNo = 0;
                query = "SELECT AthleteID FROM Athletes";
                con.Open();
                SqlDa = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                SqlDa.Fill(table);

                if (table.Rows.Count > 0)
                {
                    query = "SELECT MAX(AthleteID) FROM Athletes";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader R = cmd.ExecuteReader();

                    while (R.Read())
                    {
                        serialNo = int.Parse(R.GetValue(0).ToString());
                    }
                    serialNo += 1;
                }
                else
                {
                    serialNo = 1;
                }
                con.Close();

                // This is where the fix is needed
                cmbAthleteID.Items.Clear();
                cmbAthleteID.Items.Add(serialNo.ToString());
                cmbAthleteID.Text = serialNo.ToString();
                cmbAthleteID.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while Serial No Generation" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e) // Update Button
        {
            if (cmbAthleteID.SelectedIndex == 0)
            {
                // avoid misclicks before getting information 
                MessageBox.Show("Please select an Athlete ID from the list");
            }
            else if (txtAthleteName.Text == "")
            {
                MessageBox.Show("Please enter the Athlete Name");
            }
            else if (txtNIC.Text == "")
            {
                MessageBox.Show("Please enter the NIC");
            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter the Contact No.");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address.");
            }
            else if (txtCurrentWeight.Text == "")
            {
                MessageBox.Show("Please enter the Current Weight.");
            }
            else if (rbFemale.Checked == false && rbMale.Checked == false)
            {
                MessageBox.Show("Please select the Gender");
            }
            else
            {
                // update new changes  
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gen = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gen = "Female";
                    }
                    query = "UPDATE Athletes SET AthleteName = '" + txtAthleteName.Text + "', NIC = '" + txtNIC.Text + "', Gender= '" + gen +
                            "', DateOfBirth='" + dtpDOB.Text + "', ContactNo = '" + txtContactNo.Text + "', Address='" + txtAddress.Text +
                            "', TrainingPlan='" + cmbTrainingPlan.Text + "', CurrentWeight='" + txtCurrentWeight.Text +
                            "', PrivateCoachingHours='" + nudPHours.Value.ToString() + "' WHERE AthleteID= '" + cmbAthleteID.SelectedItem.ToString() + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Athlete ID: " + cmbAthleteID.SelectedItem.ToString() + " updated successfully");
                    Clear();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while updating" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }
        private void cmbAthleteID_SelectedIndexChanged(object sender, EventArgs e) // Event handler for when an Athlete ID is selected in the ComboBox
        {
            try
            {
                if (cmbAthleteID.SelectedIndex > 0)
                {
                    athleteId = cmbAthleteID.SelectedItem.ToString();
                    query = "SELECT * FROM Athletes WHERE AthleteID = '" + athleteId + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        txtAthleteName.Text = r.GetValue(1).ToString();
                        txtNIC.Text = r.GetValue(2).ToString();
                        gen = r.GetValue(3).ToString();
                        dtpDOB.Text = r.GetValue(4).ToString();
                        txtContactNo.Text = r.GetValue(5).ToString();
                        txtAddress.Text = r.GetValue(6).ToString();
                        cmbTrainingPlan.Text = r.GetValue(7).ToString();
                        txtCurrentWeight.Text = r.GetValue(8).ToString();
                        nudPHours.Value = decimal.Parse(r.GetValue(9).ToString());
                    }
                    if (gen.Equals("Male")) { rbMale.Checked = true; }
                    else if (gen.Equals("Female")) { rbFemale.Checked = true; }

                    con.Close();
                }
                else
                {
                    txtAthleteName.Text = "";
                    txtNIC.Text = "";
                    txtContactNo.Text = "";
                    txtAddress.Text = "";
                    cmbTrainingPlan.SelectedIndex = -1;
                    txtCurrentWeight.Text = "";
                    nudPHours.Value = 1;
                    rbMale.Checked = false;
                    rbFemale.Checked = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while getting data" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e) // Delete button
        {
            try
            {
                athleteId = cmbAthleteID.SelectedItem.ToString();
                DialogResult res = MessageBox.Show("Are you sure you want to DELETE record " + athleteId, "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    query = "DELETE FROM Athletes WHERE AthleteID = '" + athleteId + "'";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record deleted successfully");
                    Clear();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while deleting" + Environment.NewLine + err);
                con.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e) // Exit button
        {
            DialogResult res = MessageBox.Show("Do you really want to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AthleteRegForm_Load_1(object sender, EventArgs e)
        {
            cmbTrainingPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAthleteID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrainingPlan.SelectedIndex = 0;
            UniqueNumberGenerator();

            
            nudPHours.Minimum = 1;
            nudPHours.Maximum = 5; 
            nudPHours.Value = 1;

            txtAthleteName.Focus();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new MenuForm();
            this.Close();
            back.Show();
        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {
            // NIC text box user input check 
            if (txtNIC.Text.Length == 10 || txtNIC.Text.Length == 12)
            {
                txtNIC.ForeColor = Color.Green;
            }
            else
            {
                txtNIC.ForeColor = Color.Red;

            }

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            // checks user's contact number length
            if (txtContactNo.Text.Length == 10)
            {
                txtContactNo.ForeColor = Color.Green;
            }
            else
            {
                txtContactNo.ForeColor = Color.Red;
            }
        }

        private void txtNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // avoid entering more than 12 characters in NIC textbox
            if (char.IsControl(e.KeyChar)) // allow control keys
            {
                return;
            }
            if (txtNIC.Text.Length > 11)
            {
                e.Handled = true;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // limit user input to 10 characters
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (txtContactNo.Text.Length > 9)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (rbFemale.Checked == false && rbMale.Checked == false)
            {
                MessageBox.Show("Please select the Gender");
            }
            else if (txtAthleteName.Text == "")
            {
                MessageBox.Show("Please enter the Athlete Name");
            }
            else if (txtNIC.Text == "")
            {
                MessageBox.Show("Please enter the NIC");
            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter the Contact No.");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address.");
            }
            else if (txtCurrentWeight.Text == "")
            {
                MessageBox.Show("Please enter the Current Weight.");
            }
            else
            {
                // save to database 
                try
                {
                    if (rbMale.Checked == true)
                    {
                        gen = "Male";
                    }
                    else if (rbFemale.Checked == true)
                    {
                        gen = "Female";
                    }

                    query = "INSERT INTO Athletes(AthleteID, AthleteName, NIC, Gender, DateOfBirth, ContactNo, Address, TrainingPlan, CurrentWeight, PrivateCoachingHours) VALUES('" +
                             cmbAthleteID.Text + "','" + txtAthleteName.Text + "','" + txtNIC.Text + "','" + gen + "','" + dtpDOB.Text + "','" + txtContactNo.Text + "','" +
                             txtAddress.Text + "','" + cmbTrainingPlan.Text + "','" + txtCurrentWeight.Text + "','" + nudPHours.Value.ToString() + "')";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Athlete ID: " + serialNo + " successfully SAVED to the database!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while Saving" + Environment.NewLine + err);
                    con.Close();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // Search button
        {
            try
            {
                query = "SELECT AthleteID FROM Athletes";
                con.Open();
                SqlDa = new SqlDataAdapter(query, con);
                DataTable tab = new DataTable();
                SqlDa.Fill(tab);
                con.Close();

                if (tab.Rows.Count > 0)
                {
                    cmbAthleteID.Enabled = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
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
                con.Close();
            }
        }
    }
}