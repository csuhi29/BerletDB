//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PassRegister.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BERLET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BERLET()
        {
            this.VASARLAS = new HashSet<VASARLAS>();
        }
    
        public decimal BERLET_ID { get; set; }
        public string MEGNEVEZES { get; set; }
        public Nullable<decimal> AR { get; set; }
        public Nullable<decimal> ERVENYESSEG_IDO { get; set; }
        public string KEDVEZMENY_TIPUS { get; set; }
        public string BERLET_FORMATUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VASARLAS> VASARLAS { get; set; }
    }
}