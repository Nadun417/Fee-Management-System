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
    public partial class UserRegForm : Form
    {
        public UserRegForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save button functionality
            try
            {
                // Validate inputs
                if (txtPassword.Text == "" || txtUsername.Text == "" || txtRealName.Text == "")
                {
                    MessageBox.Show("All fields must be filled", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
                else if (cmbUserType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select the user type", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbUserType.Focus();
                }
                else
                {
                    // Save data to database with direct SQL query
                    string query = "INSERT INTO Logins(Username, Password, RealName, UserType) VALUES('"
                        + txtUsername.Text + "','" + txtPassword.Text + "','"
                        + txtRealName.Text + "','" + cmbUserType.SelectedItem.ToString() + "')";

                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("User " + txtRealName.Text + " successfully added ",
                        "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error while saving" + Environment.NewLine + err.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void Clear()
        {
            // Reset all form controls
            txtRealName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            chkShowPassword.Checked = false;
            cmbUserType.SelectedIndex = 0;
            lblUsernameStatus.Text = "";
            txtUsername.ForeColor = SystemColors.WindowText;
            btnSave.Enabled = true;
        }

        private void UserRegForm_Load(object sender, EventArgs e)
        {
            Clear();
            cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserType.SelectedIndex = 0;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form back = new MenuForm();
            this.Close();
            back.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            // Exit button
            DialogResult result = MessageBox.Show("Are you sure you want to EXIT?",
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form mainForm = new MenuForm();
                this.Close();
                mainForm.Show();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Check username availability
            try
            {
                if (txtUsername.Text != "")
                {
                    string query = "SELECT * FROM Logins WHERE Username = '" + txtUsername.Text + "'";
                    con.Open();
                    SqlDa = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    SqlDa.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtUsername.ForeColor = Color.Red;
                        btnSave.Enabled = false;
                        lblUsernameStatus.Text = "Username Unavailable";
                        lblUsernameStatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtUsername.ForeColor = Color.Green;
                        btnSave.Enabled = true;
                        lblUsernameStatus.Text = "Username Available";
                        lblUsernameStatus.ForeColor = Color.Turquoise;
                    }
                    con.Close();
                }
                else
                {
                    lblUsernameStatus.Text = "";
                    txtUsername.ForeColor = SystemColors.WindowText;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error checking username: " + Environment.NewLine + err.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}