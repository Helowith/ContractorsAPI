using ContractorsAPI.ContractorsStatus;
using ContractorsAPI.DTOs;
using ContractorsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorsAPI.Data
{
    public class SqlKontrahentRepo : IKontrahentRepo
    {
        private ContractorsContext _context;

        public SqlKontrahentRepo(ContractorsContext contractorsContext)
        {
            _context = contractorsContext;
        }
        public void CreateContractor(Kontrahent kontrahent)
        {

            if(kontrahent == null)
            {
                throw new ArgumentNullException(nameof(kontrahent));
            }
            _context.Kontrahenci.Add(kontrahent);
            
        }

        public void DeleteContractor(Kontrahent kontrahent)
        {
            if (kontrahent == null)
            {
                throw new ArgumentNullException(nameof(kontrahent));
            }
            _context.Kontrahenci.Remove(kontrahent);
        }

        public IList<Object> GetAllContractors()
        {
            var query = _context.Kontrahenci.Select(contractor => new
            {
                KontrahentID = contractor.KontrahentID,
                NazwaFirmy = contractor.NazwaFirmy,
                NIP = contractor.NIP,
                NrKontaBankowego = contractor.NrKontaBankowego,
                Fax = contractor.Fax,
                OddzialGlowny = contractor.Oddzialy.Select(oddzial => new
                {
                    OddzialID = oddzial.OddzialID,
                    CzyOddzialGlowny = oddzial.CzyOddzialGlowny,
                    Kraj = oddzial.Kraj,
                    KodPocztowy = oddzial.KodPocztowy,
                    Wojewodztwo = oddzial.Wojewodztwo,
                    Miasto = oddzial.Miasto,
                    Ulica = oddzial.Ulica,
                    NrBudynku = oddzial.NrBudynku,
                    NazwaOddzialu = oddzial.NazwaOddzialu
                }).Where(oddzial => oddzial.CzyOddzialGlowny == true).FirstOrDefault()

            }).ToList<Object>();
            return query;
            //return _context.Kontrahenci.ToList();
        }

        public Kontrahent GetContractorById(int id)
        {
            return _context.Kontrahenci.FirstOrDefault(contraktor => contraktor.KontrahentID == id);
        }

        public IList<Object> GetContractorByIdWithAllData(int id)
        {
            var query = _context.Kontrahenci.Select(contractor => new
            {
                KontrahentID = contractor.KontrahentID,
                NazwaFirmy = contractor.NazwaFirmy,
                NIP = contractor.NIP,
                NrKontaBankowego = contractor.NrKontaBankowego,
                Fax = contractor.Fax,
                OddzialGlowny = contractor.Oddzialy.Select(oddzial => new
                {
                    OddzialID = oddzial.OddzialID,
                    CzyOddzialGlowny = oddzial.CzyOddzialGlowny,
                    Kraj = oddzial.Kraj,
                    KodPocztowy = oddzial.KodPocztowy,
                    Wojewodztwo = oddzial.Wojewodztwo,
                    Miasto = oddzial.Miasto,
                    Ulica = oddzial.Ulica,
                    NrBudynku = oddzial.NrBudynku,
                    NazwaOddzialu = oddzial.NazwaOddzialu
                }).Where(oddzial => oddzial.CzyOddzialGlowny == true).FirstOrDefault()

            }).Where(contractor => contractor.KontrahentID == id).ToList<Object>();
            return query;
            //return _context.Kontrahenci.FirstOrDefault(p => p.KontrahentID == id);
        }

        public KontrahentOutsideDTO GetContractorByNip(string nip)
        {
            var kontrahentOutside = new KontrahentOutsideDTO();
            var query = _context.Kontrahenci.Select(contractor => new
            {
                KontrahentID = contractor.KontrahentID,
                NazwaFirmy = contractor.NazwaFirmy,
                NIP = contractor.NIP,
                NrKontaBankowego = contractor.NrKontaBankowego,
                Fax = contractor.Fax,
                OddzialGlowny = contractor.Oddzialy.Select(oddzial => new
                {
                    OddzialID = oddzial.OddzialID,
                    CzyOddzialGlowny = oddzial.CzyOddzialGlowny,
                    Kraj = oddzial.Kraj,
                    KodPocztowy = oddzial.KodPocztowy,
                    Wojewodztwo = oddzial.Wojewodztwo,
                    Miasto = oddzial.Miasto,
                    Ulica = oddzial.Ulica,
                    NrBudynku = oddzial.NrBudynku,
                    NazwaOddzialu = oddzial.NazwaOddzialu,
                    OsobaKontaktowa = oddzial.OsobyKontaktowe.Select(osobaKontaktowa => new
                    {
                        Email = osobaKontaktowa.Email,
                        Telefon = osobaKontaktowa.NrTelefonu

                    }).FirstOrDefault()
                }).Where(oddzial => oddzial.CzyOddzialGlowny == true).FirstOrDefault()

            }).Where(contractor => contractor.NIP == nip).FirstOrDefault();
            if(query != null)
            {
                kontrahentOutside.ID = query.KontrahentID;
                kontrahentOutside.Nazwa = query.NazwaFirmy;
                kontrahentOutside.Adres = $"{query.OddzialGlowny.Ulica} {query.OddzialGlowny.NrBudynku} {query.OddzialGlowny.Miasto} {query.OddzialGlowny.KodPocztowy}";
                kontrahentOutside.NIP = query.NIP;

                if (query.OddzialGlowny.OsobaKontaktowa == null)
                {
                    kontrahentOutside.Email = "Brak";
                    kontrahentOutside.Telefon = "Brak";
                }
                else
                {
                    kontrahentOutside.Email = query.OddzialGlowny.OsobaKontaktowa.Email;
                    kontrahentOutside.Telefon = query.OddzialGlowny.OsobaKontaktowa.Telefon;
                }
            }
            else
            {
                kontrahentOutside.ID = -1;
                kontrahentOutside.Nazwa = "Brak";
                kontrahentOutside.Adres = "Brak";
                kontrahentOutside.NIP = "Brak kontrahenta o podanym numerze NIP";
                kontrahentOutside.Email = "Brak";
                kontrahentOutside.Telefon = "Brak";
            }
            
            
            return kontrahentOutside;
        }

        public Sum GetInvoices(string Nip, DateTime dateFromDateTime, DateTime dateToDateTime)
        {
            var invoices = new InvoiceSummary(Nip, dateFromDateTime, dateToDateTime);
            return invoices.Suma;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateContractor(Kontrahent kontrahent)
        {
            //nothing
        }
    }
}
