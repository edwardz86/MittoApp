using MittoApp.DTO;
using MittoApp.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
