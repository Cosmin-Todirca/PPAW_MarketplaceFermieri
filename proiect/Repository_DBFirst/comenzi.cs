//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository_DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class comenzi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comenzi()
        {
            this.obiectComanda = new HashSet<obiecteComanda>();
        }
    
        public int idComanda { get; set; }
        public int idClient { get; set; }
        public System.DateTime dataComanda { get; set; }
        public string situatieComanda { get; set; }
        public decimal total { get; set; }
    
        public virtual clienti clienti { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obiecteComanda> obiectComanda { get; set; }
    }
}
