//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeVista.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sektorler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sektorler()
        {
            this.DilKonulari = new HashSet<DilKonulari>();
            this.Diller = new HashSet<Diller>();
            this.Konular = new HashSet<Konular>();
        }
    
        public int SektorID { get; set; }
        public string SektorAdi { get; set; }
        public int PopulerYazilimDiliİD { get; set; }
        public Nullable<int> ResimID { get; set; }
        public string resim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DilKonulari> DilKonulari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diller> Diller { get; set; }
        public virtual Diller Diller1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konular> Konular { get; set; }
        public virtual Resimler Resimler { get; set; }
    }
}
