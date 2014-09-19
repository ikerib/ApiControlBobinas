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
using ApiControlBobinas.Models;

namespace ApiControlBobinas
{
    public class menusController : ApiController
    {
        private ApiControlBobinasDBContext db = new ApiControlBobinasDBContext();

        // GET api/menus
        public IQueryable<menus> Getmenus()
        {
            return db.menus;
        }

        // GET api/menus/5
        [ResponseType(typeof(menus))]
        public IHttpActionResult Getmenus(int id)
        {
            menus menus = db.menus.Find(id);
            if (menus == null)
            {
                return NotFound();
            }

            return Ok(menus);
        }

        // PUT api/menus/5
        public IHttpActionResult Putmenus(int id, menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menus.id)
            {
                return BadRequest();
            }

            db.Entry(menus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!menusExists(id))
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

        // POST api/menus
        [ResponseType(typeof(menus))]
        public IHttpActionResult Postmenus(menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.menus.Add(menus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menus.id }, menus);
        }

        // DELETE api/menus/5
        [ResponseType(typeof(menus))]
        public IHttpActionResult Deletemenus(int id)
        {
            menus menus = db.menus.Find(id);
            if (menus == null)
            {
                return NotFound();
            }

            db.menus.Remove(menus);
            db.SaveChanges();

            return Ok(menus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool menusExists(int id)
        {
            return db.menus.Count(e => e.id == id) > 0;
        }
    }
}