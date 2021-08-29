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
    public class UsersnController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/Usersn
        public IQueryable<UsersTable> GetUsersTables()
        {
            return db.UsersTables;
        }

        // GET: api/Usersn/5
        [ResponseType(typeof(UsersTable))]
        public IHttpActionResult GetUsersTable(int id)
        {
            UsersTable usersTable = db.UsersTables.Find(id);
            if (usersTable == null)
            {
                return NotFound();
            }

            return Ok(usersTable);
        }

        // PUT: api/Usersn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsersTable(int id, UsersTable usersTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersTable.UserID)
            {
                return BadRequest();
            }

            db.Entry(usersTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersTableExists(id))
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

        // POST: api/Usersn
        [ResponseType(typeof(UsersTable))]
        public IHttpActionResult PostUsersTable(UsersTable usersTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersTables.Add(usersTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usersTable.UserID }, usersTable);
        }

        // DELETE: api/Usersn/5
        [ResponseType(typeof(UsersTable))]
        public IHttpActionResult DeleteUsersTable(int id)
        {
            UsersTable usersTable = db.UsersTables.Find(id);
            if (usersTable == null)
            {
                return NotFound();
            }

            db.UsersTables.Remove(usersTable);
            db.SaveChanges();

            return Ok(usersTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersTableExists(int id)
        {
            return db.UsersTables.Count(e => e.UserID == id) > 0;
        }
    }
}