using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace ContractorsAPI.ContractorsStatus
{
    public class SerializationClass
    {
        public int ID { get; set; }
        public string Numer_faktury { get; set; }
        public string NIP { get; set; }
        public string Status { get; set; }
        public object Data_platnosci { get; set; }
        public double Wartosc_faktury_brutto { get; set; }
    }

    
}
