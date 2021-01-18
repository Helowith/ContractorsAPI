using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.DTOs
{
    public class OsobaKontaktowaCreateDTO
    {
        
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NrTelefonu { get; set; }
    }
}
