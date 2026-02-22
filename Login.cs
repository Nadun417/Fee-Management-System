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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        public static String rN = "", uT = "";

        private void Clear()
        {
            txtPw.Text = "";
            txtUsername.Text = "";
            cmbUserType.SelectedIndex = 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String username = txtUsername.Text;
                String password = txtPw.Text;
                uT = cmbUserType.SelectedItem.ToString();

                // Validate user selection
                if (uT == "Select User Type")
                {
                    MessageBox.Show("Please select a user type!", "KickBlast Judo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Updated query to use the Logins table
                String queryCheck = "SELECT RealName FROM Logins WHERE Username='" + username + "' AND Password='" + password + "' AND UserType='" + uT + "'";
                con.Open();
                SqlDa = new SqlDataAdapter(queryCheck, con);
                DataTable dtLogin = new DataTable();
                SqlDa.Fill(dtLogin);

                if (dtLogin.Rows.Count > 0)
                {
                    cmd = new SqlCommand(queryCheck, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rN = reader.GetValue(0).ToString();
                    }

                    MenuForm mainForm = new MenuForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username, Password or User Type!", "KickBlast Judo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                }
                con.Close();
            }
            catch (Exception loginError)
            {
                MessageBox.Show("Error during login..." + Environment.NewLine + loginError.Message, "KickBlast Judo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txtPw.UseSystemPasswordChar = false;
            }
            else
            {
                txtPw.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = true;
            cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserType.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txtPw.UseSystemPasswordChar = false;
            }
            else
            {
                txtPw.UseSystemPasswordChar = true;
            }
        }
    }
}
