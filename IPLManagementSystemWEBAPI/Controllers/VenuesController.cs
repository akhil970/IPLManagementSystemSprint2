﻿using System;
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
    public class VenuesController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/Venues
        public IHttpActionResult GetVenues()
        {
            var venues = db.Venues.Select(v => new { v.Id,v.Location,v.Description });
            return Ok(venues);
        }

        // GET: api/Venues/5
        [ResponseType(typeof(Venue))]
        public IHttpActionResult GetVenue(int id)
        {
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }

        // PUT: api/Venues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenue(int id, Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venue.Id)
            {
                return BadRequest();
            }

            db.Entry(venue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueExists(id))
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

        // POST: api/Venues
        [ResponseType(typeof(Venue))]
        public IHttpActionResult PostVenue(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Venues.Add(venue);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VenueExists(venue.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = venue.Id }, venue);
        }

        // DELETE: api/Venues/5
        [ResponseType(typeof(Venue))]
        public IHttpActionResult DeleteVenue(int id)
        {
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return NotFound();
            }

            db.Venues.Remove(venue);
            db.SaveChanges();

            return Ok(venue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VenueExists(int id)
        {
            return db.Venues.Count(e => e.Id == id) > 0;
        }
    }
}