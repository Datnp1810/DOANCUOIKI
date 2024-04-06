using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public interface IHoaDonRepository
    {
        Task<IEnumerable<HoaDon>> GetAllAsync();
        Task<HoaDon> GetByIdAsync(int id);
        Task AddAsync(HoaDon hoadon);
        Task UpdateAsync(HoaDon hoadon);
        Task DeleteAsync(int id);
    }
}
