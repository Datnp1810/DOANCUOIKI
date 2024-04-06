using System.ComponentModel.DataAnnotations;

namespace DOANCUOIKI.Models
{
    public class LoaiThucPham
    {
        [Key]
        public int MaLoaiTP { get; set; }

        [Required, StringLength(100)]
        public string TenLoaiTP { get; set; }

        public List<MonAn>? Mons { get; set; }
    }
}
