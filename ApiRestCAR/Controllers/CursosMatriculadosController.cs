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
    public class CursosMatriculadosController : ApiController
    {
        private DbCoopeAlfaroRuizEntidades db = new DbCoopeAlfaroRuizEntidades();

        // GET: api/CursosMatriculados
        public IQueryable<CursosMatriculados> GetCursosMatriculados()
        {
            return db.CursosMatriculados;
        }

        // GET: api/CursosMatriculados/5
        [ResponseType(typeof(CursosMatriculados))]
        public IHttpActionResult GetCursosMatriculados(int id)
        {
            CursosMatriculados cursosMatriculados = db.CursosMatriculados.Find(id);
            if (cursosMatriculados == null)
            {
                return NotFound();
            }

            return Ok(cursosMatriculados);
        }

        // PUT: api/CursosMatriculados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursosMatriculados(int id, CursosMatriculados cursosMatriculados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursosMatriculados.IdCursoMatriculado)
            {
                return BadRequest();
            }

            db.Entry(cursosMatriculados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosMatriculadosExists(id))
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

        // POST: api/CursosMatriculados
        [ResponseType(typeof(CursosMatriculados))]
        public IHttpActionResult PostCursosMatriculados(CursosMatriculados cursosMatriculados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CursosMatriculados.Add(cursosMatriculados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cursosMatriculados.IdCursoMatriculado }, cursosMatriculados);
        }

        // DELETE: api/CursosMatriculados/5
        [ResponseType(typeof(CursosMatriculados))]
        public IHttpActionResult DeleteCursosMatriculados(int id)
        {
            CursosMatriculados cursosMatriculados = db.CursosMatriculados.Find(id);
            if (cursosMatriculados == null)
            {
                return NotFound();
            }

            db.CursosMatriculados.Remove(cursosMatriculados);
            db.SaveChanges();

            return Ok(cursosMatriculados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursosMatriculadosExists(int id)
        {
            return db.CursosMatriculados.Count(e => e.IdCursoMatriculado == id) > 0;
        }
    }
}