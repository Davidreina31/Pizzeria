using System;
using Data;
using Data.Form;

namespace Pizzeria.Mappers
{
    public static class ClientMapper
    {
        public static Data.Form.ClientForm ClientToClientForm(this Data.Client client)
        {
            return new Data.Form.ClientForm
            {
                ClientId = client.ClientId,
                LastName = client.LastName,
                FirstName = client.FirstName,
                Email = client.Email,
                Adresse = client.Adresse,
                PizzaId = client.PizzaId,
                Coment = client.Coment,
                DateEtHeure = client.DateEtHeure
            };
        }

        public static Client ClientFormToClient(this ClientForm client)
        {
            return new Client
            {
                ClientId = client.ClientId,
                LastName = client.LastName,
                FirstName = client.FirstName,
                Email = client.Email,
                Adresse = client.Adresse,
                PizzaId = client.PizzaId,
                Coment = client.Coment,
                DateEtHeure = client.DateEtHeure
            };
        }
    }
}
