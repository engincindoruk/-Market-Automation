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
    public partial class Add_Products : Form
    {
        public Add_Products()
        {
            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            tbPictureAdress.Text = "";
            openFileDialog1.ShowDialog();
            pbProductImage.ImageLocation = openFileDialog1.FileName;
            tbPictureAdress.Text = openFileDialog1.FileName;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbProductName.Text = "";
            cbProductCategorie.Text = "";
            cbProductBrand.Text = "";
            tbProductCount.Text = "";
            cbProductSupplierName.Text = "";
            pbProductImage.Image = null;
            tbProductBuyprice.Text = "";
            tbProductSalePriceA.Text = "";
            tbProductSalePriceC.Text = "";
            tbProductDiscount.Text = "";
        }

        public void RefreshComboboxs()
        {
            cbProductSupplierName.Items.Clear();
            cbProductCategorie.Items.Clear();
            cbProductBrand.Items.Clear();

            Product product = new Product();
            DataTable dt = product.GetSupplierName();
            foreach (DataRow dr in dt.Rows)
            {
                cbProductSupplierName.Items.Add(dr["SupplierName"].ToString());
            }
            DataTable dt2 = product.GetCategorieName();
            foreach (DataRow dr in dt2.Rows)
            {
                cbProductCategorie.Items.Add(dr["CategorieName"].ToString());
            }
            DataTable dt3 = product.GetBrandName();
            foreach (DataRow dr in dt3.Rows)
            {
                cbProductBrand.Items.Add(dr["BrandName"].ToString());
            }
        }

        private void Add_Products_Load(object sender, EventArgs e)
        {
            RefreshComboboxs();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            lblError.Text = "";
            if (tbProductName.Text == "" || tbProductName.TextLength < 3)
            {
                lblError.Text = "Please Check Product Name";
                tbProductName.Focus();
                return;
            }
            if (cbProductCategorie.SelectedIndex < 0)
            {
                lblError.Text = "Please Select Product Categorie";
                cbProductCategorie.Focus();
                return;
            }
            if (cbProductBrand.SelectedIndex < 0)
            {
                lblError.Text = "Please Select Product Brand";
                cbProductBrand.Focus();
                return;
            }
            if (tbProductCount.Text == "")
            {
                lblError.Text = "Please Enter Product Count";
                tbProductCount.Focus();
                return;
            }
            if (cbProductSupplierName.SelectedIndex < 0)
            {
                lblError.Text = "Please Select Product Supplier Name";
                cbProductSupplierName.Focus();
                return;
            }
            if (tbProductBuyprice.Text == "")
            {
                lblError.Text = "Please Enter Product Buying Price";
                tbProductBuyprice.Focus();
                return;
            }
            if (tbProductSalePriceC.Text == "")
            {
                lblError.Text = "Please Enter Product Sale Price For Customer";
                tbProductSalePriceC.Focus();
                return;
            }
            if (tbProductSalePriceA.Text == "")
            {
                lblError.Text = "Please Enter Product Sale Price For Artisan";
                tbProductSalePriceA.Focus();
                return;
            }
            if (tbProductDiscount.Text == "")
            {
                lblError.Text = "Please Enter Product Discount";
                tbProductDiscount.Focus();
                return;
            }
            if (tbPictureAdress.Text == "")
            {
                lblError.Text = "Please Choose Image For Product";
                tbPictureAdress.Focus();
                return;
            }
            else
            {
                int i = 0;
                DataTable dt1 = product.GetProductName();
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr["ProductName"].ToString()==tbProductName.Text.Trim())
                    {
                        MessageBox.Show("You Have This Product");
                        break;
                    }
                    i++;
                }
                if (i==dt1.Rows.Count)
                {
                    string categorieidgetch = "", brandidgetch = "", suppleridgetch = "";
                    DataTable dt = product.GetidFromCategorie(cbProductCategorie.Text);
                    foreach (DataRow dr in dt.Rows)
                    {
                        categorieidgetch = dr["Categorieid"].ToString();
                    }
                    DataTable dt2 = product.GetidFromBrandName(cbProductBrand.Text);
                    foreach (DataRow dr in dt2.Rows)
                    {
                        brandidgetch = dr["Brandid"].ToString();
                    }
                    DataTable dt3 = product.GetidFromSupplierName(cbProductSupplierName.Text);
                    foreach (DataRow dr in dt3.Rows)
                    {
                        suppleridgetch = dr["Supplierid"].ToString();
                    }
                    if (product.AddProduct(tbPictureAdress.Text.Trim(), Convert.ToInt16(categorieidgetch.Trim()), Convert.ToInt16(brandidgetch.Trim()),
                        tbProductName.Text.Trim(), Convert.ToInt16(tbProductCount.Text.Trim()), Convert.ToInt16(tbProductBuyprice.Text.Trim()),
                        Convert.ToInt16(suppleridgetch.Trim()), Convert.ToInt16(tbProductSalePriceC.Text.Trim()), Convert.ToInt16(tbProductSalePriceA.Text.Trim()),
                        Convert.ToInt16(tbProductDiscount.Text.Trim())) > 0)
                    {
                        MessageBox.Show("Product Added Successfully");
                    }
                }
              
            }
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            Suppliersadd_screen ss = new Suppliersadd_screen();
            ss.ShowDialog();
            RefreshComboboxs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshComboboxs();
        }

        private void btnAddCategorie_Click(object sender, EventArgs e)
        {
            if (cbProductCategorie.Text.Trim() !="")
            {
                Product product = new Product();
                int i = 0;
                while (i<cbProductCategorie.Items.Count)
                {
                    if (cbProductCategorie.Items[i].ToString() == cbProductCategorie.Text)
                    {
                        MessageBox.Show("You Have This Categorie");
                        break;
                    }
                    i++;
                }
                if (i==cbProductCategorie.Items.Count)
                {
                    product.AddCategorie(cbProductCategorie.Text);
                    MessageBox.Show("Categorie Added Succesfully");
                    RefreshComboboxs();
                }
            }
            else
            {
                MessageBox.Show("Enter The Categorie Name for Add");
            }

        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (cbProductBrand.Text.Trim() != "")
            {
                Product product = new Product();
                int i = 0;
                while (i < cbProductBrand.Items.Count)
                {
                    if (cbProductBrand.Items[i].ToString() == cbProductBrand.Text)
                    {
                        MessageBox.Show("You Have This Brand");
                        break;
                    }
                    i++;
                }
                if (i == cbProductBrand.Items.Count)
                {
                    product.AddBrand(cbProductBrand.Text);
                    MessageBox.Show("Brand Added Succesfully");
                    RefreshComboboxs();
                }
            }
            else
            {
                MessageBox.Show("Enter The Brand Name for Add");
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
