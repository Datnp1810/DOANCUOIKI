using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOANCUOIKI.Models
{
    public class CTHoaDon
    {
        [Key]
        public int ID { get; set; }
        public HoaDon? HoaDon { get; set;}
        public int MaHD { get; set; }

        public MonAn? MonAn { get; set; }
        public int MaMon {  get; set; }

        public int Soluong { get; set; }
        public decimal Dongia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
