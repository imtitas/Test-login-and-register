using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login_and_register
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" && txtPassword.Text == "" && txtConfirmPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty","Registration failed!!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if (txtPassword.Text == txtConfirmPass.Text) 
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUserName.Text + "', '" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPass.Text = "";

                MessageBox.Show("YOUR ACCOUNT HAS NEEEN SUCCESSFULLY CREATED!!", "REGISTRATION SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
            {
                MessageBox.Show("Password do not match, Registration failed", "Please re-enter", MessageBoxButtons.OK, MessageBoxIcon.Error );
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Focus();
            }    

        }

        private void checkBxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else 
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtUserName.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }

}
