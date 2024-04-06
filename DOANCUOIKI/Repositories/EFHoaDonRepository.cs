using DOANCUOIKI.Models;
using Microsoft.EntityFrameworkCore;

namespace DOANCUOIKI.Repositories
{
    public class EFHoaDonRepository:IHoaDonRepository
    {
        private readonly ApplicationDbContext _context;
        public EFHoaDonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HoaDon>> GetAllAsync()
        {
            // return await _context.Bans.ToListAsync();
            return await _context.HoaDons.ToListAsync();

        }
        public async Task<HoaDon> GetByIdAsync(int id)
        {
            return await _context.HoaDons.FirstOrDefaultAsync(p => p.MaHD == id);
        }
        public async Task AddAsync(HoaDon hoadon)
        {
            _context.HoaDons.Add(hoadon);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(HoaDon hoadon)
        {
            _context.HoaDons.Update(hoadon);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var ban = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(ban);
            await _context.SaveChangesAsync();
        }
    }
}
