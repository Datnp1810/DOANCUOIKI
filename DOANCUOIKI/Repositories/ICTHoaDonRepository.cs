using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public interface ICTHoaDonRepository
    {
        Task<IEnumerable<CTHoaDon>> GetAllAsync();
        Task<CTHoaDon> GetByIdAsync(int id);
        Task AddAsync(CTHoaDon ct_hoadon);
        Task UpdateAsync(CTHoaDon ct_HoaDon);
        Task DeleteAsync(int id);
    }
}
