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
    
    public partial class usp_allstatistics_teamname_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Tied { get; set; }
        public int NoResult { get; set; }
        public Nullable<int> Points { get; set; }
        public decimal NRR { get; set; }
    }
}
