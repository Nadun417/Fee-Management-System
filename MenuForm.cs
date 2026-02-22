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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UVFTKGA;Initial Catalog=KickBlast_Judo;Integrated Security=True");
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        private void athleteRegistrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AthleteRegForm objHome = new AthleteRegForm();
            
            objHome.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to Logout?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Login back = new Login();
                this.Close();
                back.Show();
            }
            
        }

        private void competitionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form objHome = new CompetitionForm();

            objHome.Show();
        }

        private void courseFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form objHome = new FeeForm();

            objHome.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form objHome = new EmployeeRegForm();

            objHome.Show();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form objHome = new UserRegForm();

            objHome.Show();
        }
    }
}
