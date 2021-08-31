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
    public class TicketCategoriesController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/TicketCategories
        public IQueryable<TicketCategory> GetTicketCategories()
        {
            var ticketCategories = db.TicketCategories.Select(tc => new { tc.Id, tc.Name });
            return db.TicketCategories;
        }

        // GET: api/TicketCategories/5
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult GetTicketCategory(int id)
        {
            TicketCategory ticketCategory = db.TicketCategories.Find(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            return Ok(ticketCategory);
        }

        // PUT: api/TicketCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketCategory(int id, TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(ticketCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCategoryExists(id))
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

        // POST: api/TicketCategories
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult PostTicketCategory(TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketCategories.Add(ticketCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TicketCategoryExists(ticketCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticketCategory.Id }, ticketCategory);
        }

        // DELETE: api/TicketCategories/5
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult DeleteTicketCategory(int id)
        {
            TicketCategory ticketCategory = db.TicketCategories.Find(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            db.TicketCategories.Remove(ticketCategory);
            db.SaveChanges();

            return Ok(ticketCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketCategoryExists(int id)
        {
            return db.TicketCategories.Count(e => e.Id == id) > 0;
        }
    }
}