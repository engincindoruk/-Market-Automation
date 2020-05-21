using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Announcement
    {
        private int _Announcementid;
        private string _Text;
        private int _Productid;
        private DateTime _Startdate;

        public int Id1 { get => _Announcementid; set => _Announcementid = value; }
        public string Text { get => _Text; set => _Text = value; }
        public int Productid { get => _Productid; set => _Productid = value; }
        public DateTime Startdate { get => _Startdate; set => _Startdate = value; }


        public DataTable GetAnnouncement()
        {
            string query = "select Tbl_Announcement.Announcementid,Tbl_Announcement.Announcementtext,Tbl_Brand.BrandName AS Brand, " +
                "Tbl_Products.ProductName,Tbl_Products.Discount, " +
                "Tbl_Announcement.StartDate,Tbl_Products.Productid,Tbl_Products.ProductImage  from Tbl_Announcement  " +
                "join Tbl_Products on Tbl_Announcement.Productid=Tbl_Products.Productid " +
                "join Tbl_Categorie on Tbl_Products.ProductCategorieid=Tbl_Categorie.Categorieid " +
                "join Tbl_Brand on Tbl_Products.ProductBrandid=Tbl_Brand.Brandid ";
            return DataAccess.ExecuteQuery(query);
        }


        public int DeleteAnnouncement(int id,int productid)
        {
            string query = string.Format("delete from Tbl_Announcement where Announcementid={0}", id);
            //return DataAccess.ExecuteNonQuery(query);
            string query2 = "";
            int dt = 0;
            if (DataAccess.ExecuteNonQuery(query)>0)
            {
                query2= string.Format("UPDATE Tbl_Products SET Discount=0 WHERE Productid={0}", productid);
                dt = DataAccess.ExecuteNonQuery(query2);
            }
            return dt;
        }

        public int AddAnnouncement(string text, int productid, string startdate, int discount)
        {
            string query = string.Format("UPDATE Tbl_Products SET Discount={0} WHERE Productid={1}", discount, productid);
            string query2 = "";
            int dt = 0;
            if (DataAccess.ExecuteNonQuery(query) > 0)
            {
                query2 = string.Format("INSERT INTO Tbl_Announcement(Announcementtext,Productid,StartDate) VALUES('{0}',{1},'{2}')", text, productid, startdate);
                dt = DataAccess.ExecuteNonQuery(query2);
            }
            return dt;
        }

        public int UpdateAnnouncement(int id,int productid,string text,int discount,string time)
        {
            string query = string.Format("UPDATE Tbl_Announcement SET Announcementtext='{0}',StartDate='{1}' WHERE Announcementid={2} ", text,time,id);
            string query2 = "";
            int dt = 0;
            if (DataAccess.ExecuteNonQuery(query)>0)
            {
                query2 = string.Format("UPDATE Tbl_Products SET Discount={0} WHERE Productid={1} ", discount, productid);
                dt = DataAccess.ExecuteNonQuery(query2);
            }
            return dt;
        }

    }
}
