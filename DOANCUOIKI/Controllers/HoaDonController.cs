using DOANCUOIKI.Models;
using DOANCUOIKI.Repositories;
using DOANCUOIKI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DOANCUOIKI.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonRepository _hoadonRepository;

        public HoaDonController(IHoaDonRepository hoadonRepository)
        {
            _hoadonRepository = hoadonRepository;

        }

        public async Task<IActionResult> Index()
        {
            var hoadon = await _hoadonRepository.GetAllAsync();
            return View(hoadon);
        }
        public async Task<IActionResult> Add()
        {
            var hoadon = await _hoadonRepository.GetAllAsync();
            return View();
        }
        // Xử lý thêm sản phẩm mới

        [HttpPost]
        public async Task<IActionResult> Add(HoaDon hoadon)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện thêm bàn mới vào cơ sở dữ liệu
                await _hoadonRepository.AddAsync(hoadon);
                return RedirectToAction("Index");
            }
            // Nếu model không hợp lệ, hiển thị lại form thêm bàn với thông báo lỗi
            return View(hoadon);
        }
        public async Task<IActionResult> Display(int id)
        {
            var hoadon = await _hoadonRepository.GetByIdAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var hoadon = await _hoadonRepository.GetByIdAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }
        // Xử lý cập nhật bàn
        [HttpPost]
        public async Task<IActionResult> Update(int id, HoaDon hoadon)
        {
            if (id != hoadon.MaHD)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _hoadonRepository.UpdateAsync(hoadon);
                return RedirectToAction(nameof(Index));
            }
            return View(hoadon);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var hoadon = await _hoadonRepository.GetByIdAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _hoadonRepository.GetByIdAsync(id);
            if (hoadon != null)
            {
                // Xóa bản ghi khỏi cơ sở dữ liệu
                await _hoadonRepository.DeleteAsync(id);
            }

            // Redirect về action Index
            return RedirectToAction(nameof(Index));
        }

    }
}
