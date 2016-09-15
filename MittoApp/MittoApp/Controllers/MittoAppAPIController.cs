using MittoApp.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MittoApp.Controllers
{
    public class MittoAppAPIController : ApiController
    {
        private MittoContext db = new MittoContext();

        public Messages[] GetSendSMS()
        {
            return db.Messages.ToArray<Messages>();
        }
    }
}
