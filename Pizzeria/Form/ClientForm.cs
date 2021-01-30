using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.Form
{
    public class ClientForm
    {
        public int ClientId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public List<int> PizzaId { get; set; } = new List<int>();

        public string Coment { get; set; }

        public DateTime DateEtHeure { get; set; }
    }
}
