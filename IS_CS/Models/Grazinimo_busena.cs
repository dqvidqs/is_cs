//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IS_CS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grazinimo_busena
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grazinimo_busena()
        {
            this.Grazinimas = new HashSet<Grazinima>();
        }
    
        public int busena { get; set; }
        public System.DateTime busenos_pakeitimo_data { get; set; }
        public int fk_grazinimo_busena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grazinima> Grazinimas { get; set; }
        public virtual Grazinimo_busenos Grazinimo_busenos { get; set; }
    }
}
