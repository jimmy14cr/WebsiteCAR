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
    public class DetalleEvaluacionController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/DetalleEvaluacion
        public IQueryable<DetalleEvaluacion> GetDetalleEvaluacion()
        {
            return db.DetalleEvaluacion;
        }

        // GET: api/DetalleEvaluacion/5
        [ResponseType(typeof(DetalleEvaluacion))]
        public IHttpActionResult GetDetalleEvaluacion(int id)
        {
            DetalleEvaluacion detalleEvaluacion = db.DetalleEvaluacion.Find(id);
            if (detalleEvaluacion == null)
            {
                return NotFound();
            }

            return Ok(detalleEvaluacion);
        }

        // PUT: api/DetalleEvaluacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetalleEvaluacion(int id, DetalleEvaluacion detalleEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalleEvaluacion.IdDetalle)
            {
                return BadRequest();
            }

            db.Entry(detalleEvaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleEvaluacionExists(id))
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

        // POST: api/DetalleEvaluacion
        [ResponseType(typeof(DetalleEvaluacion))]
        public IHttpActionResult PostDetalleEvaluacion(DetalleEvaluacion detalleEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetalleEvaluacion.Add(detalleEvaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalleEvaluacion.IdDetalle }, detalleEvaluacion);
        }

        // DELETE: api/DetalleEvaluacion/5
        [ResponseType(typeof(DetalleEvaluacion))]
        public IHttpActionResult DeleteDetalleEvaluacion(int id)
        {
            DetalleEvaluacion detalleEvaluacion = db.DetalleEvaluacion.Find(id);
            if (detalleEvaluacion == null)
            {
                return NotFound();
            }

            db.DetalleEvaluacion.Remove(detalleEvaluacion);
            db.SaveChanges();

            return Ok(detalleEvaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetalleEvaluacionExists(int id)
        {
            return db.DetalleEvaluacion.Count(e => e.IdDetalle == id) > 0;
        }
    }
}