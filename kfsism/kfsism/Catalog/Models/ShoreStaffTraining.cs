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
    
    public partial class ShoreStaffTraining
    {
        public int ShoreStaffTrainingID { get; set; }
        public string AttendanceSheet { get; set; }
        public string EvaluationSheet { get; set; }
        public Nullable<System.DateTime> Entered_On { get; set; }
        public Nullable<int> Entered_By { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
