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
    public partial class Register_Screen : Form
    {
        public Register_Screen()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();

            lblError.Text = "";
            if (tbName.Text == "")
            {
                lblError.Text = "Please Enter Your Name";
                tbName.Focus();
                return;
            }
            if (tbSurname.Text == "")
            {
                lblError.Text = "Please Enter Your Surname";
                tbSurname.Focus();
                return;
            }
            if (tbEmail.Text.Trim() == "")
            {
                lblError.Text = "Please Enter Your Email";
                tbEmail.Focus();
                return;
            }
            if (!(tbEmail.Text.Contains('@') && tbEmail.Text.EndsWith(".com")))
            {
                lblError.Text = "Please Check Your Email";
                tbEmail.Focus();
                return;
            }
            if (mskPhone.Text.Length < 14)
            {
                lblError.Text = "Please Check Your Phone Number";
                mskPhone.Focus();
                return;
            }

            if (tbSalary.Text == "")
            {
                lblError.Text = "Please Enter Your Salary";
                tbSalary.Focus();
                return;
            }
            else if (mskTc.Text.Length < 11)
            {
                lblError.Text = "Please Check Your T.C";
                mskTc.Focus();
                return;
            }
            if (tbUsername.Text == "")
            {
                lblError.Text = "Please Enter Your Username";
                tbUsername.Focus();
                return;
            }
            if (tbUsername.Text.Length < 5)
            {
                lblError.Text = "Please Enter Min 5 Characters to Username";
                tbUsername.Focus();
                return;
            }
            if (tbPassword.Text == "")
            {
                lblError.Text = "Please Enter Your Password";
                tbPassword.Focus();
                return;
            }
            if (tbPassword.Text.Length < 5)
            {
                lblError.Text = "Please Enter Min 5 Characters to Password";
                tbPassword.Focus();
                return;
            }
            else
            {

                string name = tbName.Text.Trim();
                string surname = tbSurname.Text.Trim();
                string email = tbEmail.Text.Trim();
                string phone = mskPhone.Text.Trim();
                string time = dtDate.Value.ToShortDateString();
                int salary = int.Parse(tbSalary.Text.Trim());
                string tc = mskTc.Text.Trim();
                string username = tbUsername.Text.Trim();
                string password = tbPassword.Text.Trim();

                if (admin.AddAdmin(name, surname, email, phone, time, salary, tc, username, password,true) > 0)
                {
                    MessageBox.Show("Admin Added Successfully");
                    this.Close();
                }

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
