using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public interface IOsobaKontaktowaRepo
    {
        IEnumerable<OsobaKontaktowa> GetAllPeople(int id);
        OsobaKontaktowa GetPersonById(int id);
        void CreatePerson(OsobaKontaktowa osobaKontaktowa);
        void UpdatePerson(OsobaKontaktowa osobaKontaktowa);
        void DeletePerson(OsobaKontaktowa osobaKontaktowa);
        bool SaveChanges();
    }
}
