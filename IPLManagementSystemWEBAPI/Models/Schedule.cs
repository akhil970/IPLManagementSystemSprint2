//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPLManagementSystemWEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int Id { get; set; }
        public Nullable<int> MatchId { get; set; }
        public Nullable<int> VenueId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
    
        public virtual Venue Venue { get; set; }
    }
}
