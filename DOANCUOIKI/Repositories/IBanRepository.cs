using DOANCUOIKI.Models;
namespace DOANCUOIKI.Repository
{
    public interface IBanRepository
    {

        Task<IEnumerable<Ban>> GetAllAsync();
        Task<Ban> GetByIdAsync(int id);
        Task AddAsync(Ban ban);
        Task UpdateAsync(Ban ban);
        Task DeleteAsync(int id);
    }
}
