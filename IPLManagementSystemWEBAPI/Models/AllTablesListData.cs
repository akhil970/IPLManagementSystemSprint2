using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPLManagementSystemWEBAPI.Models;
namespace IPLManagementSystemWEBAPI.Models
{
    public class AllTablesListData
    {
        public List<Match> Match {set;get;}
        public List<Team> Team {set;get;}
        public List<Player> Player {set;get;}
        public List<PlayerPhoto> PlayerPhoto {set;get;}
        public List<AllStatistic> Statistics {set;get;}
        public List<News> News {set;get;}
        public List<Schedule> Schedule {set;get;}
        public List<Venue> Venue { set;get;}
        public List<Speciality> Speciality {set;get;}
        public List<Ticket> Ticket {set;get;}
        public List<TicketCategory> TicketCategory {set;get;}
    }
}