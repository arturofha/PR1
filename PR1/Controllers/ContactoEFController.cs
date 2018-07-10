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
using PR1.Models;

namespace PR1.Controllers
{
    [RoutePrefix("api/ContactoEF")]
    public class ContactoEFController : ApiController
    {
        private PR1Context db = new PR1Context();

        // GET: api/ContactoEF
        [Route("")]
        public IQueryable<Contacto> GetContactoes()
        {
            return db.Contactoes;
        }

        // GET: api/ContactoEF/5
        [ResponseType(typeof(Contacto))]
        public IHttpActionResult GetContacto(int id)
        {
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return Ok(contacto);
        }

        // PUT: api/ContactoEF/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContacto(int id, Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contacto.Id)
            {
                return BadRequest();
            }

            db.Entry(contacto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContactoEF
        [Route("")]
        [ResponseType(typeof(Contacto))]
        public IHttpActionResult PostContacto(Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contactoes.Add(contacto);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = contacto.Id }, contacto);
            return Ok(contacto);
        }

        // DELETE: api/ContactoEF/5
        [ResponseType(typeof(Contacto))]
        public IHttpActionResult DeleteContacto(int id)
        {
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            db.Contactoes.Remove(contacto);
            db.SaveChanges();

            return Ok(contacto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactoExists(int id)
        {
            return db.Contactoes.Count(e => e.Id == id) > 0;
        }
    }
}