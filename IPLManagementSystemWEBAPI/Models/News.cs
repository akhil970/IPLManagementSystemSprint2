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
    
    public partial class News
    {
        public int Id { get; set; }
        public System.DateTime News_Date { get; set; }
        public Nullable<int> MatchId { get; set; }
        public string Description { get; set; }
    
        public virtual Match Match { get; set; }
    }
}
