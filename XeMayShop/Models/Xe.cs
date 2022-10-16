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
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            this.ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
        }
    
        public int MaXe { get; set; }
        public Nullable<int> MaLoaiXe { get; set; }
        public Nullable<int> MaDongXe { get; set; }
        public string TenXe { get; set; }
        public string MoTaXe { get; set; }
        public string ThongTinBaoHanh { get; set; }
        public Nullable<double> DonGiaXe { get; set; }
        public Nullable<int> SoLuongHienCo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DongXe DongXe { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
    }
}