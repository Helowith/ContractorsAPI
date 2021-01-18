using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public interface IOddzialRepo
    {
        IEnumerable<Oddzial> GetAllDepartments(int id);
        Oddzial GetDepartmentById(int id);
        void CreateDepartment(Oddzial oddzial);
        void UpdateDepartment(Oddzial oddzial);
        void DeleteDepartment(Oddzial oddzial);
        bool SaveChanges();
    }
}
