//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminPanel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NForm()
        {
            this.NLinks = new HashSet<NLink>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> NCategory { get; set; }
        public Nullable<int> Order_O { get; set; }
    
        public virtual NCategory NCategory1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NLink> NLinks { get; set; }
    }
}
