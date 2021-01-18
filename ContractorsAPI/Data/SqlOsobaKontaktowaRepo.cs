using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public class SqlOsobaKontaktowaRepo : IOsobaKontaktowaRepo
    {
        private ContractorsContext _context;

        public SqlOsobaKontaktowaRepo(ContractorsContext contractorsContext)
        {
            _context = contractorsContext;
        }
        public void CreatePerson(OsobaKontaktowa osobaKontaktowa)
        {
            if (osobaKontaktowa == null)
            {
                throw new ArgumentNullException(nameof(osobaKontaktowa));
            }
            _context.OsobyKontaktowe.Add(osobaKontaktowa);
        }

        public void DeletePerson(OsobaKontaktowa osobaKontaktowa)
        {
            if(osobaKontaktowa == null)
            {
                throw new ArgumentNullException(nameof(osobaKontaktowa));
            }
            _context.OsobyKontaktowe.Remove(osobaKontaktowa);
        }

        public IEnumerable<OsobaKontaktowa> GetAllPeople(int id)
        {
            return _context.OsobyKontaktowe.Where(p => p.OddzialID == id).ToList();
        }

        public OsobaKontaktowa GetPersonById(int id)
        {
            return _context.OsobyKontaktowe.FirstOrDefault(p => p.OsobaKontaktowaID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdatePerson(OsobaKontaktowa osobaKontaktowa)
        {
            //nothing
        }
    }
}
