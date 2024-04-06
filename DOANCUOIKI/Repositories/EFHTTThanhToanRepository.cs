using DOANCUOIKI.Models;
using Microsoft.EntityFrameworkCore;

namespace DOANCUOIKI.Repositories
{
    public class EFHTTThanhToanRepository : IHTThanhToanRepository
    {

        private readonly ApplicationDbContext _context;
        public EFHTTThanhToanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HTThanhToan>> GetAllAsync()
        {
            // return await _context.Bans.ToListAsync();
            return await _context.HTThanhToans.ToListAsync();

        }
        public async Task<HTThanhToan> GetByIdAsync(int id)
        {
            return await _context.HTThanhToans.FirstOrDefaultAsync(p => p.IdThanhToan == id);
        }
        public async Task AddAsync(HTThanhToan htttoan)
        {
            _context.HTThanhToans.Add(htttoan);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(HTThanhToan htttoan)
        {
            _context.HTThanhToans.Update(htttoan);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var htttoan = await _context.HTThanhToans.FindAsync(id);
            _context.HTThanhToans.Remove(htttoan);
            await _context.SaveChangesAsync();
        }

        
    }
}
