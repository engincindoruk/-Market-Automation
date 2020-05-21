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
    public partial class Enway : Form
    {
        public Enway()
        {
            InitializeComponent();
        }
        string clienttypeforsearchname = "";

        private void btnClose_Click(object sender, EventArgs e)
        {
            Bag bag = new Bag();
            DataTable dt = bag.GetProductNameinBag();
            if (dt.Rows.Count != 0) { 
                if (MessageBox.Show("All Product Will be Deleting in the Bag ,Do You Want it ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bag.DeleteAllProductsinBag();
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
            else
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        public void GetAdmin_func()
        {
            Admin admin = new Admin();
            dgvAdminInfo.DataSource = admin.getAdmin();
            dgvAdminInfo.Columns[0].Visible = false;
            dgvAdminInfo.Columns[2].Visible = false;
            dgvAdminInfo.Columns[3].Visible = false;
            dgvAdminInfo.Columns[4].Visible = false;
            dgvAdminInfo.Columns[5].Visible = false;
            dgvAdminInfo.Columns[6].Visible = false;
            dgvAdminInfo.Columns[7].Visible = false;
            dgvAdminInfo.Columns[8].Visible = false;
            dgvAdminInfo.Columns[9].Visible = false;
            dgvAdminInfo.Columns[10].Visible = false;
        }
        public void GetSupplier_func()
        {
            Supplier supplier = new Supplier();
            dgvSuppliersname.DataSource = supplier.getSupplier();
            dgvSuppliersname.Columns[0].Visible = false;
            dgvSuppliersname.Columns[2].Visible = false;
            dgvSuppliersname.Columns[3].Visible = false;
            dgvSuppliersname.Columns[4].Visible = false;
            dgvSuppliersname.Columns[5].Visible = false;
            dgvSuppliersname.Columns[6].Visible = false;
        }
        public void GetArtisan_func()
        {
            Artisan artisan = new Artisan();
            dgvArtisanName.DataSource = artisan.getArtisan();
            dgvArtisanName.Columns[0].Visible = false;
            dgvArtisanName.Columns[2].Visible = false;
            dgvArtisanName.Columns[3].Visible = false;
            dgvArtisanName.Columns[4].Visible = false;
            dgvArtisanName.Columns[5].Visible = false;
            dgvArtisanName.Columns[6].Visible = false;

        }
        public void GetCustomer_func()
        {
            Customer customer = new Customer();
            dgvCustomerName.DataSource = customer.getCustomer();
            dgvCustomerName.Columns[0].Visible = false;
            dgvCustomerName.Columns[2].Visible = false;
            dgvCustomerName.Columns[3].Visible = false;
            dgvCustomerName.Columns[4].Visible = false;
            dgvCustomerName.Columns[5].Visible = false;
        }
        

        public void ShowDiscountProducts()
        {
            Product product = new Product();
            dgvProductShowforManege.DataSource = product.GetAllProducts();
            for (int i = 0; i < dgvProductShowforManege.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle();
                if (Convert.ToInt16(dgvProductShowforManege.Rows[i].Cells[10].Value) > 0)
                {
                    color.BackColor = Color.LightGreen;
                    color.ForeColor = Color.White;
                }
                dgvProductShowforManege.Rows[i].DefaultCellStyle = color;
            }
            dgvProductShowforManege.Columns[11].Visible = false;
        }


        public void GetCategorieName()
        {
            cbSearchbyCategorie.Items.Clear();
            cbProductCategorieM.Items.Clear();
            cbSearchbyCategorieM.Items.Clear();
            Product product = new Product();
            DataTable dt = product.GetCategorieName();
            foreach (DataRow dr in dt.Rows)
            {
                cbSearchbyCategorie.Items.Add(dr["CategorieName"].ToString());
                cbProductCategorieM.Items.Add(dr["CategorieName"].ToString());
                cbSearchbyCategorieM.Items.Add(dr["CategorieName"].ToString());
            }
        }

        public void GetBrandName()
        {
            cbSearchbyBrand.Items.Clear();
            cbProductbrandM.Items.Clear();
            cbSearchbyBrandM.Items.Clear();
            Product product = new Product();
            DataTable dt = product.GetBrandName();
            foreach (DataRow dr in dt.Rows)
            {
                cbSearchbyBrand.Items.Add(dr["BrandName"].ToString());
                cbProductbrandM.Items.Add(dr["BrandName"].ToString());
                cbSearchbyBrandM.Items.Add(dr["BrandName"].ToString());
            }
        }

        public void GetSupplierName()
        {
            cbProductSuppliernameM.Items.Clear();
            Supplier supplier = new Supplier();
            DataTable dt = supplier.getSupplier();
            foreach (DataRow dr in dt.Rows)
            {
                cbProductSuppliernameM.Items.Add(dr["SupplierName"].ToString());
            }
        }


        public void ClearAdminInfo()
        {
            lblAdminid.Text = "";
            tbAdminname.Text = "";
            tbAdminsurname.Text = "";
            tbadminemail.Text = "";
            mskadminphone.Text = "";
            dtpAdmindate.Text = "";
            tbAdminsalary.Text = "";
            mskAdmintc.Text = "";
            tbAdminusername.Text = "";
            tbAdminpassword.Text = "";
        }
        public void ClearSuppliersInfo()
        {
            lblSupplierid.Text = "";
            tbSupplierName.Text = "";
            tbSupplierSurname.Text = "";
            tbSupplierMail.Text = "";
            mskSupplierphone.Text = "";
            mskSuppliertc.Text = "";
            tbSupplierCompanyname.Text = "";
        }
        public void ClearArtisanInfo()
        {
            lblArtisanid.Text = "";
            tbArtisanname.Text = "";
            tbArtisanSurname.Text = "";
            tbArtisanmail.Text = "";
            mskArtisanphone.Text = "";
            mskArtisantc.Text = "";
            tbArtisanBrandname.Text = "";
        }
        public void ClearCustomerInfo()
        {
            tbCustomerName.Text = "";
            tbCustomerSurname.Text = "";
            tbCustomerMail.Text = "";
            mskCustomerphone.Text = "";
            mskCustomerTc.Text = "";
        }
        public void ClearProductInfoM()
        {
            lblProductidM.Text = "";
            tbProductNameM.Text = "";
            cbProductbrandM.Text = "";
            cbProductCategorieM.Text = "";
            cbProductSuppliernameM.Text = "";
            tbProductCountM.Text = "";
            tbProductBuyingPriceM.Text = "";
            tbProductSalePriceM_C.Text = "";
            tbProductSalePriceM_A.Text = "";
            tbProductDiscountM.Text = "";
            tbPictureAdressM.Text = "";
            pbProductImage.ImageLocation = "";
        }
        public void ClearProductInfo()
        {
            lblProductNameShow.Text = "";
            lblProductbrandShow.Text = "";
            lblProductCategorieShow.Text = "";
            lblProductPriceshow.Text = "";
            lblProductdiscountshow.Text = "";
            lblProductLastPrice.Text = "";
        }

        public void ClearBagInfo()
        {
            lblBagid.Text = "";
            lblBagProductName.Text = "";
            lblBagProductCategorie.Text = "";
            lblBagProductBrand.Text = "";
            lblBagProductPrice.Text = "";
            lblBagProductDiscount.Text = "";
            nudBagProductCount.Value = 0;
            tbBagProductTotal.Text = "";
            pbBagProductImage.ImageLocation = null;
            lblBagProductLastPrice.Text = "";
        }

        public void ClearAnnouncementInfo()
        {
            lblAnnouncementProductid.Text = "";
            lblAnnouncementid.Text = "";
            lblAnnouncementProductname.Text = "";
            lblAnnouncementProductsalaryC.Text = "";
            lblAnnouncementProductsalaryA.Text = "";
            lblAnnouncementProductbrand.Text = "";
            tbAnnouncementProductDiscount.Text = "";
            rtbAnnouncementText.Text = "";
            pbAnnouncementProductımage.ImageLocation = "";
        }

        public void ClearCasaInfo()
        {
            lblCasaClientid.Text = "";
            lblclienttype.Text = "";
            lblCasaClientName.Text = "";
            lblCasaClientSurname.Text = "";
            lblCasaTotal.Text = "";
            cbCashType.Text = "";
            cbCashMovement.Text = "";
            cbCasaAdminName.Text = "";
            lblErrorforCasaEdit.Text = "";
        }

        public void ShowDiscountProductsC()
        {
            Product product = new Product();
            dgvProductShowforSale.DataSource = product.GetAllProductforSaleC();
            for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle();
                if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                {
                    color.BackColor = Color.LightGreen;
                }
                dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
            }
            dgvProductShowforSale.Columns[3].Visible = false;

        }
        public void ShowDiscountProductsA()
        {
            Product product = new Product();
            dgvProductShowforSale.DataSource = product.GetAllProductforSaleA();
            for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle();
                if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                {
                    color.BackColor = Color.LightGreen;
                }
                dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
            }
            dgvProductShowforSale.Columns[3].Visible = false;
        }


        private void selectproductwarning()
        {
            Bag bag = new Bag();
            if (tabControl1.SelectedIndex == 1)
            { 
                DataTable dt= bag.GetProductNameinBag();
                if (dt.Rows.Count==0)
                {
                    Product product = new Product();
                    if (MessageBox.Show("For Now Automaticly Choosed Client Type is 'CUSTOMER' ,Do you want to sell your Products to this Client Type", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClearProductInfo();
                        ShowDiscountProductsC();
                        clienttypeforsearchname = "customer";
                    }
                    else
                    {
                        ClearProductInfo();
                        ShowDiscountProductsA();
                        clienttypeforsearchname = "artisan";
                    }
                }
            }
            if (tabControl1.SelectedIndex==2)
            {
                DataTable dt = bag.GetProductNameinBag();
                if (dt.Rows.Count==0)
                {
                    if (MessageBox.Show("Your Bag is Empty,Do you Want Add Product from Products Menu","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectedIndex = 1;
                    }
                    else
                    {
                        tabControl1.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (clienttypeforsearchname=="customer")
                    {
                        GetDiscountProductInfoforBag_C();
                    }
                    else
                    {
                        GetDiscountProductInfoforBag_A();
                    }
                }
            }
            if (tabControl1.SelectedIndex == 3)
            {
                btnCashCustomer.BackColor = Color.Transparent;
                btnCashArtisan.BackColor = Color.Transparent;
                if (clienttypeforsearchname=="customer")
                {
                    btnCashCustomer.BackColor = Color.White;
                    lblclienttype.Text = "customer";
                    Customer customer = new Customer();
                    dgvCasaClientName.DataSource = customer.getCustomer();
                    dgvCasaClientName.Columns[0].Visible = false;
                    dgvCasaClientName.Columns[2].Visible = false;
                    dgvCasaClientName.Columns[3].Visible = false;
                    dgvCasaClientName.Columns[4].Visible = false;
                    dgvCasaClientName.Columns[5].Visible = false;

                }
                else if (clienttypeforsearchname=="artisan")
                {
                    btnCashArtisan.BackColor = Color.White;
                    lblclienttype.Text = "artisan";
                    Artisan artisan = new Artisan();
                    dgvCasaClientName.DataSource = artisan.getArtisan();
                    dgvCasaClientName.Columns[0].Visible = false;
                    dgvCasaClientName.Columns[2].Visible = false;
                    dgvCasaClientName.Columns[3].Visible = false;
                    dgvCasaClientName.Columns[4].Visible = false;
                    dgvCasaClientName.Columns[5].Visible = false;
                    dgvCasaClientName.Columns[6].Visible = false;
                }
            }
        }

        public void GetProductinBag_C()
        {
            Bag bag = new Bag();
            dgvBagProducts.DataSource = bag.GetProductinBag_C();
            dgvBagProducts.Columns[9].Visible = false;
        }
        public void GetProductinBag_A()
        {
            Bag bag = new Bag();
            dgvBagProducts.DataSource = bag.GetProductinBag_A();
            dgvBagProducts.Columns[9].Visible = false;
        }


        public void GetDiscountProductInfoforBag_C()
        {
            Product product = new Product();
            dgvBagAdvantageousProduct.DataSource = product.GetDiscountProductforbag_C();
            dgvBagAdvantageousProduct.Columns[3].Visible = false;
        }
        public void GetDiscountProductInfoforBag_A()
        {
            Product product = new Product();
            dgvBagAdvantageousProduct.DataSource = product.GetDiscountProductforbag_A();
            dgvBagAdvantageousProduct.Columns[3].Visible = false;
        }

        public void GetProductwithoutDiscountforAnnouncement()
        {
            Product product = new Product();
            dgvAnnouncementAllProduct.DataSource = product.GetProductWithoutDiscountForAnnouncement();
            dgvAnnouncementAllProduct.Columns[10].Visible = false;
        }

        public void GetCreatedAnnouncement()
        {
            Announcement announcement = new Announcement();
            dgvAnnouncementCreated.DataSource = announcement.GetAnnouncement();
            dgvAnnouncementCreated.Columns[8].Visible = false;
        }

        public void GetBaginCasa()
        {
            Bag bag = new Bag();
            dgvCasaListBag.DataSource = bag.GetProductinBag();
        }

        private void Enway_Load(object sender, EventArgs e)     //LOAD KISMI
        {
            

            string username = Login.outgoinginfo;
            Admin admin= new Admin();
            DataTable dt=admin.getAdminNamefortheHeader(username);
            foreach (DataRow dr in dt.Rows)
            {
                lbl__Name.Text = dr["AdminName"].ToString();
            }
            GetAdmin_func();
            GetSupplier_func();
            GetArtisan_func();
            GetCustomer_func();
            ShowDiscountProducts();
            GetBrandName();
            cbProductbrandM.Items.Clear();
            GetCategorieName();
            cbProductCategorieM.Items.Clear();
            GetProductinBag_C();
            GetProductwithoutDiscountforAnnouncement();
            GetCreatedAnnouncement();
        }

        /////Admin
        private void dgvAdminInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int result2 = dgvAdminInfo.SelectedCells[0].RowIndex;
                lblAdminid.Text = dgvAdminInfo.Rows[result2].Cells[0].Value.ToString();
                tbAdminname.Text = dgvAdminInfo.Rows[result2].Cells[1].Value.ToString();
                tbAdminsurname.Text = dgvAdminInfo.Rows[result2].Cells[2].Value.ToString();
                tbadminemail.Text = dgvAdminInfo.Rows[result2].Cells[3].Value.ToString();
                mskadminphone.Text = dgvAdminInfo.Rows[result2].Cells[4].Value.ToString();
                dtpAdmindate.Text = dgvAdminInfo.Rows[result2].Cells[5].Value.ToString();
                tbAdminsalary.Text = dgvAdminInfo.Rows[result2].Cells[6].Value.ToString();
                mskAdmintc.Text = dgvAdminInfo.Rows[result2].Cells[7].Value.ToString();
                tbAdminusername.Text = dgvAdminInfo.Rows[result2].Cells[8].Value.ToString();
                tbAdminpassword.Text = dgvAdminInfo.Rows[result2].Cells[9].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnAdminCreate_Click(object sender, EventArgs e)
        {
            Register_Screen rs = new Register_Screen();
            rs.ShowDialog();
        }

        private void btnAdminUserlistRefresh_Click(object sender, EventArgs e)
        {
            GetAdmin_func();
            tbSearchAdminbyName.Text = "";
        }

        private void btnAdmindelete_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            try
            {
                if (admin.DeleteAdmin(Convert.ToInt16(lblAdminid.Text.Trim())) > 0)
                {
                    lblErrorforAdminEdit.Text= "Deleting Successfully";
                    wait(1000);
                    lblErrorforAdminEdit.Text = "";
                    GetAdmin_func();
                    ClearAdminInfo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in AdminList");
            }
        }

        private void btnAdminupdate_Click(object sender, EventArgs ex)
        {
            try
            {
                if (lblAdminid.Text!="")
                {
                    Admin admin = new Admin();
                    if (tbAdminname.Text!="" && tbAdminsurname.Text!="" &&tbadminemail.Text!="" && tbadminemail.Text.Contains('@')
                        && tbadminemail.Text.EndsWith(".com")&& mskadminphone.Text.Length == 14 &&tbAdminsalary.Text!="" &&
                        mskAdmintc.Text.Length == 11 && tbAdminsurname.Text!=""&& tbAdminpassword.Text!=""&& tbAdminpassword.Text.Length>=5
                        && admin.UpdateAdmin(int.Parse(lblAdminid.Text.Trim()), tbAdminname.Text.Trim(), tbAdminsurname.Text.Trim(), tbadminemail.Text.Trim(),
                        mskadminphone.Text.Trim(), dtpAdmindate.Value.ToShortDateString(), int.Parse(tbAdminsalary.Text.Trim()),
                        mskAdmintc.Text.Trim(), tbAdminusername.Text.Trim(), tbAdminpassword.Text.Trim(),true) > 0)
                    {
                        lblErrorforAdminEdit.Text = "Updating Succesfully";
                        GetAdmin_func();
                        ClearAdminInfo();
                        wait(1500);
                        lblErrorforAdminEdit.Text = "";
                    }
                    else
                    {
                        lblErrorforAdminEdit.Text = "Check The Information";
                        wait(1000);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in AdminList");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
        
        private void tbSearchAdminbyName_TextChanged(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            dgvAdminInfo.DataSource = admin.getAdminlıkeName(tbSearchAdminbyName.Text.Trim());
        }
        ////ADMİN BİTİŞ
        
        //Supplier Başlangıç
        private void btnCreativenewSupplier_Click(object sender, EventArgs e)
        {
            Suppliersadd_screen ss = new Suppliersadd_screen();
            ss.ShowDialog();
        }

        private void btnSupplierUserlistRefresh_Click(object sender, EventArgs e)
        {
            GetSupplier_func();
            tbSearchSupplierbyName.Text = "";
        }

        private void dgvSuppliersname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index2 = dgvSuppliersname.SelectedCells[0].RowIndex;

                lblSupplierid.Text = dgvSuppliersname.Rows[index2].Cells[0].Value.ToString();
                tbSupplierName.Text = dgvSuppliersname.Rows[index2].Cells[1].Value.ToString();
                tbSupplierSurname.Text = dgvSuppliersname.Rows[index2].Cells[2].Value.ToString();
                tbSupplierMail.Text = dgvSuppliersname.Rows[index2].Cells[3].Value.ToString();
                mskSupplierphone.Text = dgvSuppliersname.Rows[index2].Cells[4].Value.ToString();
                mskSuppliertc.Text = dgvSuppliersname.Rows[index2].Cells[5].Value.ToString();
                tbSupplierCompanyname.Text = dgvSuppliersname.Rows[index2].Cells[6].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier();
                supplier.DeleteSupplier(int.Parse(lblSupplierid.Text.Trim()));
                lblErrorforSupplierEdit.Text = "Deleting Successfully";
                wait(1000);
                lblErrorforSupplierEdit.Text = "";
                GetSupplier_func();
                ClearSuppliersInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Supplier List");
            }
        }

        private void btnSupplierUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSupplierid.Text!="")
                {
                    Supplier supplier = new Supplier();
                    if (tbSupplierName.Text!="" && tbSupplierSurname.Text!="" && tbSupplierMail.Text.Contains('@') && tbSupplierMail.Text.EndsWith(".com" )&&
                        mskSupplierphone.Text.Length == 14 && mskSuppliertc.Text.Length==11 && tbSupplierCompanyname.Text!="" && supplier.UpdateSupplier(int.Parse(lblSupplierid.Text.Trim()), tbSupplierName.Text.Trim(), tbSupplierSurname.Text.Trim(),
                    tbSupplierMail.Text.Trim(), mskSupplierphone.Text.Trim(), mskSuppliertc.Text.Trim(), tbSupplierCompanyname.Text.Trim())>0)
                    {
                        lblErrorforSupplierEdit.Text = "Updating Succesfully";
                        wait(1500);
                        GetSupplier_func();
                        ClearSuppliersInfo();
                        lblErrorforSupplierEdit.Text = "";
                    }
                    else
                    {
                        lblErrorforSupplierEdit.Text = "Check Information";
                        wait(1000);
                    }

                }
                else
                {
                    MessageBox.Show("Please Select One in Supplier List");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void tbSearchSupplierbyName_TextChanged(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            dgvSuppliersname.DataSource = supplier.getSupplierlıkeName(tbSearchSupplierbyName.Text.Trim());
        }
        //Supplier Bitiş

        //Artisan Başlangıç
        private void btnCreatenewArtisan_Click(object sender, EventArgs e)
        {
            Artisanadd_screen artisanadd_Screen = new Artisanadd_screen();
            artisanadd_Screen.ShowDialog();
        }

        private void btnArtisanUserlistRefresh_Click(object sender, EventArgs e)
        {
            GetArtisan_func();
            tbSearchArtisanbyName.Text = "";
        }

        private void dgvArtisanName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index2 = dgvArtisanName.SelectedCells[0].RowIndex;
                lblArtisanid.Text = dgvArtisanName.Rows[index2].Cells[0].Value.ToString();
                tbArtisanname.Text = dgvArtisanName.Rows[index2].Cells[1].Value.ToString();
                tbArtisanSurname.Text = dgvArtisanName.Rows[index2].Cells[2].Value.ToString();
                tbArtisanmail.Text = dgvArtisanName.Rows[index2].Cells[3].Value.ToString();
                mskArtisanphone.Text = dgvArtisanName.Rows[index2].Cells[4].Value.ToString();
                mskArtisantc.Text = dgvArtisanName.Rows[index2].Cells[5].Value.ToString();
                tbArtisanBrandname.Text = dgvArtisanName.Rows[index2].Cells[6].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnArtisanDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Artisan artisan = new Artisan();
                artisan.DeleteArtisan(int.Parse(lblArtisanid.Text.Trim()));
                lblErrorforArtisanEdit.Text = "Deleting Successfully";
                wait(1000);
                lblErrorforArtisanEdit.Text = "";
                GetArtisan_func();
                ClearArtisanInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Artisan List");
            }
        }

        private void btnArtisanUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblArtisanid.Text != "")
                {
                    Artisan artisan = new Artisan();
                    if (tbArtisanname.Text != "" && tbArtisanSurname.Text != "" && tbArtisanmail.Text != "" && tbArtisanmail.Text.Contains('@') &&
                        tbArtisanmail.Text.EndsWith(".com") && mskArtisanphone.Text.Length == 14 && mskArtisantc.Text.Length == 11 &&
                        tbArtisanBrandname.Text != "" && artisan.UpdateArtisan(int.Parse(lblArtisanid.Text.Trim()), tbArtisanname.Text.Trim(), tbArtisanSurname.Text.Trim(),
                        tbArtisanmail.Text.Trim(), mskArtisanphone.Text.Trim(), mskArtisantc.Text.Trim(), tbArtisanBrandname.Text.Trim()) > 0)
                    {
                        lblErrorforArtisanEdit.Text = "Updating Successfully";
                        wait(1500);
                        GetArtisan_func();
                        ClearArtisanInfo();
                        lblErrorforArtisanEdit.Text = "";
                    }
                    else
                    {
                        lblErrorforArtisanEdit.Text = "Check Information";
                        wait(1000);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in Artisan List");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void tbSearchArtisanbyName_TextChanged(object sender, EventArgs e)
        {
            Artisan artisan = new Artisan();
            dgvArtisanName.DataSource = artisan.getArtisanlıkeName(tbSearchArtisanbyName.Text.Trim());
        }
        //Artisan bitiş
        //Customer Başlangıç

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            Customeradd_screen cs = new Customeradd_screen();
            cs.ShowDialog();
        }

        private void btnCustomerUserlistRefresh_Click(object sender, EventArgs e)
        {
            GetCustomer_func();
            tbSearchCustomerbyName.Text = "";
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.DeleteCustomer(int.Parse(lblCustomerid.Text.Trim()));
                lblErrorforCustomerEdit.Text = "Deleting Successfully";
                wait(1000);
                lblErrorforCustomerEdit.Text = "";
                GetCustomer_func();
                ClearCustomerInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Customer List");
            }
        }

        private void dgvCustomerName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index2 = dgvCustomerName.SelectedCells[0].RowIndex;
                lblCustomerid.Text = dgvCustomerName.Rows[index2].Cells[0].Value.ToString();
                tbCustomerName.Text = dgvCustomerName.Rows[index2].Cells[1].Value.ToString();
                tbCustomerSurname.Text = dgvCustomerName.Rows[index2].Cells[2].Value.ToString();
                tbCustomerMail.Text = dgvCustomerName.Rows[index2].Cells[3].Value.ToString();
                mskCustomerphone.Text = dgvCustomerName.Rows[index2].Cells[4].Value.ToString();
                mskCustomerTc.Text = dgvCustomerName.Rows[index2].Cells[5].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCustomerid.Text != "")
                {

                    Customer customer = new Customer();
                    if (tbCustomerName.Text != "" && tbCustomerSurname.Text != "" && tbCustomerMail.Text != "" && tbCustomerMail.Text.Contains('@') &&
                        tbCustomerMail.Text.EndsWith(".com") && mskCustomerphone.Text.Length == 14 && mskCustomerTc.Text.Length == 11 &&
                        customer.UpdateCustomer(int.Parse(lblCustomerid.Text.Trim()), tbCustomerName.Text.Trim(), tbCustomerSurname.Text.Trim(),
                        tbCustomerMail.Text.Trim(), mskCustomerphone.Text.Trim(), mskCustomerTc.Text.Trim()) > 0)
                    {
                        lblErrorforCustomerEdit.Text = "Update Successfully";
                        wait(1500);
                        GetCustomer_func();
                        ClearCustomerInfo();
                        lblErrorforCustomerEdit.Text = "";
                    }
                    else
                    {
                        lblErrorforCustomerEdit.Text = "Check Information";
                        wait(1000);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in Customer List");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbSearchCustomerbyName_TextChanged(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            dgvCustomerName.DataSource = customer.getCustomerlıkeName(tbSearchCustomerbyName.Text.Trim());
        }
        //Customer Bitiş

        //Product Management Başlangıç
        private void btnProductadd_Click(object sender, EventArgs e)
        {
            Add_Products ap = new Add_Products();
            ap.ShowDialog();
        }

        private void dgvProductShowforManege_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvProductShowforManege.SelectedCells[0].RowIndex;
                lblProductidM.Text = dgvProductShowforManege.Rows[index].Cells[1].Value.ToString();
                tbProductNameM.Text = dgvProductShowforManege.Rows[index].Cells[4].Value.ToString();
                cbProductbrandM.Text = dgvProductShowforManege.Rows[index].Cells[3].Value.ToString();
                cbProductCategorieM.Text = dgvProductShowforManege.Rows[index].Cells[2].Value.ToString();
                cbProductSuppliernameM.Text = dgvProductShowforManege.Rows[index].Cells[9].Value.ToString();
                tbProductCountM.Text = dgvProductShowforManege.Rows[index].Cells[5].Value.ToString();
                tbProductBuyingPriceM.Text = dgvProductShowforManege.Rows[index].Cells[6].Value.ToString();
                tbProductSalePriceM_C.Text = dgvProductShowforManege.Rows[index].Cells[8].Value.ToString();
                tbProductSalePriceM_A.Text = dgvProductShowforManege.Rows[index].Cells[7].Value.ToString();
                tbProductDiscountM.Text = dgvProductShowforManege.Rows[index].Cells[10].Value.ToString();
                tbPictureAdressM.Text = dgvProductShowforManege.Rows[index].Cells[11].Value.ToString();
                pbProductImage.ImageLocation = dgvProductShowforManege.Rows[index].Cells[11].Value.ToString();

                GetSupplierName();
                GetCategorieName();
                GetBrandName();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnProductRefresh_Click(object sender, EventArgs e)
        {
            tbSearchbyNameM.Text = "";
            cbSearchbyCategorieM.Text = "";
            cbSearchbyBrandM.Text = "";
            ShowDiscountProducts();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.DeleteProduct(Convert.ToInt16(lblProductidM.Text));
                lblProductMError.Text = "Deleting Successfully";
                wait(1000);
                lblProductMError.Text = "";
                ShowDiscountProducts();
                ClearProductInfoM();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Product List");
            }
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblProductidM.Text!="")
                {
  
                    Product product = new Product();
                    string categorieidgetch = "", brandidgetch = "", suppleridgetch = "";

                    DataTable dt = product.GetidFromCategorie(cbProductCategorieM.Text);
                    foreach (DataRow dr in dt.Rows)
                    {
                        categorieidgetch = dr["Categorieid"].ToString();
                    }
                    DataTable dt2 = product.GetidFromBrandName(cbProductbrandM.Text);
                    foreach (DataRow dr in dt2.Rows)
                    {
                        brandidgetch = dr["Brandid"].ToString();
                    }
                    DataTable dt3 = product.GetidFromSupplierName(cbProductSuppliernameM.Text);
                    foreach (DataRow dr in dt3.Rows)
                    {
                        suppleridgetch = dr["Supplierid"].ToString();
                    }
                    if (tbProductNameM.Text != "" && tbProductNameM.TextLength >= 3  &&
                        tbProductCountM.Text != ""  && tbProductBuyingPriceM.Text != "" && tbProductSalePriceM_A.Text != "" &&
                        tbProductSalePriceM_C.Text != "" && tbProductDiscountM.Text != "" && tbPictureAdressM.Text != "" && product.UpdateProduct(Convert.ToInt16(lblProductidM.Text.Trim()), 
                        tbPictureAdressM.Text.Trim(), Convert.ToInt16(categorieidgetch.Trim()), Convert.ToInt16(brandidgetch.Trim()), tbProductNameM.Text.Trim(),
                        Convert.ToInt16(tbProductCountM.Text.Trim()), Convert.ToInt16(tbProductBuyingPriceM.Text.Trim()), Convert.ToInt16(suppleridgetch.Trim()), 
                        Convert.ToInt16(tbProductSalePriceM_C.Text.Trim()),Convert.ToInt16(tbProductSalePriceM_A.Text.Trim()), Convert.ToInt16(tbProductDiscountM.Text.Trim())) > 0)
                    {
                        lblProductMError.Text = "Update Succesfully";
                        wait(1500);
                        lblProductMError.Text = "";
                        ClearProductInfoM();
                        ShowDiscountProducts();
                    }
                    else
                    {
                        lblProductMError.Text = "Check Every Information About Product";
                        wait(1000);

                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in Product List");
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbSearchbyNameM_TextChanged(object sender, EventArgs e)
        {
            Product product = new Product();
            dgvProductShowforManege.DataSource = product.GetByName(tbSearchbyNameM.Text.Trim());

            for (int i = 0; i < dgvProductShowforManege.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle();
                if (Convert.ToInt16(dgvProductShowforManege.Rows[i].Cells[10].Value) > 0)
                {
                    color.BackColor = Color.LightGreen;
                    color.ForeColor = Color.White;
                }
                dgvProductShowforManege.Rows[i].DefaultCellStyle = color;
            }


        }

        private void btnSearchM_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            dgvProductShowforManege.DataSource = product.SearchwithComboboxs(cbSearchbyCategorieM.Text.Trim(), cbSearchbyBrandM.Text.Trim());

            for (int i = 0; i < dgvProductShowforManege.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle();
                if (Convert.ToInt16(dgvProductShowforManege.Rows[i].Cells[10].Value) > 0)
                {
                    color.BackColor = Color.LightGreen;
                    color.ForeColor = Color.White;
                }
                dgvProductShowforManege.Rows[i].DefaultCellStyle = color;
            }

            if (cbSearchbyCategorieM.Text.Trim() == "" && cbSearchbyBrandM.Text.Trim() == "")
            {
                ShowDiscountProducts();
            }

        }


        //Product Management Bitiş

        //Product  Başlangıç

        private void tbSearchbyName_TextChanged(object sender, EventArgs e)
        {
            Product product = new Product();
            if (clienttypeforsearchname == "customer")
            {
                dgvProductShowforSale.DataSource = product.GetByNameForC(tbSearchbyName.Text.Trim());

                for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
                {
                    DataGridViewCellStyle color = new DataGridViewCellStyle();
                    if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                    {
                        color.BackColor = Color.LightGreen;
                    }
                    dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
                }
            }
            else
            {
                dgvProductShowforSale.DataSource = product.GetByNameForA(tbSearchbyName.Text.Trim());

                for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
                {
                    DataGridViewCellStyle color = new DataGridViewCellStyle();
                    if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                    {
                        color.BackColor = Color.LightGreen;
                    }
                    dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)       ///bu ürün satımında customermı artisan mı onu seçmemizi sağlıyor
        {
            selectproductwarning();
            //ClearProductInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            if (cbSearchbyCategorie.Text!="" || cbSearchbyBrand.Text!="")
            {
                if (clienttypeforsearchname == "customer")
                {
                    dgvProductShowforSale.DataSource = product.SearchwithComboboxsForC(cbSearchbyCategorie.Text.Trim(), cbSearchbyBrand.Text.Trim());

                    for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
                    {
                        DataGridViewCellStyle color = new DataGridViewCellStyle();
                        if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                        {
                            color.BackColor = Color.LightGreen;
                        }
                        dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
                    }
                }
                else
                {
                    dgvProductShowforSale.DataSource = product.SearchwithComboboxsForA(cbSearchbyCategorie.Text.Trim(), cbSearchbyBrand.Text.Trim());

                    for (int i = 0; i < dgvProductShowforSale.Rows.Count - 1; i++)
                    {
                        DataGridViewCellStyle color = new DataGridViewCellStyle();
                        if (Convert.ToInt16(dgvProductShowforSale.Rows[i].Cells[9].Value) > 0)
                        {
                            color.BackColor = Color.LightGreen;
                        }
                        dgvProductShowforSale.Rows[i].DefaultCellStyle = color;
                    }
                }
            }
            else
            {
                if (clienttypeforsearchname == "customer")
                {
                    ShowDiscountProductsC();
                }
                else
                {
                    ShowDiscountProductsA();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbSearchbyName.Text = "";
            cbSearchbyCategorie.Text = "";
            cbSearchbyBrand.Text = "";
            if (clienttypeforsearchname == "customer")
            {
                ShowDiscountProductsC();
            }
            else
            {
                ShowDiscountProductsA();
            }
        }

        private void dgvProductShowforSale_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==1 && e.RowIndex>=0)
            {
                pbProductForSale.ImageLocation = dgvProductShowforSale.Rows[dgvProductShowforSale.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                pbProductForSale.Visible = true;
            }
        }

        private void dgvProductShowforSale_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0 && e.RowIndex>=0)
            {
                pbProductForSale.ImageLocation = null;
                pbProductForSale.Visible = false;
            }
        }

        private void dgvProductShowforSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id="";
            try
            {
               
                int index = dgvProductShowforSale.SelectedCells[0].RowIndex;
                id= dgvProductShowforSale.Rows[index].Cells[2].Value.ToString();
                lblProductNameShow.Text = dgvProductShowforSale.Rows[index].Cells[6].Value.ToString();
                lblProductbrandShow.Text = dgvProductShowforSale.Rows[index].Cells[5].Value.ToString();
                lblProductCategorieShow.Text = dgvProductShowforSale.Rows[index].Cells[4].Value.ToString();
                lblProductPriceshow.Text = dgvProductShowforSale.Rows[index].Cells[8].Value.ToString();
                lblProductdiscountshow.Text = dgvProductShowforSale.Rows[index].Cells[9].Value.ToString();

                if (Convert.ToInt16(lblProductdiscountshow.Text)>0)
                {

                    int i = Convert.ToInt16(lblProductPriceshow.Text);
                    int j = Convert.ToInt16(lblProductdiscountshow.Text);
                    lblProductLastPrice.Text = Convert.ToString(i - j);
                }
                if (Convert.ToInt16(lblProductdiscountshow.Text)==0)
                {
                    lblProductLastPrice.Text = "";
                }
                if (e.ColumnIndex==0 && clienttypeforsearchname=="customer")
                {
                    Bag bag = new Bag();
                    int i = 0;
                    DataTable dt1 = bag.GetProductNameinBag();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (dr["ProductName"].ToString()== lblProductNameShow.Text)
                        {
                            MessageBox.Show("You Added This Product");
                            break;
                        }
                        i++;
                    }
                    if (i==dt1.Rows.Count)
                    {
                        if (lblProductLastPrice.Text != "")
                        {
                            if (bag.AddBag(Convert.ToInt16(id.Trim()), 1, Convert.ToInt16(lblProductLastPrice.Text)) > 0)
                            {
                                MessageBox.Show("Added To Bag");
                                GetProductinBag_C();
                            }
                        }
                        else
                        {
                            lblProductLastPrice.Text = lblProductPriceshow.Text;
                            if (bag.AddBag(Convert.ToInt16(id.Trim()), 1, Convert.ToInt16(lblProductLastPrice.Text)) > 0)
                            {
                                MessageBox.Show("Added To Bag");
                                GetProductinBag_C();
                            }
                        }
                    }

                }
                else if (e.ColumnIndex == 0 && clienttypeforsearchname == "artisan")
                {
                    Bag bag = new Bag();
                    int i = 0;
                    DataTable dt1 = bag.GetProductNameinBag();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (dr["ProductName"].ToString() == lblProductNameShow.Text)
                        {
                            MessageBox.Show("You Added This Product");
                            break;
                        }
                        i++;
                    }
                    if (i == dt1.Rows.Count)
                    {
                        if (lblProductLastPrice.Text != "")
                        {
                            if (bag.AddBag(Convert.ToInt16(id.Trim()), 1, Convert.ToInt16(lblProductLastPrice.Text)) > 0)
                            {
                                MessageBox.Show("Added To Bag");
                                GetProductinBag_A();
                            }
                        }
                        else
                        {
                            lblProductLastPrice.Text = lblProductPriceshow.Text;
                            if (bag.AddBag(Convert.ToInt16(id.Trim()), 1, Convert.ToInt16(lblProductLastPrice.Text)) > 0)
                            {
                                MessageBox.Show("Added To Bag");
                                GetProductinBag_A();
                            }
                        }
                    }
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        //Product Finish
        //Bag Start


        private void dgvBagProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                nudBagProductCount.Value = 0;
                tbBagProductTotal.Text = "";
                lblBagProductLastPrice.Text = "";
                int index = dgvBagProducts.SelectedCells[0].RowIndex;
                lblBagid.Text = dgvBagProducts.Rows[index].Cells[0].Value.ToString();
                lblBagProductName.Text= dgvBagProducts.Rows[index].Cells[1].Value.ToString();
                lblBagProductCategorie.Text= dgvBagProducts.Rows[index].Cells[2].Value.ToString();
                lblBagProductBrand.Text= dgvBagProducts.Rows[index].Cells[3].Value.ToString();
                lblBagProductPrice.Text= dgvBagProducts.Rows[index].Cells[4].Value.ToString();
                lblBagProductDiscount.Text= dgvBagProducts.Rows[index].Cells[5].Value.ToString();
                nudBagProductCount.Value= Convert.ToInt16( dgvBagProducts.Rows[index].Cells[7].Value.ToString());
                tbBagProductTotal.Text= dgvBagProducts.Rows[index].Cells[8].Value.ToString();
                pbBagProductImage.ImageLocation= dgvBagProducts.Rows[index].Cells[9].Value.ToString();

                if (Convert.ToInt16(lblBagProductDiscount.Text) > 0)
                {

                    int i = Convert.ToInt16(lblBagProductPrice.Text);
                    int j = Convert.ToInt16(lblBagProductDiscount.Text);
                    lblBagProductLastPrice.Text = Convert.ToString(i - j);

                }
                else
                {
                    lblBagProductLastPrice.Text = lblBagProductPrice.Text;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }


        private void dgvBagAdvantageousProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = "", saleprice = "", discount = "";
            string name = dgvBagAdvantageousProduct.Rows[dgvBagAdvantageousProduct.SelectedCells[0].RowIndex].Cells[6].Value.ToString();
            id= dgvBagAdvantageousProduct.Rows[dgvBagAdvantageousProduct.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            saleprice= dgvBagAdvantageousProduct.Rows[dgvBagAdvantageousProduct.SelectedCells[0].RowIndex].Cells[8].Value.ToString();
            discount= dgvBagAdvantageousProduct.Rows[dgvBagAdvantageousProduct.SelectedCells[0].RowIndex].Cells[9].Value.ToString();
            try
            {
                if (e.ColumnIndex == 0)
                {
                    Bag bag = new Bag();
                    int i = 0;
                    DataTable dt1 = bag.GetProductNameinBag();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (dr["ProductName"].ToString() == name.Trim())
                        {
                            MessageBox.Show("Alredy Added To Bag", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        i++;
                    }
                    if (i == dt1.Rows.Count)
                    {
                        int lastprice = Convert.ToInt16(saleprice) - Convert.ToInt16(discount);
                        if (bag.AddBag(Convert.ToInt16(id.Trim()), 1, Convert.ToInt16(lastprice)) > 0)
                        {
                            MessageBox.Show("You Added This Product");
                            if (clienttypeforsearchname=="customer")
                            {
                                GetProductinBag_C();
                            }
                            else
                            {
                                GetProductinBag_A();
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Choose anyone for the Process");
            }
        }

        private void btnBagDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienttypeforsearchname=="customer")
                {
                    Bag bag = new Bag();
                    bag.DeleteProductinBag(Convert.ToInt16(lblBagid.Text));
                    MessageBox.Show("Deleting Successfully");
                    GetProductinBag_C();
                    ClearBagInfo();
                }
                else
                {
                    Bag bag = new Bag();
                    bag.DeleteProductinBag(Convert.ToInt16(lblBagid.Text));
                    MessageBox.Show("Deleting Successfully");
                    GetProductinBag_A();
                    ClearBagInfo();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Product List");
            }
        }

        private void btnEditBag_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBagid.Text!="")
                {

                    Product product = new Product();
                    Bag bag = new Bag();
                    int count = 0;

                    DataTable dt = product.GetProductCountFromName(lblBagProductName.Text.Trim());
                    foreach (DataRow dr in dt.Rows)
                    {
                        count =Convert.ToInt16(dr["ProductCount"].ToString());
                    }
                    if (Convert.ToInt16(nudBagProductCount.Value)<count)
                    {
                        if (bag.EditProductinBag(Convert.ToInt16(lblBagid.Text),Convert.ToInt16(nudBagProductCount.Value),Convert.ToInt16(tbBagProductTotal.Text))>0 && clienttypeforsearchname=="customer")
                        {
                            MessageBox.Show("Update Successfull");
                            GetProductinBag_C();
                            ClearBagInfo();
                        }
                        else if (bag.EditProductinBag(Convert.ToInt16(lblBagid.Text), Convert.ToInt16(nudBagProductCount.Value), Convert.ToInt16(tbBagProductTotal.Text)) > 0 && clienttypeforsearchname == "artisan")
                        {
                            MessageBox.Show("Update Successfull");
                            GetProductinBag_A();
                            ClearBagInfo();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Decrase Your Product Count Which You will Buying");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in Product List");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Contact Your Programmer");
            }
        }

        private void nudBagProductCount_Leave(object sender, EventArgs e)   ///bu kısım bakılıcak
        {
            if (lblBagProductLastPrice.Text != "")
            {
                int price = Convert.ToInt16(lblBagProductLastPrice.Text);
                tbBagProductTotal.Text = Convert.ToString(Convert.ToInt16(nudBagProductCount.Value) * price);
            }
        }

        private void dgvBagAdvantageousProduct_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                pbBagDiscountProduct.ImageLocation = dgvBagAdvantageousProduct.Rows[dgvBagAdvantageousProduct.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                pbBagDiscountProduct.Visible = true;
            }
        }

        private void dgvBagAdvantageousProduct_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                pbBagDiscountProduct.ImageLocation = null;
                pbBagDiscountProduct.Visible = false;
            }
        }

        private void btnBagtoCasa_Click(object sender, EventArgs e)
        {
            GetBaginCasa();
            tabControl1.SelectedIndex = 3;
        }
        //Bag Finish
        //Announcement Start

        private void dgvAnnouncementAllProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //GetCreatedAnnouncement();
                lblAnnouncementid.Text = "";
                int index = dgvAnnouncementAllProduct.SelectedCells[0].RowIndex;
                lblAnnouncementProductid.Text = dgvAnnouncementAllProduct.Rows[index].Cells[0].Value.ToString();
                lblAnnouncementProductname.Text= dgvAnnouncementAllProduct.Rows[index].Cells[3].Value.ToString();
                lblAnnouncementProductbrand.Text= dgvAnnouncementAllProduct.Rows[index].Cells[2].Value.ToString();
                lblAnnouncementProductsalaryC.Text= dgvAnnouncementAllProduct.Rows[index].Cells[7].Value.ToString();
                lblAnnouncementProductsalaryA.Text = dgvAnnouncementAllProduct.Rows[index].Cells[6].Value.ToString();
                pbAnnouncementProductımage.ImageLocation= dgvAnnouncementAllProduct.Rows[index].Cells[10].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Product List");
            }
        }

        private void dgvAnnouncementCreated_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                ClearAnnouncementInfo();
                int id = Convert.ToInt16(dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                int productid = Convert.ToInt16(dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[7].Value.ToString());

                lblAnnouncementProductid.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[7].Value.ToString();
                lblAnnouncementid.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                lblAnnouncementProductname.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
                tbAnnouncementProductDiscount.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                rtbAnnouncementText.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                dtpAnnouncementStartdate.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[6].Value.ToString();
                lblAnnouncementProductbrand.Text = dgvAnnouncementCreated.Rows[dgvAnnouncementCreated.SelectedCells[0].RowIndex].Cells[3].Value.ToString();

                if (e.ColumnIndex==0)
                {
                    if (MessageBox.Show("Announcement will Completily Deleting, Do You Want it ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                        Announcement announcement = new Announcement();
                        announcement.DeleteAnnouncement(id, productid);
                        MessageBox.Show("Delete Succesfull");
                        GetCreatedAnnouncement();
                        GetProductwithoutDiscountforAnnouncement();
                        ClearAnnouncementInfo();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not Any Announcement");
            }
        }

        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
        {
            if (lblAnnouncementid.Text=="")
            {
                Announcement announcement = new Announcement();
                try
                {
                    string time = dtpAnnouncementStartdate.Value.ToShortDateString();
                    if (lblAnnouncementProductid.Text.Equals(""))
                    {
                        lblAnnouncementError.Text = "Please Select One in Product List ";
                        wait(1000);
                        lblAnnouncementError.Text = "";
                        return;
                        
                    }
                    if (tbAnnouncementProductDiscount.Text.Equals(""))
                    {
                        lblAnnouncementError.Text = "Enter The Discount";
                        wait(1000);
                        lblAnnouncementError.Text = "";
                        return;
                    }
                    else
                    {
                        if (announcement.AddAnnouncement(rtbAnnouncementText.Text.Trim(), Convert.ToInt16(lblAnnouncementProductid.Text.Trim()), time.Trim(), Convert.ToInt16(tbAnnouncementProductDiscount.Text.Trim())) > 1)
                        {
                            MessageBox.Show("Announcement Added Successfully");
                        }
                        ClearAnnouncementInfo();
                        GetCreatedAnnouncement();
                        GetProductwithoutDiscountforAnnouncement();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Choose anyone for the Process or Check Date");
                }
            }
        }

        private void btnAnnouncementProductedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAnnouncementid.Text!="" && Convert.ToInt16(tbAnnouncementProductDiscount.Text)>0)
                {
                    Announcement announcement = new Announcement();
                    if (announcement.UpdateAnnouncement(Convert.ToInt16(lblAnnouncementid.Text),Convert.ToInt16(lblAnnouncementProductid.Text),rtbAnnouncementText.Text,Convert.ToInt16(tbAnnouncementProductDiscount.Text),Convert.ToString(dtpAnnouncementStartdate.Value))>0)
                    {
                        MessageBox.Show("Update Successfully");
                        ClearAnnouncementInfo();
                        GetCreatedAnnouncement();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in Announcement list");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Announcement Finish
        //Cash Start
        private void dgvCasaClientName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvCasaClientName.SelectedCells[0].RowIndex;
                lblCasaClientid.Text = dgvCasaClientName.Rows[index].Cells[0].Value.ToString();
                lblCasaClientName.Text= dgvCasaClientName.Rows[index].Cells[1].Value.ToString();
                lblCasaClientSurname.Text= dgvCasaClientName.Rows[index].Cells[2].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Client List");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvCasaListBag.DataSource==null)
            {
                MessageBox.Show("Please Go to Bag And Select  'Go To Casa' Button");
            }
            else
            {
                try
                {
                    cbCashMovement.Items.Clear();
                    cbCashType.Items.Clear();
                    cbCasaAdminName.Items.Clear();
                    Bag bag = new Bag();
                    DataTable dt = bag.GetProductinBag();
                    int aracı = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        aracı += Convert.ToInt16(dr["Price"].ToString());
                    }
                    lblCasaTotal.Text = Convert.ToString(aracı);

                    Casa casa = new Casa();
                    DataTable dt2 = casa.GetCashMovement();
                    foreach (DataRow dr in dt2.Rows)
                    {
                        cbCashMovement.Items.Add(dr["CashMovementName"].ToString());
                    }
                    DataTable dt3 = casa.GetCashType();
                    foreach (DataRow dr in dt3.Rows)
                    {
                        cbCashType.Items.Add(dr["CashTypeName"].ToString());
                    }
                    Admin admin = new Admin();
                    DataTable dt4 = admin.getAdmin();
                    foreach (DataRow dr in dt4.Rows)
                    {
                        cbCasaAdminName.Items.Add(dr["AdminName"].ToString());
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (clienttypeforsearchname=="customer")
            {
                Customer customer = new Customer();
                dgvCasaClientName.DataSource = customer.getCustomerlıkeName(textBox1.Text.Trim());
            }
            else if (clienttypeforsearchname=="artisan")
            {
                Artisan artisan = new Artisan();
                dgvCasaClientName.DataSource = artisan.getArtisanlıkeName(textBox1.Text.Trim());
            }
        }

        private void btnCasaCreateContrat_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 20, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 15, FontStyle.Regular);
        Font icerik = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Enway", Baslik,sb,350, 100, st);

            e.Graphics.DrawString("Product Name                  Count       Price", altBaslik, sb, 100, 250, st);
            e.Graphics.DrawString("------------------------------------------------------------------", altBaslik, sb, 100, 280, st);
            for (int i = 0; i < dgvCasaListBag.Rows.Count-1; i++)
            {
                e.Graphics.DrawString(dgvCasaListBag.Rows[i].Cells[2].Value.ToString(), icerik, sb, 100, 320 +( i * 40), st);
                e.Graphics.DrawString(dgvCasaListBag.Rows[i].Cells[3].Value.ToString(), icerik, sb, 400, 320 + (i * 40), st);
                e.Graphics.DrawString(dgvCasaListBag.Rows[i].Cells[4].Value.ToString(), icerik, sb, 500, 320 + (i * 40), st);
            }
            e.Graphics.DrawString("------------------------------------------------------------------", altBaslik, sb, 100, 340 + (40 * dgvCasaListBag.Rows.Count), st);
            e.Graphics.DrawString("Admin Name    : " +lblCasaClientName.Text+ " " , altBaslik, sb, 330, 380 + 30 * (dgvCasaListBag.Rows.Count+1), st);
            e.Graphics.DrawString("Cash Type   : " +cbCashType.Text, altBaslik, sb, 360, 380 + 30 * (dgvCasaListBag.Rows.Count+2), st);
            e.Graphics.DrawString("Cash Movement : " + cbCashMovement.Text, altBaslik, sb, 320, 380 + 30 * (dgvCasaListBag.Rows.Count + 3), st);
            e.Graphics.DrawString("            Total : " + lblCasaTotal.Text + " TL  ", altBaslik, sb, 340, 380 + 30 * (dgvCasaListBag.Rows.Count + 4), st);
        }

        private void btnCasaComplete_Click(object sender, EventArgs e)
        {
           
            try
            {
                string Cashmovementidgetch = "", CashTypeidgetch = "", adminid="";
                Casa casa = new Casa();
                DataTable dt = casa.GetidfromCashmovement(cbCashMovement.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    Cashmovementidgetch = dr["id"].ToString();
                }
                DataTable dt2 = casa.GetidfromCashtype(cbCashType.Text);
                foreach (DataRow dr2 in dt.Rows)
                {
                    CashTypeidgetch = dr2["id"].ToString();
                }

                Admin admin = new Admin();
                DataTable dt4 = admin.GetidfromName(cbCasaAdminName.Text);
                foreach (DataRow dr in dt4.Rows)
                {
                    adminid = dr["Adminid"].ToString();
                }

                lblErrorforCasaEdit.Text = "";
                if (lblCasaClientid.Text == "" && lblCasaClientName.Text == "" && lblCasaClientSurname.Text == "")
                {
                    lblErrorforCasaEdit.Text = "Please Select One in Client List";
                    return;
                }
                if (lblCasaTotal.Text == "")
                {
                    lblErrorforCasaEdit.Text = "Please Enter The Calculate Button For The Sale";
                    return;
                }
                if (cbCashType.Text == "")
                {
                    lblErrorforCasaEdit.Text = "Please Select Cash Type";
                    return;
                }
                if (cbCashMovement.Text == "")
                {
                    lblErrorforCasaEdit.Text = "Please Select Cash Movement";
                    return;
                }
                if (cbCasaAdminName.Text == "")
                {
                    lblErrorforCasaEdit.Text = "Please Select Admin Name";
                    return;
                }

                else
                {
                    if (lblCasaClientid.Text != "" && lblCasaTotal.Text != "" && cbCashType.SelectedIndex >= 0 && cbCashMovement.SelectedIndex >= 0 &&
                   casa.AddCasa(Convert.ToInt16(lblCasaClientid.Text), lblclienttype.Text, Convert.ToInt16(CashTypeidgetch.Trim()), Convert.ToInt16(Cashmovementidgetch.Trim()),
                   dtpCasatime.Value.ToShortDateString(), Convert.ToInt16(lblCasaTotal.Text), Convert.ToInt16(adminid)) > 0)

                    {
                        if (MessageBox.Show("Do You Want To Print The Ticket", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            printPreviewDialog1.ShowDialog();
                        }
                        Bag bag = new Bag();
                        DataTable dt3 = bag.GetProductinBag();
                        foreach (DataRow dr in dt3.Rows)
                        {
                            casa.EditProductinCasa(Convert.ToInt16(dr["Productid"].ToString()), Convert.ToInt16(dr["ProductCount"].ToString()));
                        }
                        if (bag.DeleteAllProductsinBag() > 0)
                        {
                            MessageBox.Show("Your Sale has been Successfully Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            ClearCasaInfo();
                            tabControl1.SelectedIndex = 1;
                            ClearBagInfo();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProductDetails_Click(object sender, EventArgs e)
        {
            ProductsDetails productsDetails = new ProductsDetails(lbl__Name.Text);
            productsDetails.Show();
            this.Close();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            tbPictureAdressM.Text = "";
            openFileDialog1.ShowDialog();
            pbProductImage.ImageLocation = openFileDialog1.FileName;
            tbPictureAdressM.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashDetails cashDetails = new CashDetails(lbl__Name.Text);
            cashDetails.Show();
            this.Close();

        }

    }
}