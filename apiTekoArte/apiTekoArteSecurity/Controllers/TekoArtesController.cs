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
using apiTekoArteSecurity.Models;

namespace apiTekoArteSecurity.Controllers
{
    public class TekoArtesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/TekoArtes
        public IQueryable<TekoArte> GetTekoArtes()
        {
            return db.TekoArtes;
        }

        // GET: api/TekoArtes/5
        [ResponseType(typeof(TekoArte))]
        public IHttpActionResult GetTekoArte(int id)
        {
            TekoArte tekoArte = db.TekoArtes.Find(id);
            if (tekoArte == null)
            {
                return NotFound();
            }

            return Ok(tekoArte);
        }

        // PUT: api/TekoArtes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTekoArte(int id, TekoArte tekoArte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tekoArte.ArtID)
            {
                return BadRequest();
            }

            db.Entry(tekoArte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TekoArteExists(id))
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

        // POST: api/TekoArtes
        [ResponseType(typeof(TekoArte))]
        public IHttpActionResult PostTekoArte(TekoArte tekoArte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TekoArtes.Add(tekoArte);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tekoArte.ArtID }, tekoArte);
        }

        // DELETE: api/TekoArtes/5
        [ResponseType(typeof(TekoArte))]
        public IHttpActionResult DeleteTekoArte(int id)
        {
            TekoArte tekoArte = db.TekoArtes.Find(id);
            if (tekoArte == null)
            {
                return NotFound();
            }

            db.TekoArtes.Remove(tekoArte);
            db.SaveChanges();

            return Ok(tekoArte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TekoArteExists(int id)
        {
            return db.TekoArtes.Count(e => e.ArtID == id) > 0;
        }
    }
}