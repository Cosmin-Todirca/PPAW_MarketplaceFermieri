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

    [Serializable]
    public partial class clienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clienti()
        {
            this.comanda = new HashSet<comenzi>();
            this.obiectComanda = new HashSet<obiecteComanda>();
        }
    
        public int idClient { get; set; }
        public string numeClient { get; set; }
        public string prenumeClient { get; set; }
        public string email { get; set; }
        public string numarTelefon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comenzi> comanda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obiecteComanda> obiectComanda { get; set; }
    }
}
