using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Bag
    {
        private int _Bagid;
        private int _Productid;
        private int _Count;
        private int _Price;

        public int Bagid { get => _Bagid; set => _Bagid = value; }
        public int Productid { get => _Productid; set => _Productid = value; }
        public int Count1 { get => _Count; set => _Count = value; }
        public int Price { get => _Price; set => _Price = value; }

        public int AddBag(int productid, int count, int price)
        {
            string query = string.Format("INSERT INTO Tbl_Bag(Productid,ProductCount,Price) VALUES({0},{1},{2})", productid, count, price);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetProductCountToPriceinBag(int id)
        {
            string query = string.Format("select Tbl_Bag.ProductCount,Tbl_Bag.Price from Tbl_Bag where Bagid={0}", id);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductNameinBag()
        {
            string query = "select Tbl_Products.ProductName from Tbl_Bag " +
                "join Tbl_Products on Tbl_Bag.Productid=Tbl_Products.Productid";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetProductinBag_C()
        {
            string query = "select Tbl_Bag.Bagid,Tbl_Products.ProductName,Tbl_Categorie.CategorieName,Tbl_Brand.BrandName,Tbl_Products.SalePriceC AS SalePrice, " +
                " Tbl_Products.Discount,Tbl_Products.ProductCount AS Total_Count,Tbl_Bag.ProductCount,Tbl_Bag.Price AS Total,Tbl_Products.ProductImage AS Image from Tbl_Bag " +
                " join Tbl_Products on Tbl_Bag.Productid=Tbl_Products.Productid " +
                " join Tbl_Categorie on Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                " join Tbl_Brand on Tbl_Products.ProductBrandid=Tbl_Brand.Brandid ";
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetProductinBag_A()
        {
            string query = "select Tbl_Bag.Bagid,Tbl_Products.ProductName,Tbl_Categorie.CategorieName,Tbl_Brand.BrandName,Tbl_Products.SalePriceA AS SalePrice, " +
               " Tbl_Products.Discount,Tbl_Products.ProductCount AS Total_Count,Tbl_Bag.ProductCount,Tbl_Bag.Price AS Total,Tbl_Products.ProductImage AS Image from Tbl_Bag " +
               " join Tbl_Products on Tbl_Bag.Productid=Tbl_Products.Productid " +
               " join Tbl_Categorie on Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
               " join Tbl_Brand on Tbl_Products.ProductBrandid=Tbl_Brand.Brandid ";
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetProductinBag()
        {
            string query = "select Tbl_Bag.Bagid,Tbl_Bag.Productid,Tbl_Products.ProductName,Tbl_Bag.ProductCount,Tbl_Bag.Price from Tbl_Bag " +
                "join Tbl_Products on Tbl_Bag.Productid=Tbl_Products.Productid";
            return DataAccess.ExecuteQuery(query);
        }

        public int DeleteAllProductsinBag()
        {
            string query = "delete from Tbl_Bag";
            return DataAccess.ExecuteNonQuery(query);
        }
        public int DeleteProductinBag(int id)
        {
            string query = string.Format("Delete from Tbl_Bag Where Bagid={0}", id);
            return DataAccess.ExecuteNonQuery(query); 
        }

        public int EditProductinBag(int id,int productcount,int price)
        {
            string query = string.Format("UPDATE Tbl_Bag SET ProductCount={0},Price={1} where Bagid={2}", productcount, price, id);
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}
