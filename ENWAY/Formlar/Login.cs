using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENWAY
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void tbusername_TextChanged(object sender, EventArgs e)
        {
            if (tbusername.Text == "")
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {
            if (tbpassword.Text == "")
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        public static string outgoinginfo = "";

        private void btnSignin_Click(object sender, EventArgs e)
        {

            Admin admin = new Admin();

            string username = tbusername.Text.Trim();
            string password = tbpassword.Text.Trim();

            if (cbRememberme.Checked == true)
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

            if (admin.login(username, password,true) == true)
            {
                Enway enway = new Enway();
                this.Hide();
                outgoinginfo = tbusername.Text.Trim();
                enway.Show();
            }
            else
            {
                if (tbusername.Text == "")
                {
                    lblError.Text = "Enter Your Username";
                    tbusername.Focus();
                }
                else if (tbpassword.Text == "")
                {
                    lblError.Text = "Enter Your Password";
                    tbpassword.Focus();
                }
                else
                {
                    lblError.Text = "Please check your information";
                    tbusername.Focus();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register_Screen rs = new Register_Screen();
            rs.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Username!=string.Empty )
            {
                tbusername.Text = Properties.Settings.Default.Username;
                tbpassword.Text = Properties.Settings.Default.Password;
                cbRememberme.Checked = true;
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordEnterEmial fpe = new ForgotPasswordEnterEmial();
            fpe.Show();
            this.Hide();
        }
    }
}
