using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using IPLManagementSystemWEBAPI.Models;

namespace IPLManagementSystemWEBAPI.Controllers
{
    public class MatchesController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/Matches
        public IHttpActionResult GetMatches()
        {
            var match = db.Matches.Select(m => new { m.Id, m.ScheduleId, m.VenueId, m.TeamOneId, m.TeamTwoId, m.MatchPhoto });
            return Ok(match);
        }
        //Details of all the matches
        [Route("api/Matches/MatchesDetails")]
        [ResponseType(typeof(usp_match_view_Result))]
        public IHttpActionResult GetMatchesDetails()
        {
            var matches = db.usp_match_view();
            return Ok(matches);
        }

        [Route("api/Matches/TeamVenueSchedule")]
        public IHttpActionResult GetTeamVenueSchedule()
        {
            AllTablesListData teamVenueSchedule = new AllTablesListData();
            teamVenueSchedule.Schedule = db.Schedules.ToList();
            teamVenueSchedule.Team = db.Teams.ToList();
            teamVenueSchedule.Venue = db.Venues.ToList();
            return Ok(teamVenueSchedule);
        }
        
        // GET: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/Matches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatch(int id, Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.Id)
            {
                return BadRequest();
            }

            db.Entry(match).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Matches
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string path = HttpContext.Current.Server.MapPath("~/Images/"); //maps to web api folders
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count == 1)
            {
                var Imgfile = httpRequest.Files[0];
                var LocalImgFilePath = HttpContext.Current.Server.MapPath("~/Images/" + Imgfile.FileName);
                Imgfile.SaveAs(LocalImgFilePath);
                var dbImagePath = "https://localhost:44307/Images/" + Imgfile.FileName;
                Match matchInfo = new Match()
                {
                    Id = Convert.ToInt32(httpRequest.Form["Id"]),
                    TeamOneId = Convert.ToInt32(httpRequest.Form["TeamOneId"]),
                    TeamTwoId = Convert.ToInt32(httpRequest.Form["TeamTwoId"]),
                    VenueId = Convert.ToInt32(httpRequest.Form["VenueId"]),
                    ScheduleId = Convert.ToInt32(httpRequest.Form["ScheduleId"]),
                    MatchPhoto = dbImagePath
                };
                try
                {
                    db.Matches.Add(matchInfo);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest(ModelState);
                }
                return Redirect("https://localhost:44349/MatchMVC");
            }
            return BadRequest(ModelState);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Matches.Add(match);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (MatchExists(match.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult DeleteMatch(int id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            db.Matches.Remove(match);
            db.SaveChanges();

            return Ok(match);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchExists(int id)
        {
            return db.Matches.Count(e => e.Id == id) > 0;
        }
    }
}