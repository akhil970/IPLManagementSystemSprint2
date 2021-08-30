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
    public class TeamsController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        // GET: api/Teams
        public IHttpActionResult GetTeams()
        {
            var teams = db.Teams.Select(t => new { t.Id, t.Name, t.Logo_Image, t.Home_Ground, t.Franchise_Owners });
            return Ok(teams);
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public IHttpActionResult PostTeam()
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
                Team teamInfo = new Team()
                {
                    Id = Convert.ToInt32(httpRequest.Form["Id"]),
                    Name = httpRequest.Form["Name"],
                    Home_Ground = httpRequest.Form["Home_Ground"],
                    Franchise_Owners = httpRequest.Form["Franchise_Owners"],
                    Logo_Image = dbImagePath
                };
                try
                {
                    db.Teams.Add(teamInfo);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest(ModelState);
                }
                return Redirect("https://localhost:44349/TeamMVC");
            }
            return BadRequest(ModelState);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Teams.Add(team);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (TeamExists(team.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}