using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Models
{
    public class Kontrahent
    {
        public Kontrahent()
        {
            Oddzialy = new List<Oddzial>();
        }
        [Key]
        public int KontrahentID { get; set; }
        [Required]
        public string NazwaFirmy { get; set; }
        [Required]
        public string NIP { get; set; }
        [Required]
        public string NrKontaBankowego { get; set; }
        public string Fax { get; set; }

        public IList<Oddzial> Oddzialy { get; set; }
    }
}
