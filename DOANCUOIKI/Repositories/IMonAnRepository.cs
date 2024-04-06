using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public interface IMonAnRepository
    {
        Task<IEnumerable<MonAn>> GetAllAsync();
        Task<MonAn> GetByIdAsync(int id);
        Task AddAsync(MonAn monan);
        Task UpdateAsync(MonAn monan);
        Task DeleteAsync(int id);
    }
}
