using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Customer : Person
    {
        public int AddCustomer(string name, string surname, string mail, string phone, string tc)
        {
            try
            {
                string query = string.Format("INSERT INTO Tbl_Customers(CustomerName,CustomerSurname,CustomerEmail,CustomerPhone,CustomerTc)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}')", name, surname, mail, phone, tc);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateCustomer(int id, string name, string surname, string mail, string phone, string tc)
        {
            string query = string.Format("UPDATE Tbl_Customers SET CustomerName='{0}'," +
                "CustomerSurname='{1}'," +
                "CustomerEmail='{2}'," +
                "CustomerPhone='{3}'," +
                "CustomerTc='{4}'" +
                "WHERE Customerid={5}", name, surname, mail, phone, tc, id);
            return DataAccess.ExecuteNonQuery(query);
        }


        public int DeleteCustomer(int id)
        {
            string query = "Delete FROM Tbl_Customers WHERE Customerid=" + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable getCustomer()
        {
            string query = "Select * from Tbl_Customers ";
            var dt = DataAccess.ExecuteQuery(query);
            return dt;
        }
        public DataTable getCustomerlıkeName(string name)
        {
            string query = string.Format("select * from Tbl_Customers where CustomerName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }

    }
}
