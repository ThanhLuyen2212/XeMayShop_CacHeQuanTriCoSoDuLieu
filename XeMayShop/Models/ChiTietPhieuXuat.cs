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
    
    public partial class ChiTietPhieuXuat
    {
        public int MaXe { get; set; }
        public int MaPhieuXuat { get; set; }
        public Nullable<int> SoLuongXuat { get; set; }
        public Nullable<double> DonGiaXuat { get; set; }
    
        public virtual PhieuXuat PhieuXuat { get; set; }
        public virtual Xe Xe { get; set; }
    }
}
