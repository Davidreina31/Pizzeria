using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Form
{
    public class RetourForm
    {
        public int AvisId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Avis { get; set; }
    }
}
