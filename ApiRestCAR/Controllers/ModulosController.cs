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
    public class ModulosController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/Modulos
        public IQueryable<Modulos> GetModulos()
        {
            return db.Modulos;
        }

        // GET: api/Modulos/5
        [ResponseType(typeof(Modulos))]
        public IHttpActionResult GetModulos(int id)
        {
            Modulos modulos = db.Modulos.Find(id);
            if (modulos == null)
            {
                return NotFound();
            }

            return Ok(modulos);
        }

        // PUT: api/Modulos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModulos(int id, Modulos modulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modulos.IdModulo)
            {
                return BadRequest();
            }

            db.Entry(modulos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulosExists(id))
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

        // POST: api/Modulos
        [ResponseType(typeof(Modulos))]
        public IHttpActionResult PostModulos(Modulos modulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modulos.Add(modulos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modulos.IdModulo }, modulos);
        }

        // DELETE: api/Modulos/5
        [ResponseType(typeof(Modulos))]
        public IHttpActionResult DeleteModulos(int id)
        {
            Modulos modulos = db.Modulos.Find(id);
            if (modulos == null)
            {
                return NotFound();
            }

            db.Modulos.Remove(modulos);
            db.SaveChanges();

            return Ok(modulos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModulosExists(int id)
        {
            return db.Modulos.Count(e => e.IdModulo == id) > 0;
        }
    }
}