using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Models
{
    public class OsobaKontaktowa
    {
        [Key]
        public int OsobaKontaktowaID { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NrTelefonu { get; set; }

        [ForeignKey("Oddzial")]
        public int OddzialID { get; set; }

        public Oddzial Oddzial { get; set; }
    }
}
