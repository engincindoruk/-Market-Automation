using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    class Artisan : Person
    {
        private int _Artisanid;
        private string _Brandname;

        public int Artisanid { get => _Artisanid; set => _Artisanid = value; }
        public string Brandname { get => _Brandname; set => _Brandname = value; }


        public int AddArtisan(string name, string surname, string mail, string phone, string tc, string brandname)
        {
            try
            {
                string query = string.Format("INSERT INTO Tbl_Artisans(ArtisanName,ArtisanSurname,ArtisanEmail,ArtisanPhone,ArtisanTc,ArtisanBrandName)" +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", name, surname, mail, phone, tc, brandname);
                return DataAccess.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateArtisan(int id, string name, string surname, string mail, string phone, string tc, string brandname)
        {
            string query = string.Format("UPDATE Tbl_Artisans SET ArtisanName='{0}'," +
                "ArtisanSurname='{1}'," +
                "ArtisanEmail='{2}'," +
                "ArtisanPhone='{3}'," +
                "ArtisanTc='{4}'," +
                "ArtisanBrandName='{5}'" +
                "WHERE Artisanid={6}", name, surname, mail, phone, tc, brandname, id);
            return DataAccess.ExecuteNonQuery(query);
        }


        public int DeleteArtisan(int id)
        {
            string query = "Delete FROM Tbl_Artisans WHERE Artisanid=" + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable getArtisan()
        {
            string query = "select * from Tbl_Artisans  ";
            var dt = DataAccess.ExecuteQuery(query);
            return dt;
        }
        public DataTable getArtisanlıkeName(string name)
        {
            string query = string.Format("select * from Tbl_Artisans where ArtisanName LIKE '{0}%'", name);
            return DataAccess.ExecuteQuery(query);
        }

    }
}
