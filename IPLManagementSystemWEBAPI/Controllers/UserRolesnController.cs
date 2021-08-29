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
    public class UserRolesnController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/UserRolesn
        public IQueryable<UserRolesTable> GetUserRolesTables()
        {
            return db.UserRolesTables;
        }

        // GET: api/UserRolesn/5
        [ResponseType(typeof(UserRolesTable))]
        public IHttpActionResult GetUserRolesTable(int id)
        {
            UserRolesTable userRolesTable = db.UserRolesTables.Find(id);
            if (userRolesTable == null)
            {
                return NotFound();
            }

            return Ok(userRolesTable);
        }

        // PUT: api/UserRolesn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserRolesTable(int id, UserRolesTable userRolesTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRolesTable.Id)
            {
                return BadRequest();
            }

            db.Entry(userRolesTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesTableExists(id))
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

        // POST: api/UserRolesn
        [ResponseType(typeof(UserRolesTable))]
        public IHttpActionResult PostUserRolesTable(UserRolesTable userRolesTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserRolesTables.Add(userRolesTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userRolesTable.Id }, userRolesTable);
        }

        // DELETE: api/UserRolesn/5
        [ResponseType(typeof(UserRolesTable))]
        public IHttpActionResult DeleteUserRolesTable(int id)
        {
            UserRolesTable userRolesTable = db.UserRolesTables.Find(id);
            if (userRolesTable == null)
            {
                return NotFound();
            }

            db.UserRolesTables.Remove(userRolesTable);
            db.SaveChanges();

            return Ok(userRolesTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRolesTableExists(int id)
        {
            return db.UserRolesTables.Count(e => e.Id == id) > 0;
        }
    }
}