using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class Player
    {
        public int Id { get; set; }
        public Nullable<int> TeamId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> SpecialityId { get; set; }
        public Nullable<int> PhotoId { get; set; }

        public virtual PlayerPhoto PlayerPhoto { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Team Team { get; set; }
    }
}