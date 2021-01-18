using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Models
{
    public class Oddzial
    {
        [Key]
        public int OddzialID { get; set; }
        [Required]
        public bool CzyOddzialGlowny { get; set; }
        [Required]
        public string Kraj { get; set; }
        [Required]
        public string KodPocztowy { get; set; }
        [Required]
        public string Wojewodztwo { get; set; }
        [Required]
        public string Miasto { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public string NrBudynku { get; set; }
        [Required]
        public string NazwaOddzialu { get; set; }

        [ForeignKey("Kontrahent")]
        public int KontrahentID { get; set; }
        public Kontrahent Kontrahent { get; set; }

        public ICollection<OsobaKontaktowa> OsobyKontaktowe { get; set; }

    }
}
