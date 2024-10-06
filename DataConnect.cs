using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form1
{
    internal class DataConnect
    {
        static string _connectionString = @"Data Source=LAPTOP-FST05RKU;Initial Catalog=Hospital;Integrated Security=True;Encrypt=False";
        public static DataTable GetData(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool ExexuteQyery(string query)
        {
            try
            {


                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

                return false;
            }
        }
    }
}