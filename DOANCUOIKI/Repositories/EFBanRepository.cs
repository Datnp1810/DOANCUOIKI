using Microsoft.EntityFrameworkCore;
using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repository
{
    public class EFBanRepository : IBanRepository
    {
        private readonly ApplicationDbContext _context;
        public EFBanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ban>> GetAllAsync()
        {
        
            return await _context.Bans.ToListAsync();

        }
        public async Task<Ban> GetByIdAsync(int id)
        {
            return await _context.Bans.FirstOrDefaultAsync(p => p.SoBan == id);
        }
        public async Task AddAsync(Ban ban)
        {
            _context.Bans.Add(ban);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Ban ban)
        {
            _context.Bans.Update(ban);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var ban = await _context.Bans.FindAsync(id);
            _context.Bans.Remove(ban);
            await _context.SaveChangesAsync();
        } 
    }
}
