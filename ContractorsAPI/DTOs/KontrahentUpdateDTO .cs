using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.DTOs
{
    public class KontrahentUpdateDTO
    {
        [Required]
        public string NazwaFirmy { get; set; }
        [Required]
        public string NIP { get; set; }
        [Required]
        public string NrKontaBankowego { get; set; }
        public string Fax { get; set; }
        public IList<OddzialUpdateDTO> Oddzialy { get; set; }
    }
}
