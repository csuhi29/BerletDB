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
    
    public partial class CEG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CEG()
        {
            this.DOLGOZO = new HashSet<DOLGOZO>();
        }
    
        public decimal CEG_ID { get; set; }
        public string CEGNEV { get; set; }
        public string SZEKHELY { get; set; }
        public Nullable<decimal> ADOSZAM { get; set; }
        public Nullable<System.DateTime> ALAPITAS_DATUMA { get; set; }
        public Nullable<decimal> JEGYZETT_TOKE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOLGOZO> DOLGOZO { get; set; }
    }
}
