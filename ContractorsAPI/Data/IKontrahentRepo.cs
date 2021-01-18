using ContractorsAPI.ContractorsStatus;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public interface IKontrahentRepo
    {
        IList<Object> GetAllContractors();
        IList<Object> GetContractorByIdWithAllData(int id);
        KontrahentOutsideDTO GetContractorByNip(string nip);
        Sum GetInvoices(string Nip, DateTime dateFromDateTime, DateTime dateToDateTime);  
        Kontrahent GetContractorById(int id);
        void CreateContractor(Kontrahent kontrahent);
        void UpdateContractor(Kontrahent kontrahent);
        void DeleteContractor(Kontrahent kontrahent);
        bool SaveChanges();
    }
}
