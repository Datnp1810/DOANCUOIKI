using System.ComponentModel.DataAnnotations;

namespace DOANCUOIKI.Models
{
    public class MonAn
    {
        [Key]
        public int MaMon { get; set; }

        [Required, StringLength(100)]
       
        public string TenMon { get; set; }

        
        public string? ImageUrl { get; set; }

        public List<MonAnImage>? Images { get; set; }
       

        public string DVT { get; set; }
        public decimal Gia { get; set; }

        public int LoaiThucPhamId { get; set; }

        public LoaiThucPham? LoaiThucPham { get; set; }

        public List<CTHoaDon>? ct_hoadon { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }

    }
}
