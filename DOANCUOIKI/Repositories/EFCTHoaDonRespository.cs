using DOANCUOIKI.Models;
using Microsoft.EntityFrameworkCore;

namespace DOANCUOIKI.Repositories
{
    public class EFCTHoaDonRespository : ICTHoaDonRepository
    {
        private readonly ApplicationDbContext _context;
        public EFCTHoaDonRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CTHoaDon>> GetAllAsync()
        {
            // return await _context.Bans.ToListAsync();
            return await _context.CTHoaDons.ToListAsync();

        }
        public async Task<CTHoaDon> GetByIdAsync(int id)
        {
            return await _context.CTHoaDons.FirstOrDefaultAsync(p => p.MaHD == id);
        }
        public async Task AddAsync(CTHoaDon ct_hoadon)
        {
            _context.CTHoaDons.Add(ct_hoadon);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CTHoaDon ct_hoadon)
        {
            _context.CTHoaDons.Update(ct_hoadon);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var ct_hoadon = await _context.CTHoaDons.FindAsync(id);
            _context.CTHoaDons.Remove(ct_hoadon);
            await _context.SaveChangesAsync();
        }
    }
}
