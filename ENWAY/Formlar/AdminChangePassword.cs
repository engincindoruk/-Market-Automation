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
    public partial class AdminChangePassword : Form
    {
        private string mail;
        private string code;
        private int id;

        public AdminChangePassword(string mail, string code, int id)
        {
            InitializeComponent();
            this.mail = mail;
            this.code = code;
            this.id = id;
        }

        private void AdminChangePassword_Load(object sender, EventArgs e)
        {
            tbEmail.Text = mail;
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

        private void tbPasswordagain_TextChanged(object sender, EventArgs e)
        {
            if (tbPasswordagain.Text == "")
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void tbpasswordverification_TextChanged(object sender, EventArgs e)
        {
            if (tbpasswordverification.Text == "")
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string password = tbpassword.Text.Trim();
                string againpassword = tbPasswordagain.Text.Trim();
                string verification = tbpasswordverification.Text.Trim();
                string email = tbEmail.Text.Trim();

                if (password == "")
                {
                    lblError.Text = "Please Enter Your Password";
                    tbpassword.Focus();
                    return;
                }
                if (password.Length < 5)
                {
                    lblError.Text = "Please Enter Min 5 Characters to Password";
                    tbpassword.Focus();
                    return;
                }
                if (againpassword=="")
                {
                    lblError.Text = "Please Enter Again Password";
                    tbPasswordagain.Focus();
                    return;
                }
                if (!againpassword.Equals(password))
                {
                    lblError.Text = "Passwords Are Not Same";
                    tbPasswordagain.Focus();
                    return;
                }
                if (!verification.Equals(code))
                {
                    lblError.Text = "Please Check Your Verification Code";
                    tbpasswordverification.Focus();
                    return;
                }
                else
                {
                    Admin admin = new Admin();
                    if (admin.EditAdminPassword(id, password)>0)
                    {
                        MessageBox.Show("Password Updated Successfully");
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
