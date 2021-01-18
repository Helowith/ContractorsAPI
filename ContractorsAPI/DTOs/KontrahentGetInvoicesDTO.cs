using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.DTOs
{
    public class KontrahentGetInvoicesDTO
    {
        public DateTime dateFromDateTime { get; set; }
        public DateTime dateToDateTime { get; set; }
    }
}
