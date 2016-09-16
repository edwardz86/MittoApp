using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MittoApp.DTO
{
    [DataContract(Name = "statistics")]
    public class StatisticDTO
    {
        [DataMember(Name = "day")]
        public DateTime CreatedDate { get; set; }
        [DataMember(Name = "mcc")]
        public string MobileCountryCode { get; set; }
        [DataMember(Name = "pricePerSMS")]
        public decimal PricePerSMS { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "totalPrice")]
        public decimal TotalPrice { get; set; }
    }
}