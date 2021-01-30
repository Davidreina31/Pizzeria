using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repository
{
    public class ClientRepo : Services, IClientRepo
    {
        public List<Client> Get()
        {
            List<Client> listeClient = new List<Client>();

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Client";


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listeClient.Add(new Client
                            {
                                ClientId = (int)reader["ClientId"],
                                LastName = (string)reader["LastName"],
                                FirstName = (string)reader["FirstName"],
                                Email = (string)reader["Email"],
                                Adresse = (string)reader["Adresse"],
                                Coment = reader["Coment"] == DBNull.Value ? string.Empty : (string)reader["Coment"],
                                DateEtHeure = (DateTime)reader["DateEtHeure"]

                            });
                        }

                    }
                }

            }

            return listeClient;
        }


        public Client Get(int id)
        {

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT c.[ClientId], c.[Lastname], c.[Firstname]," +
                        " c.[Email], c.[Adresse], c.[Coment], c.[DateEtHeure], p.[Name] " +
                        ", p.PizzaId FROM[dbo].[Client] c LEFT JOIN[dbo].Client_Pizza cp ON c.ClientId = cp.ClientId " +
                        "LEFT JOIN[dbo].Pizza p ON p.PizzaId = cp.PizzaId WHERE c.ClientId=@id";
                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Client client = new Client();
                        while (reader.Read())
                        {
                            client.ClientId = (int)reader["ClientId"];
                            client.LastName = (string)reader["LastName"];
                            client.FirstName = (string)reader["FirstName"];
                            client.Email = (string)reader["Email"];
                            client.Adresse = (string)reader["Adresse"];
                            client.PizzaId.Add(reader.GetInt32("PizzaId"));
                            client.Coment = reader["Coment"] == DBNull.Value ? string.Empty : (string)reader["Coment"];
                            client.DateEtHeure = (DateTime)reader["DateEtHeure"];
                            
                        }

                        return client;
                       
                    }
                }
            }

        }

        public void Create(Client client)
        {
            int id = 0;
            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert into Client (LastName, FirstName,Email, Adresse, Coment, DateEtHeure) ";
                    cmd.CommandText += "output Inserted.ClientId values(@p1, @p2, @p3, @p4, @p5, @p6) ";

                    cmd.Parameters.AddWithValue("p1", client.LastName);
                    cmd.Parameters.AddWithValue("p2", client.FirstName);
                    cmd.Parameters.AddWithValue("p3", client.Email);
                    cmd.Parameters.AddWithValue("p4", client.Adresse);
                    cmd.Parameters.AddWithValue("p5", (object)client.Coment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("p6", DateTime.Now);

                    id = (int)cmd.ExecuteScalar();

                }

                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText += "Insert into Client_Pizza (ClientId, PizzaId) values ";
                    foreach (int item in client.PizzaId)
                    {
                        if (item != 0)
                        {
                            if (item.Equals(client.PizzaId.First()))
                            {
                                cmd.CommandText += $"('{id}', '{item}')";
                            }
                            else
                            {
                                cmd.CommandText += $",('{id}', '{item}')";
                            }

                        }

                    }

                    cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Client client)
        {
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "update Client Set LastName=@p1, FirstName=@p2,";
                    cmd.CommandText += " Email=@p3, Adresse=@p4, Coment=@p5, DateEtHeure=@p6 where ClientId = @id";


                    cmd.Parameters.AddWithValue("p1", client.LastName);
                    cmd.Parameters.AddWithValue("p2", client.FirstName);
                    cmd.Parameters.AddWithValue("p3", client.Email);
                    cmd.Parameters.AddWithValue("p4", client.Adresse);
                    cmd.Parameters.AddWithValue("p5", (object)client.Coment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("p6", DateTime.Now);
                    cmd.Parameters.AddWithValue("id", client.ClientId);


                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Delete(int id)
        {
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete from Client_Pizza where ClientId=@id ";
                    cmd.CommandText += "Delete from Client where ClientId=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
