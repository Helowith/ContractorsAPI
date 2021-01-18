using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public class SqlOddzialRepo : IOddzialRepo
    {
        private ContractorsContext _context;

        public SqlOddzialRepo(ContractorsContext contractorsContext)
        {
            _context = contractorsContext;
        }
        public void CreateDepartment(Oddzial oddzial)
        {
            if(oddzial == null)
            {
                throw new ArgumentNullException(nameof(oddzial));
            }
            _context.Oddzialy.Add(oddzial);
        }

        public void DeleteDepartment(Oddzial oddzial)
        {
            if(oddzial == null)
            {
                throw new ArgumentNullException(nameof(oddzial));
            }
            _context.Oddzialy.Remove(oddzial);
        }

        public IEnumerable<Oddzial> GetAllDepartments(int id)
        {
            return _context.Oddzialy.Where(p => p.KontrahentID == id).ToList();
        }

        public Oddzial GetDepartmentById(int id)
        {
            return _context.Oddzialy.FirstOrDefault(p => p.OddzialID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateDepartment(Oddzial oddzial)
        {
            //nothing
        }
    }
}
