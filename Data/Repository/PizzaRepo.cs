using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class PizzaRepo : Services
    {
        public List<Pizza> Get()
        {
            List<Pizza> listePizza = new List<Pizza>();

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select PizzaId, Name from Pizza";


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listePizza.Add(new Pizza
                            {
                                PizzaId = (int) reader["PizzaId"],
                                Name = (string) reader["Name"],
                            });
                        }

                    }
                }

            }

            return listePizza;
        }
    }
}
