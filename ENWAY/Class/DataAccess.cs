using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ENWAY
{
    class DataAccess
    {
        private static string dppath = @"Data Source=DESKTOP-8A6F159\SQLEXPRESS;Initial Catalog=Enway;Integrated Security=True";

        //select
        public static DataTable ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(dppath);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        public static int ExecuteNonQuery(string query)
        {
            SqlConnection con = new SqlConnection(dppath);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery();
        }

    }
}
