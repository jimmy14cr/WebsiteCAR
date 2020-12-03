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
    public class RegistroController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/Registro
        public IQueryable<Registro> GetRegistro()
        {
            return db.Registro;
        }

        // GET: api/Registro/5
        [ResponseType(typeof(Registro))]
        public IHttpActionResult GetRegistro(int id)
        {
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        // PUT: api/Registro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistro(int id, Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro.IdRegistro)
            {
                return BadRequest();
            }

            db.Entry(registro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
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

        // POST: api/Registro
        [ResponseType(typeof(Registro))]
        public IHttpActionResult PostRegistro(Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registro.Add(registro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registro.IdRegistro }, registro);
        }

        // DELETE: api/Registro/5
        [ResponseType(typeof(Registro))]
        public IHttpActionResult DeleteRegistro(int id)
        {
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return NotFound();
            }

            db.Registro.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroExists(int id)
        {
            return db.Registro.Count(e => e.IdRegistro == id) > 0;
        }
    }
}