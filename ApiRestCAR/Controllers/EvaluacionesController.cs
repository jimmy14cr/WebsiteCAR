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
    public class EvaluacionesController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/Evaluaciones
        public IQueryable<Evaluaciones> GetEvaluaciones()
        {
            return db.Evaluaciones;
        }

        // GET: api/Evaluaciones/5
        [ResponseType(typeof(Evaluaciones))]
        public IHttpActionResult GetEvaluaciones(int id)
        {
            Evaluaciones evaluaciones = db.Evaluaciones.Find(id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            return Ok(evaluaciones);
        }

        // PUT: api/Evaluaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvaluaciones(int id, Evaluaciones evaluaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluaciones.IdEvaluacion)
            {
                return BadRequest();
            }

            db.Entry(evaluaciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionesExists(id))
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

        // POST: api/Evaluaciones
        [ResponseType(typeof(Evaluaciones))]
        public IHttpActionResult PostEvaluaciones(Evaluaciones evaluaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evaluaciones.Add(evaluaciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = evaluaciones.IdEvaluacion }, evaluaciones);
        }

        // DELETE: api/Evaluaciones/5
        [ResponseType(typeof(Evaluaciones))]
        public IHttpActionResult DeleteEvaluaciones(int id)
        {
            Evaluaciones evaluaciones = db.Evaluaciones.Find(id);
            if (evaluaciones == null)
            {
                return NotFound();
            }

            db.Evaluaciones.Remove(evaluaciones);
            db.SaveChanges();

            return Ok(evaluaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvaluacionesExists(int id)
        {
            return db.Evaluaciones.Count(e => e.IdEvaluacion == id) > 0;
        }
    }
}