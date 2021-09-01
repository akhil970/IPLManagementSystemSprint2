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
    public class PlayersController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();

        public IHttpActionResult GetPlayers()
        {
            
            var player = db.Players.Select(p => new { p.Id, p.Name, p.TeamId, p.Age, p.SpecialityId, p.PhotoId});
            return Ok(player);
        }


        //Details of all the players
        [Route("api/Players/PlayerDetails")]
        [ResponseType(typeof(usp_player_view_Result))]
        public IHttpActionResult GetPlayerDetails()
        {
            var players = db.usp_player_view();
            return Ok(players);
        }
         
        [Route("api/Players/TeamSpeciality")]
        public IHttpActionResult GetTeamSpeciality()
        {
            
            List<Speciality> spec = new List<Speciality>();
            //AllTablesListData teamsAndSpeciality = new AllTablesListData();
            //teamsAndSpeciality.Team = db.Teams.ToList();
            //teamsAndSpeciality.Speciality = db.Specialities.ToList();
            spec = db.Specialities.ToList();
            
            return Ok(spec);
        }

        // GET: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.Id))
                {
                    return Conflict();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}
