using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ENWAY
{
    public partial class ProductsDetails : Form
    {

        public ProductsDetails(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void ProductsDetails_Load(object sender, EventArgs e)
        {
            int count=0;
            if (Text != null)
            {
                lbl__Name.Text = Text;
            }

            Product product = new Product();
            DataTable dt = product.GetProductCountRelation();
            foreach (DataRow dr in dt.Rows)
            {
                chart1.Series[","].Points.AddXY(dr["ProductName"].ToString(), dr["ProductCount"]);
                count += Convert.ToInt16(dr["ProductCount"]);
            }
            lblProductCount.Text = count.ToString();
            

            DataTable dt2 = product.GetProductCategorieRelation();
            foreach (DataRow dr2 in dt2.Rows)
            {
                chart2.Series["."].Points.AddXY(dr2["CategorieName"].ToString(), dr2["ProductCount"]);
            }

            DataTable dt3 = product.GetProductBrandRelation();
            foreach (DataRow dr3 in dt3.Rows)
            {
                chart3.Series["-"].Points.AddXY(dr3["BrandName"].ToString(), dr3["ProductCount"]);
            }

        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            Enway enway = new Enway();
            enway.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Enway enway = new Enway();
            enway.Show();
            this.Close();

        }

    }
}
