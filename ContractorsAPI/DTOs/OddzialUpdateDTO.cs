using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.DTOs
{
    public class OddzialUpdateDTO
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
    }
}
