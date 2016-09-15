using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MittoApp.Migrations;

namespace MittoApp.Controllers
{
    public class MessagesApiController : ApiController
    {
        private MittoContext db = new MittoContext();

        // Obowiązkowe linki: http://www.asp.net/web-api/overview/older-versions/build-restful-apis-with-aspnet-web-api
        // http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
        // http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1
        // https://msdn.microsoft.com/en-us/library/hh833994(v=vs.108).aspx
        // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
        // https://msdn.microsoft.com/en-us/library/ms733127.aspx bardzo wazne annotacje nad modele co zwrocic i jakie ma miec nazwy
        // wydrukować na przyszłość 6 tutoriali!!!!

        // GET: api/GetSendSMS
        public Messages[] GetSendSMS()
        {
            return db.Messages.ToArray<Messages>();
        }

        //// GET: api/MessagesApi/5
        //[ResponseType(typeof(Messages))]
        //public IHttpActionResult GetMessages(Guid id)
        //{
        //    Messages messages = db.Messages.Find(id);
        //    if (messages == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(messages);
        //}

        //// PUT: api/MessagesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMessages(Guid id, Messages messages)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != messages.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(messages).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MessagesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/MessagesApi
        //[ResponseType(typeof(Messages))]
        //public IHttpActionResult PostMessages(Messages messages)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Messages.Add(messages);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MessagesExists(messages.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = messages.Id }, messages);
        //}

        //// DELETE: api/MessagesApi/5
        //[ResponseType(typeof(Messages))]
        //public IHttpActionResult DeleteMessages(Guid id)
        //{
        //    Messages messages = db.Messages.Find(id);
        //    if (messages == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Messages.Remove(messages);
        //    db.SaveChanges();

        //    return Ok(messages);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MessagesExists(Guid id)
        //{
        //    return db.Messages.Count(e => e.Id == id) > 0;
        //}
    }
}