using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//var jsonString = JsonConvert.DeserializeObject(JsonString);
namespace ContractorsAPI.ContractorsStatus
{
    public class InvoiceSummary
    {
        public SerializationClass[] Invoices { get; set; }
        public string JsonString { get; set; }
        public Sum Suma { get; set; }
        public string Nip { get; set; }
        public DateTime DateFromDateTime { get; set; }
        public DateTime DateToDateTime { get; set; }

        public InvoiceSummary(string nip, DateTime dateFromDateTime, DateTime dateToDateTime)
        {
            Nip = nip;
            DateFromDateTime = dateFromDateTime;
            DateToDateTime = dateToDateTime;

            Suma = new Sum();
            DownloadAndDeserializeString();
            ContractorsSummary();
        }
        private void DownloadAndDeserializeString()
        {
            //DateTime DateFromDateTime = new DateTime(2020, 12, 10);
            //DateTime DateToDateTime = new DateTime(2020, 12, 15);
            string DateFrom = DateFromDateTime.ToString("yyyy-MM-dd");
            string DateTo = DateToDateTime.ToString("yyyy-MM-dd");
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    JsonString = webClient.DownloadString($"https://inz-opr.herokuapp.com/api/faktury/?nip={Nip}&Data_od=\"{DateFrom}\"&Data_do=\"{DateTo}\"");

                    Invoices = JsonConvert.DeserializeObject<SerializationClass[]>(JsonString);
                    Console.WriteLine();
                }


            }
            catch
            {
                Console.WriteLine("Error while downloading data from the internet!");
            }

        }

        private void ContractorsSummary()
        {
            Suma.LiczbaZaplaconych = 0;
            Suma.LiczbaNiezaplaconych = 0;
            Suma.SumaZaplaconych = 0;
            Suma.SumaNiezaplaconych = 0;
            for (int i = 0; i < Invoices.Length; i++)
            {


                if (Invoices[i].Status == "nie oplacona")
                {
                    Suma.SumaZaplaconych = Suma.SumaZaplaconych + Invoices[i].Wartosc_faktury_brutto;
                    Suma.LiczbaZaplaconych++;
                }
                else
                {
                    Suma.SumaNiezaplaconych = Suma.SumaNiezaplaconych + Invoices[i].Wartosc_faktury_brutto;
                    Suma.LiczbaNiezaplaconych++;
                }

            }
        }

    }
}

