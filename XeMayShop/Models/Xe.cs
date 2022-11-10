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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            this.PhieuDatXes = new HashSet<PhieuDatXe>();
            this.PhieuXuats = new HashSet<PhieuXuat>();
        }
    
        public int MaXe { get; set; }
        public string MauXe { get; set; }
        public Nullable<int> MaLoaiXe { get; set; }
        public Nullable<int> MaDongXe { get; set; }
        public Nullable<int> MaChiNhanh { get; set; }
        public string TenXe { get; set; }
        public Nullable<double> GiaXe { get; set; }
        public Nullable<double> TrongLuong { get; set; }
        public Nullable<int> NamSanXuat { get; set; }
        public string ThongTinBaoHanh { get; set; }
        public Nullable<int> SoLuongHienCo { get; set; }
        public byte[] HinhAnh { get; set; }
    
        public virtual ChiNhanh ChiNhanh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DongXe DongXe { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatXe> PhieuDatXes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
