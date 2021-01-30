using System;
using System.Data.SqlClient;

namespace Data
{
    public class Services
    {
        public string _conString;
        public SqlConnection connection;

        public Services()
        {
            _conString = "Server=localhost;Database=Pizzeria;User Id=SA;Password=Y3s0fC0uRs3;";
            connection = new SqlConnection(_conString);
        }
    }
}
