//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Catalog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ptwinspection
    {
        public int id { get; set; }
        public int head_id { get; set; }
        public string hot_m { get; set; }
        public string hot_y { get; set; }
        public string cold_m { get; set; }
        public string cold_y { get; set; }
        public string aloft_m { get; set; }
        public string aloft_y { get; set; }
        public string confined_m { get; set; }
        public string confined_y { get; set; }
        public string diving_m { get; set; }
        public string diving_y { get; set; }
        public string electrical_m { get; set; }
        public string electrical_y { get; set; }
        public Nullable<bool> firstaid { get; set; }
        public Nullable<bool> firefighting { get; set; }
        public Nullable<bool> mess { get; set; }
        public Nullable<bool> toilet { get; set; }
        public Nullable<bool> pms { get; set; }
        public Nullable<bool> galley { get; set; }
        public Nullable<bool> lifesaving { get; set; }
        public Nullable<bool> towing_inspect { get; set; }
        public Nullable<bool> radio_inspect { get; set; }
        public Nullable<bool> hull_inspect { get; set; }
        public string remark { get; set; }
    }
}