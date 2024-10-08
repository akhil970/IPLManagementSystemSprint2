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
    public class AllStatisticsController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/AllStatistics
        public IHttpActionResult GetAllStatistics()
        {
            var stats = db.AllStatistics.Select(sta => new { sta.Id,sta.TeamId, sta.Played, sta.Won, sta.Lost, sta.Tied, sta.NRR, sta.NoResult, sta.Points });
            return Ok(stats);
        }

        [Route("api/AllStatistics/Statistics")]
        [ResponseType(typeof(usp_allstatistics_teamname_Result))]
        public IHttpActionResult GetStatistics()
        {
            var stats = db.usp_allstatistics_teamname();
            return Ok(stats);
        }

        [Route("api/AllStatistics/Teamname")]
        [ResponseType(typeof(Team))]
        public IHttpActionResult GetTeamname()
        {
            List<Team> teamName = new List<Team>();
            teamName = db.Teams.ToList();
            return Ok(teamName);
        }

        // GET: api/AllStatistics/5
        [ResponseType(typeof(AllStatistic))]
        public IHttpActionResult GetAllStatistic(int id)
        {
            AllStatistic allStatistic = db.AllStatistics.Find(id);
            if (allStatistic == null)
            {
                return NotFound();
            }

            return Ok(allStatistic);
        }

        // PUT: api/AllStatistics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAllStatistic(int id, AllStatistic allStatistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allStatistic.Id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(allStatistic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllStatisticExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            //200 operation susccesfull, 204 operation sucessfull and it return no data
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AllStatistics
        [ResponseType(typeof(AllStatistic))]
        public IHttpActionResult PostAllStatistic(AllStatistic allStatistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AllStatistics.Add(allStatistic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AllStatisticExists(allStatistic.Id))
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = allStatistic.Id }, allStatistic);
        }

        // DELETE: api/AllStatistics/5
        [ResponseType(typeof(AllStatistic))]
        public IHttpActionResult DeleteAllStatistic(int id)
        {
            AllStatistic allStatistic = db.AllStatistics.Find(id);
            if (allStatistic == null)
            {
                return NotFound();
            }

            db.AllStatistics.Remove(allStatistic);
            db.SaveChanges();

            return Ok(allStatistic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllStatisticExists(int id)
        {
            return db.AllStatistics.Count(e => e.Id == id) > 0;
        }
    }
}