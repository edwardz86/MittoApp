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
        
        // GET: api/MessagesApi/5
        [ResponseType(typeof(Messages))]
        public IHttpActionResult GetMessages(Guid id)
        {
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }
        
        // POST: api/MessagesApi
        [ResponseType(typeof(Messages))]
        public IHttpActionResult PostMessages(Messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(messages);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MessagesExists(messages.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = messages.Id }, messages);
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}


        private bool MessagesExists(Guid id)
        {
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}