using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Admin : Person
    {
        private int _Adminid;
        private DateTime _Startdate;
        private int _Salary;
        private string _Username;
        private string _Password;
        private bool _Status;

        public int Adminid { get => _Adminid; set => _Adminid = value; }
        public DateTime Startdate { get => _Startdate; set => _Startdate = value; }
        public int Salary { get => _Salary; set => _Salary = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public bool Status1 { get => _Status; set => _Status = value; }

        public bool login(string username, string password,bool status)
        {
            _Username = username;
            _Password = password;
            try
            {
                string query = string.Format("select * from Tbl_Admin where AdminUsername='{0}' AND AdminPassword='{1}'and AdminStatus='{2}' ", _Username, _Password,status);
                var dt = DataAccess.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable ForgotPasswordCheckMail(string email)
        {
            try
            {
                string query = string.Format("select Tbl_Admin.AdminName,Tbl_Admin.Adminid from Tbl_Admin where Tbl_Admin.AdminEmail='{0}'", email);
                return DataAccess.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int EditAdminPassword(int id,string password)
        {
            try
            {
                string query = string.Format("UPDATE Tbl_Admin SET AdminPassword='{0}',AdminStatus='1' WHERE Adminid={1} ",password,id);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int ForgotPasswordDeletePassword(int id)
        {
            try
            {
                string query = string.Format("UPDATE Tbl_Admin SET AdminPassword='',AdminStatus='0' WHERE Adminid={0} ", id);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception )
            {
                throw;
            }
        }

        public int AddAdmin(string name, string surname, string mail, string phone, string time, int salary, string tc, string username, string password,bool status)
        {
            try
            {
                string query = string.Format("INSERT INTO Tbl_Admin(AdminName,AdminSurname,AdminEmail,AdminPhone,AdminDate,AdminSalary,AdminTc,AdminUsername,AdminPassword,AdminStatus)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}')", name, surname, mail, phone, time, salary, tc, username, password,status);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }



        public int UpdateAdmin(int id, string name, string surname, string mail, string phone, string date, int salary, string tc, string username, string password, bool status)
        {
            string query = string.Format("UPDATE Tbl_Admin SET AdminName='{0}' ," +
                "AdminSurname='{1}'," +
                "AdminEmail='{2}'," +
                "AdminPhone='{3}'," +
                "AdminDate='{4}'," +
                "AdminSalary={5}," +
                "AdminTc='{6}'," +
                "AdminUsername='{7}'," +
                "AdminPassword='{8}'," +
                "AdminStatus='{9}'" +
                "WHERE Adminid={10}", name, surname, mail, phone, date, salary, tc, username, password,status,id);
            return DataAccess.ExecuteNonQuery(query);
        }


        public int DeleteAdmin(int id)
        {
            string query = "Delete FROM Tbl_Admin WHERE Adminid=" + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable getAdmin()
        {
            string query = "select * from Tbl_Admin";
            var dt = DataAccess.ExecuteQuery(query);
            return dt;
        }
        public DataTable getAdminlıkeName(string name)
        {
            string query = string.Format("select * from Tbl_Admin where AdminName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable getAdminNamefortheHeader(string username)
        {
            string query = string.Format("select AdminName from Tbl_Admin where AdminUsername='{0}'", username);
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetidfromName(string name)
        {
            string query = string.Format("select Adminid from Tbl_Admin where AdminName='{0}'", name);
            return DataAccess.ExecuteQuery(query);   
        }

    }
}
