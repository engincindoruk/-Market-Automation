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
    public partial class Suppliersadd_screen : Form
    {
        public Suppliersadd_screen()
        {
            InitializeComponent();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();

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
            if (mskTc.Text.Length < 11)
            {
                lblError.Text = "Please Check Your T.C";
                mskTc.Focus();
                return;
            }
            if (tbCompanyName.Text.Trim() == "")
            {
                lblError.Text = "Please Enter Your Company Name";
                tbCompanyName.Focus();
                return;
            }

            else
            {
                string name = tbName.Text.Trim();
                string surname = tbSurname.Text.Trim();
                string email = tbEmail.Text.Trim();
                string phone = mskPhone.Text.Trim();
                string tc = mskTc.Text.Trim();
                string companyname = tbCompanyName.Text.Trim();
                if (supplier.AddSupplier(name, surname, email, phone, tc, companyname) > 0)
                {
                    MessageBox.Show("Supplier Added Successfully");
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
