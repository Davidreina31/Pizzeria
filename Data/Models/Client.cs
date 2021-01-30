using System;
using System.Collections.Generic;

namespace Data
{
    public class Client
    {
        public int ClientId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Adresse { get; set; }

        public List<int> PizzaId { get; set; } = new List<int>();

        public string? Coment { get; set; }

        public DateTime DateEtHeure { get; set; }
    }
}
