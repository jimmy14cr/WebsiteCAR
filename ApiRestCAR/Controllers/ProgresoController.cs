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
using ApiRestCAR.Models;

namespace ApiRestCAR.Controllers
{
    public class ProgresoController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/Progreso
        public IQueryable<Progreso> GetProgreso()
        {
            return db.Progreso;
        }

        // GET: api/Progreso/5
        [ResponseType(typeof(Progreso))]
        public IHttpActionResult GetProgreso(int id)
        {
            Progreso progreso = db.Progreso.Find(id);
            if (progreso == null)
            {
                return NotFound();
            }

            return Ok(progreso);
        }

        // PUT: api/Progreso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgreso(int id, Progreso progreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != progreso.IdProgreso)
            {
                return BadRequest();
            }

            db.Entry(progreso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgresoExists(id))
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

        // POST: api/Progreso
        [ResponseType(typeof(Progreso))]
        public IHttpActionResult PostProgreso(Progreso progreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Progreso.Add(progreso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = progreso.IdProgreso }, progreso);
        }

        // DELETE: api/Progreso/5
        [ResponseType(typeof(Progreso))]
        public IHttpActionResult DeleteProgreso(int id)
        {
            Progreso progreso = db.Progreso.Find(id);
            if (progreso == null)
            {
                return NotFound();
            }

            db.Progreso.Remove(progreso);
            db.SaveChanges();

            return Ok(progreso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgresoExists(int id)
        {
            return db.Progreso.Count(e => e.IdProgreso == id) > 0;
        }
    }
}