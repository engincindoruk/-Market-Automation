using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Supplier : Person
    {
        private int _Supplierid;
        private string _Brandname;

        public int Supplierid { get => _Supplierid; set => _Supplierid = value; }
        public string Brandname { get => _Brandname; set => _Brandname = value; }


        public int AddSupplier(string name, string surname, string mail, string phone, string tc, string companyname)
        {
            try
            {
                string query = string.Format("INSERT INTO Tbl_Suppliers(SupplierName,SupplierSurname,SupplierEmail,SupplierPhone,SupplierTc,SupplierCompanyName)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", name, surname, mail, phone, tc, companyname);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateSupplier(int id, string name, string surname, string mail, string phone, string tc, string companyname)
        {
            string query = string.Format("UPDATE Tbl_Suppliers SET SupplierName='{0}'," +
                "SupplierSurname='{1}'," +
                "SupplierEmail='{2}'," +
                "SupplierPhone='{3}'," +
                "SupplierTc='{4}'," +
                "SupplierCompanyName='{5}'" +
                "WHERE Supplierid={6}", name, surname, mail, phone, tc, companyname, id);
            return DataAccess.ExecuteNonQuery(query);
        }


        public int DeleteSupplier(int id)
        {
            string query = "Delete FROM Tbl_Suppliers WHERE Supplierid=" + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable getSupplier()
        {
            string query = "select * from Tbl_Suppliers";
            var dt = DataAccess.ExecuteQuery(query);
            return dt;
        }

        public DataTable getSupplierlıkeName(string name)
        {
            string query = string.Format("select * from Tbl_Suppliers where SupplierName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }

    }
}