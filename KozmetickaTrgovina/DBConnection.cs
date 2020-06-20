using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KozmetickaTrgovina
{
    class DBConnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private double dailybirthdays;
        public string MyConnection()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=KozmetickiSalon;Integrated Security=True";
            return con;
        }
    }
}
