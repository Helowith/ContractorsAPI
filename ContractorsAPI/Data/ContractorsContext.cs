using ContractorsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public class ContractorsContext : DbContext
    {
        public ContractorsContext(DbContextOptions<ContractorsContext> options) : base(options)
        {
            
        }
        public DbSet<OsobaKontaktowa> OsobyKontaktowe { get; set; }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
        public DbSet<Oddzial> Oddzialy { get; set; }
        
    }
}
