using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace DOANCUOIKI.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
options) : base(options)
        {
        }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<LoaiThucPham> LoaiThucPhams { get; set; }
        public DbSet<MonAnImage> MonAnImages { get; set; }
        public DbSet<HTThanhToan> HTThanhToans { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CTHoaDon> CTHoaDons { get;set; }
         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CTHoaDon>()
                .HasKey(k => new { k.MaHD, k.MaMon });
        }
    }
}