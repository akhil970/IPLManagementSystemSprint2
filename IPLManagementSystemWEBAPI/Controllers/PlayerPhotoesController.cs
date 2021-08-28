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
    public class PlayerPhotoesController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/PlayerPhotoes
        public IHttpActionResult GetPlayerPhotoes()
        {
            var playerphotos = db.PlayerPhotoes.Select(p => new { p.Id, p.Photo });
            return Ok(playerphotos);
        }

        // GET: api/PlayerPhotoes/5
        [ResponseType(typeof(PlayerPhoto))]
        public IHttpActionResult GetPlayerPhoto(int id)
        {
            PlayerPhoto playerPhoto = db.PlayerPhotoes.Find(id);
            if (playerPhoto == null)
            {
                return NotFound();
            }

            return Ok(playerPhoto);
        }

        // PUT: api/PlayerPhotoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerPhoto(int id, PlayerPhoto playerPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerPhoto.Id)
            {
                return BadRequest();
            }

            db.Entry(playerPhoto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerPhotoExists(id))
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

        // POST: api/PlayerPhotoes
        [ResponseType(typeof(PlayerPhoto))]
        public IHttpActionResult PostPlayerPhoto(PlayerPhoto playerPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlayerPhotoes.Add(playerPhoto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerPhotoExists(playerPhoto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = playerPhoto.Id }, playerPhoto);
        }

        // DELETE: api/PlayerPhotoes/5
        [ResponseType(typeof(PlayerPhoto))]
        public IHttpActionResult DeletePlayerPhoto(int id)
        {
            PlayerPhoto playerPhoto = db.PlayerPhotoes.Find(id);
            if (playerPhoto == null)
            {
                return NotFound();
            }

            db.PlayerPhotoes.Remove(playerPhoto);
            db.SaveChanges();

            return Ok(playerPhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerPhotoExists(int id)
        {
            return db.PlayerPhotoes.Count(e => e.Id == id) > 0;
        }
    }
}