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
    
    public partial class Sertifikalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sertifikalar()
        {
            this.Basarilar = new HashSet<Basarilar>();
        }
    
        public int SertifikaİD { get; set; }
        public string SertifikaAdi { get; set; }
        public string VerenKurulus { get; set; }
        public System.DateTime VerilisTarihi { get; set; }
        public int KullaniciİD { get; set; }
        public Nullable<int> ResimID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basarilar> Basarilar { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual Resimler Resimler { get; set; }
    }
}