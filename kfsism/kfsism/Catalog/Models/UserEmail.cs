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
    
    public partial class UserEmail
    {
        public int Id { get; set; }
        public Nullable<int> LoginId { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Entered { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
