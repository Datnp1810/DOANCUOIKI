using DOANCUOIKI.Models;

namespace DOANCUOIKI.Repositories
{
    public interface ILoaiThucPhamRepository
    {
        Task<IEnumerable<LoaiThucPham>> GetAllAsync();
        Task<LoaiThucPham> GetByIdAsync(int id);
        Task AddAsync(LoaiThucPham loaithucpham);
        Task UpdateAsync(LoaiThucPham loaithucPham);
        Task DeleteAsync(int id);
    }
}
