using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IPLManagementSystemWEBAPI.Models;

namespace IPLManagementSystemWEBAPI.Controllers
{
    public class CustomerPlayerController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayersofTeam(string teamname)
        {
            var playersonly = db.GetPlayers(teamname);
            return Ok(playersonly);

            //AllTablesListData players = new AllTablesListData();
            //players.Player = db.Players.ToList();
            //return Ok(players);
        }
    }
}
