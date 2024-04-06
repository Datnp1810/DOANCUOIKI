namespace DOANCUOIKI.Models
{
    public class MonAnImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int MonAnId { get; set; }

        public MonAn? MonAn { get; set; }
    }
}