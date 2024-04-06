using Microsoft.EntityFrameworkCore;
using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public class EFLoaiThucPhamRepository : ILoaiThucPhamRepository
    {
        private readonly ApplicationDbContext _context;

        public EFLoaiThucPhamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoaiThucPham>> GetAllAsync()
        {
            return await _context.LoaiThucPhams.ToListAsync();
        }

        public async Task<LoaiThucPham> GetByIdAsync(int id)
        {
            return await _context.LoaiThucPhams.FindAsync(id);
        }

        public async Task AddAsync(LoaiThucPham loaiThucPham)
        {
            _context.LoaiThucPhams.Add(loaiThucPham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoaiThucPham loaiThucPham)
        {
            _context.LoaiThucPhams.Update(loaiThucPham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var loaiThucPham = await _context.LoaiThucPhams.FindAsync(id);
            _context.LoaiThucPhams.Remove(loaiThucPham);
            await _context.SaveChangesAsync();
        }
    }
}
