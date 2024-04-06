using System.ComponentModel.DataAnnotations;

namespace DOANCUOIKI.Models
{
    public class HTThanhToan
    {
        [Key]
        public int IdThanhToan { get; set; }
        public string HinhThuc {  get; set; }
    }
}
