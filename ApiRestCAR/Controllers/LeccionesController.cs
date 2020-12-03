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
    public class LeccionesController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/Lecciones
        public IQueryable<Lecciones> GetLecciones()
        {
            return db.Lecciones;
        }

        // GET: api/Lecciones/5
        [ResponseType(typeof(Lecciones))]
        public IHttpActionResult GetLecciones(int id)
        {
            Lecciones lecciones = db.Lecciones.Find(id);
            if (lecciones == null)
            {
                return NotFound();
            }

            return Ok(lecciones);
        }

        // PUT: api/Lecciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLecciones(int id, Lecciones lecciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecciones.IdLeccion)
            {
                return BadRequest();
            }

            db.Entry(lecciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeccionesExists(id))
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

        // POST: api/Lecciones
        [ResponseType(typeof(Lecciones))]
        public IHttpActionResult PostLecciones(Lecciones lecciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lecciones.Add(lecciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lecciones.IdLeccion }, lecciones);
        }

        // DELETE: api/Lecciones/5
        [ResponseType(typeof(Lecciones))]
        public IHttpActionResult DeleteLecciones(int id)
        {
            Lecciones lecciones = db.Lecciones.Find(id);
            if (lecciones == null)
            {
                return NotFound();
            }

            db.Lecciones.Remove(lecciones);
            db.SaveChanges();

            return Ok(lecciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeccionesExists(int id)
        {
            return db.Lecciones.Count(e => e.IdLeccion == id) > 0;
        }
    }
}