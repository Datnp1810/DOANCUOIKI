using System.ComponentModel.DataAnnotations;

namespace DOANCUOIKI.Models
{
    public class Ban
    {
        [Key]
        public int SoBan { get; set; }
        [Required]
        public int SLNguoi { get; set; }

        public int status { get; set; } = 0;
    }
}
