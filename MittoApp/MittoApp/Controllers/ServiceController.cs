using MittoApp.DTO;
using MittoApp.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static MittoApp.Utils.Enums;

namespace MittoApp.Controllers
{
    public class ServiceController : ApiController
    {
        private MittoContext db = new MittoContext();
        
        [HttpGet]
        [Route("countries{x:regex(.[A-Z])}")]
        public IEnumerable<CountryDTO> GetCountries()
        {
            var countries = from c in db.Countries
                            select new CountryDTO()
                            {
                                CountryCode = c.CountryCode,
                                MobileCountryCode = c.MobileCountryCode,
                                Name = c.Name,
                                PricePerSMS = c.PricePerSMS
                            };

            return countries.ToList();            
        }

        [HttpPost]
        [Route("sms/send{x:regex(.[A-Z])}")]
        public State SendSMS(string from, string to, string text)
        {
            Countries country = db.Countries.FirstOrDefault();

            if(country == null)
            {
                return State.Failed;
            }
   
            db.Messages.Add(getMessage(from, to, text, country));

            try
            {
                db.SaveChanges();
                
            }
            catch (DbUpdateException)
            {
                throw;                
            }
            
            return State.Success;
        }

        [HttpGet]
        [Route("sms/sent{x:regex(.[A-Z])}/")]
        public SendedMessagesDTO GetSendSMS(int skip, int take, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            // sms/sent{x}?skip=1&take=5&dateTimeFrom=2016-09-16T00:00:00.00&dateTimeTo=2016-09-16T22:00:00.00
            SendedMessagesDTO result = new SendedMessagesDTO();

            IQueryable<SendedMessageDTO> sendedMessagesQuery = from c in db.Countries
                            join m in db.Messages
                            on c.Id equals m.Country.Id
                            where m.SendDate >= dateTimeFrom && m.SendDate <= dateTimeTo
                            select new SendedMessageDTO()
                            {
                                SendDate = m.SendDate,
                                MobileCountryCode = c.MobileCountryCode,
                                Sender = m.Sender,
                                Receiver = m.Receiver,
                                PricePerSMS = c.PricePerSMS,
                                State = m.State
                            };

            var sendedMessages = sendedMessagesQuery.ToList().Skip(skip).Take(take);

            result.Items = sendedMessages;
            result.TotalCount = sendedMessages.Count();
            
            return result;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Messages getMessage(string from, string to, string text, Countries country)
        {
            Messages message = new Messages()
            {
                Id = Guid.NewGuid(),
                Sender = from,
                Receiver = to,
                Text = text,
                SendDate = DateTime.Now,
                State = 0,
                Country = country
            };

            return message;
        }

    }
}
