using Microsoft.AspNetCore.Mvc;
using DOANCUOIKI.Models;
using DOANCUOIKI.Repositories;

namespace DOANCUOIKI.Controllers
{
    public class LoaiThucPhamController : Controller
    {
        private readonly IMonAnRepository _monantRepository;
        private readonly ILoaiThucPhamRepository _loaiThucPhamRepository;

        public LoaiThucPhamController(IMonAnRepository productRepository, ILoaiThucPhamRepository loaiThucPhamRepository)
        {
            _monantRepository = productRepository;
            _loaiThucPhamRepository = loaiThucPhamRepository;
        }

        public async Task<IActionResult> Index()
        {
            var loaiThucPhams = await _loaiThucPhamRepository.GetAllAsync();
            return View(loaiThucPhams);
        }

        public async Task<IActionResult> Display(int id)
        {
            var loaiThucPham = await _loaiThucPhamRepository.GetByIdAsync(id);
            if (loaiThucPham == null)
            {
                return NotFound();
            }
            return View(loaiThucPham);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(LoaiThucPham loaiThucPham)
        {
            if (ModelState.IsValid)
            {
                await _loaiThucPhamRepository.AddAsync(loaiThucPham);
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThucPham);
        }
        public async Task<IActionResult> Update(int id)
        {
            var loaiThucPham = await _loaiThucPhamRepository.GetByIdAsync(id);
            if (loaiThucPham == null)
            {
                return NotFound();
            }
            return View(loaiThucPham);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, LoaiThucPham loaiThucPham)
        {
            if (id != loaiThucPham.MaLoaiTP)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _loaiThucPhamRepository.UpdateAsync(loaiThucPham);
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThucPham);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var loaiThucPham = await _loaiThucPhamRepository.GetByIdAsync(id);
            if (loaiThucPham == null)
            {
                return NotFound();
            }
            return View(loaiThucPham);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _loaiThucPhamRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

