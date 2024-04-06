using System.ComponentModel.DataAnnotations;

namespace DOANCUOIKI.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        public Ban? Ban { get; set; }
        public int SoBan { get; set; }

        public DateTime NgayVao { get; set; }
        public DateTime NgayRa { get; set; }

        public List<CTHoaDon>? ct_hoadon {  get; set; }
        public HTThanhToan? HTTToan { get; set; }
        public int IdThanhToan { get; set; }
        public virtual ICollection<MonAn>? MonAns { get; set; }
    }
}
