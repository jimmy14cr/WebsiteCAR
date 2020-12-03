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
    public class TipoLeccionController : ApiController
    {
        private DbCAREntidades db = new DbCAREntidades();

        // GET: api/TipoLeccion
        public IQueryable<TipoLeccion> GetTipoLeccion()
        {
            return db.TipoLeccion;
        }

        // GET: api/TipoLeccion/5
        [ResponseType(typeof(TipoLeccion))]
        public IHttpActionResult GetTipoLeccion(int id)
        {
            TipoLeccion tipoLeccion = db.TipoLeccion.Find(id);
            if (tipoLeccion == null)
            {
                return NotFound();
            }

            return Ok(tipoLeccion);
        }

        // PUT: api/TipoLeccion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoLeccion(int id, TipoLeccion tipoLeccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoLeccion.IdTipoLeccion)
            {
                return BadRequest();
            }

            db.Entry(tipoLeccion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLeccionExists(id))
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

        // POST: api/TipoLeccion
        [ResponseType(typeof(TipoLeccion))]
        public IHttpActionResult PostTipoLeccion(TipoLeccion tipoLeccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoLeccion.Add(tipoLeccion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoLeccion.IdTipoLeccion }, tipoLeccion);
        }

        // DELETE: api/TipoLeccion/5
        [ResponseType(typeof(TipoLeccion))]
        public IHttpActionResult DeleteTipoLeccion(int id)
        {
            TipoLeccion tipoLeccion = db.TipoLeccion.Find(id);
            if (tipoLeccion == null)
            {
                return NotFound();
            }

            db.TipoLeccion.Remove(tipoLeccion);
            db.SaveChanges();

            return Ok(tipoLeccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoLeccionExists(int id)
        {
            return db.TipoLeccion.Count(e => e.IdTipoLeccion == id) > 0;
        }
    }
}