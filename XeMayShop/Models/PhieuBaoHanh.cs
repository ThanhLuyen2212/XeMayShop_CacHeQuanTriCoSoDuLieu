//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XeMayShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuBaoHanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuBaoHanh()
        {
            this.ChiTietPhieuBaoHanhs = new HashSet<ChiTietPhieuBaoHanh>();
        }
    
        public int MaPhieuBaoHanh { get; set; }
        public Nullable<int> MaPhieuXuat { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<int> ThoiGianBaoHanh { get; set; }
        public string SoKhung { get; set; }
        public string SoSuon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public virtual PhieuXuat PhieuXuat { get; set; }
    }
}
