using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Casa
    {
        private int _Casaid;
        private int _Sepetid;
        private int _Cashtypeid;
        private int _Cashmovementid;
        private DateTime _Date;
        private int _Adminid;
        private int _Total;
        private int _Personid;
        private string _PersonType;

        public int Casaid { get => _Casaid; set => _Casaid = value; }
        public int Sepetid { get => _Sepetid; set => _Sepetid = value; }
        public int Cashtypeid { get => _Cashtypeid; set => _Cashtypeid = value; }
        public int Cashmovementid { get => _Cashmovementid; set => _Cashmovementid = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int Adminid { get => _Adminid; set => _Adminid = value; }
        public int Total { get => _Total; set => _Total = value; }
        public int Personid1 { get => _Personid; set => _Personid = value; }
        public string PersonType { get => _PersonType; set => _PersonType = value; }

        public DataTable GetArtisansCash()
        {
            string query = " select Tbl_Casa.Casaid,Tbl_Artisans.ArtisanName,Tbl_CashType.CashTypeName,Tbl_CashMovement.CashMovementName,Tbl_Casa.CasaDate,Tbl_Casa.Total,Tbl_Admin.AdminName from Tbl_Casa " +
                " join Tbl_Artisans on Tbl_Artisans.Artisanid=Tbl_Casa.Personid " +
                " join Tbl_CashType on Tbl_CashType.id=Tbl_Casa.CashTypeid " +
                " join Tbl_CashMovement on Tbl_CashMovement.id=Tbl_Casa.CashMovementid " +
                " join Tbl_Admin on Tbl_Admin.Adminid=Tbl_Casa.Adminid";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCustomersCash()
        {
            string query = " select Tbl_Casa.Casaid,Tbl_Customers.CustomerName,Tbl_CashType.CashTypeName,Tbl_CashMovement.CashMovementName,Tbl_Casa.CasaDate,Tbl_Casa.Total,Tbl_Admin.AdminName from Tbl_Casa " +
                " join Tbl_Customers on Tbl_Customers.Customerid=Tbl_Casa.Personid " +
                " join Tbl_CashType on Tbl_CashType.id=Tbl_Casa.CashTypeid " +
                " join Tbl_CashMovement on Tbl_CashMovement.id=Tbl_Casa.CashMovementid " +
                " join Tbl_Admin on Tbl_Admin.Adminid=Tbl_Casa.Adminid";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetIncomeTopPrice()
        {
            string query = "SELECT Tbl_CashType.CashTypeName,Tbl_Casa.Total from Tbl_Casa join Tbl_CashType on Tbl_CashType.id=Tbl_Casa.CashTypeid " +
                " join Tbl_CashMovement on Tbl_CashMovement.id=Tbl_Casa.CashMovementid " +
                " where Tbl_CashMovement.id='2' ORDER BY Tbl_Casa.Total DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetExportTopPrice()
        {
            string query = "SELECT Tbl_CashType.CashTypeName,Tbl_Casa.Total from Tbl_Casa join Tbl_CashType on Tbl_CashType.id=Tbl_Casa.CashTypeid " +
                " join Tbl_CashMovement on Tbl_CashMovement.id=Tbl_Casa.CashMovementid " +
                " where Tbl_CashMovement.id='1' ORDER BY Tbl_Casa.Total DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCashExport()
        {
            string query = "SELECT SUM(Tbl_Casa.Total) AS total FROM Tbl_Casa WHERE Tbl_Casa.CashMovementid = '1'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCashIncome()
        {
            string query = "SELECT SUM(Tbl_Casa.Total) AS total FROM Tbl_Casa WHERE Tbl_Casa.CashMovementid = '2'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCashMovement()
        {
            string query = "select Tbl_CashMovement.CashMovementName  from Tbl_CashMovement";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCashType()
        {
            string query = "select Tbl_CashType.CashTypeName  from Tbl_CashType";
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetidfromCashmovement(string name)
        {
            string query = string.Format("select Tbl_CashMovement.id from Tbl_CashMovement where CashMovementName='{0}'", name);
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetidfromCashtype(string name)
        {
            string query = string.Format("select Tbl_CashType.id from Tbl_CashType where CashTypeName='{0}'", name);
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetidfromClientNameForc(string name)
        {
            string query = string.Format("select Tbl_Customers.Customerid from Tbl_Customers where Tbl_Customers.CustomerName='{0}'", name);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetidfromClientNameForA(string name)
        {
            string query = string.Format("select Tbl_Artisans.Artisanid from Tbl_Artisans where Tbl_Artisans.ArtisanName='{0}'", name);
            return DataAccess.ExecuteQuery(query);
        }

        public int AddCasa(int personid, string persontype, int cashtypeid, int cashmovementid, string date, int total, int adminid)
        {
            string query= string.Format("INSERT INTO Tbl_Casa(Personid,PersonType,CashTypeid,CashMovementid,CasaDate,Total,Adminid) " +
                "VALUES({0},'{1}',{2},{3},'{4}',{5},{6})",personid, persontype, cashtypeid, cashmovementid, date, total, adminid);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int EditProductinCasa(int productid, int productcount)
        {
            string query = string.Format("UPDATE Tbl_Products SET ProductCount = ProductCount -{0} where Productid = {1}", productcount, productid);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int DeleteCash(int id)
        {
            string query = string.Format("delete from Tbl_Casa where Tbl_Casa.Casaid={0}", id);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int UpdateCasa(int id, int personid, string persontype, int cashtypeid, int cashmovementid, string date, int total, int adminid)
        {
            string query = string.Format("UPDATE Tbl_Casa SET Personid={0} ," +
                " PersonType='{1}'," +
                " CashTypeid={2}," +
                " CashMovementid={3}," +
                " CasaDate='{4}'," +
                " Total={5}," +
                " Adminid={6}" +
                " WHERE Casaid={7}", personid, persontype, cashtypeid, cashmovementid, date, total, adminid,id);
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}
