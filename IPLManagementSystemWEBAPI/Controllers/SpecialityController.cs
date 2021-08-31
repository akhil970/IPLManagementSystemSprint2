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
using IPLManagementSystemWEBAPI.Models;

namespace IPLManagementSystemWEBAPI.Controllers
{
    public class SpecialityController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/Speciality
        public IHttpActionResult GetSpecialities()
        {
            var speciality = db.Specialities.Select(s => new { s.Id, s.Description });
            return Ok(speciality);
        }

        // GET: api/Speciality/5
        [ResponseType(typeof(Speciality))]
        public IHttpActionResult GetSpeciality(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return NotFound();
            }

            return Ok(speciality);
        }

        // PUT: api/Speciality/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpeciality(int id, Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speciality.Id)
            {
                return BadRequest();
            }

            db.Entry(speciality).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Speciality
        [ResponseType(typeof(Speciality))]
        public IHttpActionResult PostSpeciality(Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specialities.Add(speciality);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SpecialityExists(speciality.Id))
                {
                    return BadRequest();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = speciality.Id }, speciality);
        }

        // DELETE: api/Speciality/5
        [ResponseType(typeof(Speciality))]
        public IHttpActionResult DeleteSpeciality(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return NotFound();
            }

            db.Specialities.Remove(speciality);
            db.SaveChanges();

            return Ok(speciality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialityExists(int id)
        {
            return db.Specialities.Count(e => e.Id == id) > 0;
        }
    }
}