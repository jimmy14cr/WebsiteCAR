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
    public class AsigCursoRolController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/AsigCursoRol
        public IQueryable<AsigCursoRol> GetAsigCursoRol()
        {
            return db.AsigCursoRol;
        }

        // GET: api/AsigCursoRol/5
        [ResponseType(typeof(AsigCursoRol))]
        public IHttpActionResult GetAsigCursoRol(int id)
        {
            AsigCursoRol asigCursoRol = db.AsigCursoRol.Find(id);
            if (asigCursoRol == null)
            {
                return NotFound();
            }

            return Ok(asigCursoRol);
        }

        // PUT: api/AsigCursoRol/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsigCursoRol(int id, AsigCursoRol asigCursoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asigCursoRol.IdAsignacion)
            {
                return BadRequest();
            }

            db.Entry(asigCursoRol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsigCursoRolExists(id))
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

        // POST: api/AsigCursoRol
        [ResponseType(typeof(AsigCursoRol))]
        public IHttpActionResult PostAsigCursoRol(AsigCursoRol asigCursoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AsigCursoRol.Add(asigCursoRol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asigCursoRol.IdAsignacion }, asigCursoRol);
        }

        // DELETE: api/AsigCursoRol/5
        [ResponseType(typeof(AsigCursoRol))]
        public IHttpActionResult DeleteAsigCursoRol(int id)
        {
            AsigCursoRol asigCursoRol = db.AsigCursoRol.Find(id);
            if (asigCursoRol == null)
            {
                return NotFound();
            }

            db.AsigCursoRol.Remove(asigCursoRol);
            db.SaveChanges();

            return Ok(asigCursoRol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsigCursoRolExists(int id)
        {
            return db.AsigCursoRol.Count(e => e.IdAsignacion == id) > 0;
        }
    }
}