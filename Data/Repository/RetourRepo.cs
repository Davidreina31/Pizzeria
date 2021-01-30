using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data.Models;

namespace Data.Repository
{
    public class RetourRepo : Services, IRetourRepo
    {
        public List<Retour> Get()
        {
            List<Retour> listeRetour = new List<Retour>();

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Retour";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listeRetour.Add(new Retour
                            {
                                AvisId = (int)reader["AvisId"],
                                LastName = (string)reader["LastName"],
                                FirstName = (string)reader["FirstName"],
                                Avis = (string)reader["Avis"]

                            });
                        }
                    }
                }

            }

            return listeRetour;
        }

        public Retour Get(int id)
        {
            Retour model = new Retour();

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * from Retour where AvisId=@id";
                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.AvisId = (int)reader["AvisId"];
                            model.LastName = (string)reader["LastName"];
                            model.FirstName = (string)reader["FirstName"];
                            model.Avis = (string)reader["Avis"];
                        }
                    }
                }
            }

            return model;
        }

        public void Create(Retour retour)
        {
            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert into Retour (LastName, FirstName, Avis) ";
                    cmd.CommandText += "output Inserted.AvisId values(@p1, @p2, @p3)";

                    cmd.Parameters.AddWithValue("p1", retour.LastName);
                    cmd.Parameters.AddWithValue("p2", retour.FirstName);
                    cmd.Parameters.AddWithValue("p3", retour.Avis);

                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Retour retour)
        {
            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "update Retour Set LastName=@p1, FirstName=@p2,";
                    cmd.CommandText += " Avis=@p3 where AvisId = @id";


                    cmd.Parameters.AddWithValue("p1", retour.LastName);
                    cmd.Parameters.AddWithValue("p2", retour.FirstName);
                    cmd.Parameters.AddWithValue("p3", retour.Avis);
                    cmd.Parameters.AddWithValue("id", retour.AvisId);

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
                    cmd.CommandText = "Delete from Retour where AvisId=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
