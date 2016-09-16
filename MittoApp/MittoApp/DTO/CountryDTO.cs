using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MittoApp.DTO
{
    [DataContract(Name = "countries")]
    public class CountryDTO
    {
        [DataMember(Name = "mcc")]
        public string MobileCountryCode { get; set; }
        [DataMember(Name = "cc")]
        public string CountryCode { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "pricePerSMS")]
        public decimal PricePerSMS { get; set; }
    }
}