using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Product
    {
        private int _Productid;
        private string _Picture;
        private int _Categorieid;
        private int _Brandid;
        private string _Name;
        private int _Count;
        private int _Buyprice;
        private int _Supplierid;
        private int _SalepriceC;
        private int _SalepriceA;
        private int _Discount;

        public int Id { get => _Productid; set => _Productid = value; }
        public string Picture { get => _Picture; set => _Picture = value; }
        public int Categorieid { get => _Categorieid; set => _Categorieid = value; }
        public int Brandid { get => _Brandid; set => _Brandid = value; }
        public string Name { get => _Name; set => _Name = value; }
        public int Count { get => _Count; set => _Count = value; }
        public int Buyprice { get => _Buyprice; set => _Buyprice = value; }
        public int Supplierid { get => _Supplierid; set => _Supplierid = value; }
        public int SalepriceC { get => _SalepriceC; set => _SalepriceC = value; }
        public int SalepriceA { get => _SalepriceA; set => _SalepriceA = value; }
        public int Discount { get => _Discount; set => _Discount = value; }

        public DataTable GetProductCountRelation()
        {
            string query = "SELECT DISTINCT Tbl_Products.ProductName ,Tbl_Products.ProductCount FROM Tbl_Products";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductCategorieRelation()
        {
            string query = "SELECT  Tbl_Categorie.CategorieName ,Tbl_Products.ProductCount FROM Tbl_Products "+
                            " JOIN Tbl_Categorie ON Tbl_Categorie.Categorieid = Tbl_Products.ProductCategorieid";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductBrandRelation()
        {
            string query = "SELECT  Tbl_Brand.BrandName ,Tbl_Products.ProductCount FROM Tbl_Products "+ 
                            " JOIN Tbl_Brand ON Tbl_Brand.Brandid = Tbl_Products.ProductCategorieid ";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductCountFromName(string name)
        {
            string query = string.Format("select Tbl_Products.ProductCount from Tbl_Products where ProductName='{0}'", name);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetDiscountProductforbag_C()
        {
            try
            {
                string query = "Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName," +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount," +
                "Tbl_Products.SalePriceC AS SalePrice,Tbl_Products.Discount " +
                "from Tbl_Products " +
                "JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                " where Discount>0";
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDiscountProductforbag_A()
        {
            try
            {
                string query = "Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName," +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount," +
                "Tbl_Products.SalePriceA AS SalePrice,Tbl_Products.Discount " +
                "from Tbl_Products " +
                "JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                " where Discount>0";
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable GetAllProducts()
        {
            try
            {
                string query = "Select Tbl_Products.Productid,Tbl_Categorie.CategorieName," +
                    "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount,Tbl_Products.BuyPrice," +
                    "Tbl_Products.SalePriceA,Tbl_Products.SalePriceC,Tbl_Suppliers.SupplierName ,Tbl_Products.Discount,Tbl_Products.ProductImage  " +
                    "from Tbl_Products " +
                    " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                    " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid=Tbl_Brand.Brandid " +
                    " JOIN  Tbl_Suppliers ON Tbl_Products.Supplierid=Tbl_Suppliers.Supplierid";
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetProductName()//bunu ürün eklemede eğer aynı adda ürün varsa eklememek için kontrol ettiriyorum.
        {
            string query = "Select Tbl_Products.ProductName from Tbl_Products";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetByName(string name)
        {
            try
            {
                string query =string.Format( "Select Tbl_Products.Productid,Tbl_Categorie.CategorieName," +
                     "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount,Tbl_Products.BuyPrice," +
                     "Tbl_Products.SalePriceA,Tbl_Products.SalePriceC,Tbl_Suppliers.SupplierName ,Tbl_Products.Discount,Tbl_Products.ProductImage  " +
                     "from Tbl_Products " +
                     " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                     " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid=Tbl_Brand.Brandid " +
                     " JOIN  Tbl_Suppliers ON Tbl_Products.Supplierid=Tbl_Suppliers.Supplierid where ProductName LIKE '{0}%' ",name);
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetByNameForC(string name)
        {
            string query = string.Format("Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName, " +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount, " +
                "Tbl_Products.SalePriceC AS SalePrice,Tbl_Products.Discount " +
                " from Tbl_Products " +
                " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid  " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                "where ProductName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetByNameForA(string name)
        {
            string query = string.Format("Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName, " +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount, " +
                "Tbl_Products.SalePriceA AS SalePrice,Tbl_Products.Discount " +
                " from Tbl_Products " +
                " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid  " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                "where ProductName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }



        public DataTable GetSupplierName()
        {
            string query = "select Tbl_Suppliers.SupplierName from Tbl_Suppliers";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCategorieName()
        {
            string query = "Select Tbl_Categorie.CategorieName from Tbl_Categorie";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetBrandName()
        {
            string query = "Select Tbl_Brand.BrandName from Tbl_Brand";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetidFromCategorie(string categoriename)
        {
            string query = string.Format("select Tbl_Categorie.Categorieid from Tbl_Categorie where CategorieName='{0}'", categoriename);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetidFromSupplierName(string suppliername)
        {
            string query = string.Format("select Tbl_Suppliers.Supplierid from Tbl_Suppliers where SupplierName='{0}'", suppliername);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetidFromBrandName(string brandname)
        {
            string query = string.Format("select Tbl_Brand.Brandid from Tbl_Brand where BrandName='{0}'", brandname);
            return DataAccess.ExecuteQuery(query);
        }


        public DataTable GetAllProductforSaleC()
        {
            try
            {
                string query = "Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName," +
                    "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount," +
                    "Tbl_Products.SalePriceC AS SalePrice,Tbl_Products.Discount " +
                    "from Tbl_Products " +
                    "JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid " +
                    " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid";
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAllProductforSaleA()
        {
            try
            {
                string query = "Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName," +
                    "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount," +
                    "Tbl_Products.SalePriceA AS SalePrice,Tbl_Products.Discount " +
                    " from Tbl_Products " +
                    "JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                    " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid=Tbl_Brand.Brandid ";
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int AddProduct(string picture, int categorieid, int brandid, string name, int count, int buyprice, int supplierid, int salepriceC, int salepriceA, int discount)
        {
            try
            {
                string query = string.Format("INSERT INTO Tbl_Products(ProductImage,ProductCategorieid,ProductBrandid,ProductName,ProductCount,BuyPrice,Supplierid,SalePriceC,SalePriceA,Discount) " +
                " VALUES('{0}',{1},{2},'{3}',{4},{5},{6},{7},{8},{9})", picture, categorieid, brandid, name, count, buyprice, supplierid, salepriceC, salepriceA, discount);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public int AddCategorie(string name)
        {
            string query = string.Format("INSERT INTO Tbl_Categorie(CategorieName) VALUES('{0}')", name);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int AddBrand(string name)
        {
            string query = string.Format("INSERT INTO Tbl_Brand(BrandName) VALUES('{0}')", name);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int DeleteProduct(int id)
        {
            string query = "Delete FROM Tbl_Products WHERE Productid=" + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public int UpdateProduct(int id, string picture, int categorieid, int brandid, string name, int count, int buyprice, int supplierid, int salepriceC, int salepriceA, int discount)
        {
            string query = string.Format("UPDATE Tbl_Products SET ProductImage='{0}', " +
                " ProductCategorieid={1}, " +
                " ProductBrandid={2}, " +
                " ProductName='{3}', " +
                " ProductCount={4}, " +
                " BuyPrice={5}, " +
                " Supplierid={6}, " +
                " SalePriceC={7}, " +
                " SalePriceA={8}, " +
                " Discount={9} " +
                " WHERE Productid={10}", picture, categorieid, brandid, name, count, buyprice, supplierid, salepriceC, salepriceA, discount, id);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable SearchwithComboboxs(string categorie, string brand)
        {

            string query = string.Format("Select Tbl_Products.Productid,Tbl_Categorie.CategorieName," +
                    "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount,Tbl_Products.BuyPrice," +
                    "Tbl_Products.SalePriceA,Tbl_Products.SalePriceC,Tbl_Suppliers.SupplierName ,Tbl_Products.Discount,Tbl_Products.ProductImage  " +
                    "from Tbl_Products " +
                    " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                    " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid=Tbl_Brand.Brandid " +
                    " JOIN  Tbl_Suppliers ON Tbl_Products.Supplierid=Tbl_Suppliers.Supplierid where CategorieName='{0}' OR BrandName='{1}' ", categorie, brand);
            return DataAccess.ExecuteQuery(query);

        }


        public DataTable SearchwithComboboxsForC(string categorie, string brand)
        {
            string query = string.Format("Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName, " +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount, " +
                "Tbl_Products.SalePriceC AS SalePrice,Tbl_Products.Discount " +
                " from Tbl_Products " +
                " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid  " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                " where CategorieName='{0}' OR BrandName='{1}' ", categorie, brand);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable SearchwithComboboxsForA(string categorie, string brand)
        {
            string query = string.Format("Select Tbl_Products.Productid,Tbl_Products.ProductImage,Tbl_Categorie.CategorieName, " +
                "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount, " +
                "Tbl_Products.SalePriceA AS SalePrice,Tbl_Products.Discount " +
                " from Tbl_Products " +
                " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid = Tbl_Categorie.Categorieid  " +
                " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid = Tbl_Brand.Brandid " +
                " where CategorieName='{0}' OR BrandName='{1}' ", categorie, brand);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductWithoutDiscountForAnnouncement()
        {
            string query = "Select Tbl_Products.Productid,Tbl_Categorie.CategorieName," +
                    "Tbl_Brand.BrandName,Tbl_Products.ProductName,Tbl_Products.ProductCount,Tbl_Products.BuyPrice," +
                    "Tbl_Products.SalePriceA,Tbl_Products.SalePriceC,Tbl_Suppliers.SupplierName ,Tbl_Products.Discount,Tbl_Products.ProductImage  " +
                    "from Tbl_Products " +
                    " JOIN  Tbl_Categorie ON Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                    " JOIN  Tbl_Brand ON Tbl_Products.ProductBrandid=Tbl_Brand.Brandid " +
                    " JOIN  Tbl_Suppliers ON Tbl_Products.Supplierid=Tbl_Suppliers.Supplierid  where Discount=0";
            return DataAccess.ExecuteQuery(query);
        }
    }
}
