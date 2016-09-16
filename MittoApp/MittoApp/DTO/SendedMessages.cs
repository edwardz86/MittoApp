using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MittoApp.DTO
{
    [DataContract(Name = "messages")]
    public class SendedMessagesDTO
    {
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }
        [DataMember(Name = "items")]
        public IEnumerable<SendedMessageDTO> Items { get; set; }
    }
}