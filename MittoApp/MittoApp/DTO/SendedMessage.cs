using MittoApp.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using static MittoApp.Utils.Enums;

namespace MittoApp.DTO
{
    [DataContract(Name = "SMS")]
    public class SendedMessageDTO
    {
        [DataMember(Name = "dateTime")]
        public DateTime SendDate { get; set; }
        [DataMember(Name = "mcc")]
        public string MobileCountryCode { get; set; }
        [DataMember(Name = "from")]
        public string Sender { get; set; }
        [DataMember(Name = "to")]
        public string Receiver { get; set; }        
        [DataMember(Name = "price")]
        public decimal PricePerSMS { get; set; }
        [DataMember(Name = "state")]
        public State State { get; set; }
        
    }
}