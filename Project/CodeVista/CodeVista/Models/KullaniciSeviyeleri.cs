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
    
    public partial class KullaniciSeviyeleri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KullaniciSeviyeleri()
        {
            this.Kaynaklar = new HashSet<Kaynaklar>();
            this.Kullaniciİstatistikleri = new HashSet<Kullaniciİstatistikleri>();
            this.Kullanicilar = new HashSet<Kullanicilar>();
        }
    
        public int SeviyeİD { get; set; }
        public string SeviyeAdi { get; set; }
        public string SeviyeAciklama { get; set; }
        public Nullable<int> ResimID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kaynaklar> Kaynaklar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullaniciİstatistikleri> Kullaniciİstatistikleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanicilar> Kullanicilar { get; set; }
        public virtual Resimler Resimler { get; set; }
    }
}
