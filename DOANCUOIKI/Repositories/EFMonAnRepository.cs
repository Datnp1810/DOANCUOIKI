using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public class EFMonAnRepository : IMonAnRepository
    {
        private readonly ApplicationDbContext _context;

        public EFMonAnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MonAn>> GetAllAsync()
        {
            return await _context.MonAns
                .Include(m => m.LoaiThucPham) // Include thông tin về loại thực phẩm
                .ToListAsync();
        }

        public async Task<MonAn> GetByIdAsync(int id)
        {
            return await _context.MonAns
                .Include(m => m.LoaiThucPham) // Include thông tin về loại thực phẩm
                .FirstOrDefaultAsync(m => m.MaMon == id);
        }

        public async Task AddAsync(MonAn monAn)
        {
            _context.MonAns.Add(monAn);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MonAn monAn)
        {
            _context.MonAns.Update(monAn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var monAn = await _context.MonAns.FindAsync(id);
            _context.MonAns.Remove(monAn);
            await _context.SaveChangesAsync();
        }
    }
}
