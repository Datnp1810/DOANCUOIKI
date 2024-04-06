using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public interface IHTThanhToanRepository
    {
        Task<IEnumerable<HTThanhToan>> GetAllAsync();
        Task<HTThanhToan> GetByIdAsync(int id);
        Task AddAsync(HTThanhToan HTTToan);
        Task UpdateAsync(HTThanhToan HTTToan);
        Task DeleteAsync(int id);
    }
}
