using DOANCUOIKI.Models;
using DOANCUOIKI.Repositories;
using DOANCUOIKI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DOANCUOIKI.Controllers
{
    public class HTThanhToanController : Controller
    {
        private readonly IHTThanhToanRepository _htttoanRepository;

        public HTThanhToanController(IHTThanhToanRepository htttoanRepository)
        {
            _htttoanRepository = htttoanRepository;

        }


        public async Task<IActionResult> Index()
        {
            var htttoan = await _htttoanRepository.GetAllAsync();
            return View(htttoan);
        }
        public async Task<IActionResult> Add()
        {
            var htttoan = await _htttoanRepository.GetAllAsync();
            return View();
        }
        // Xử lý thêm sản phẩm mới

        [HttpPost]
        public async Task<IActionResult> Add(HTThanhToan httt)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện thêm bàn mới vào cơ sở dữ liệu
                await _htttoanRepository.AddAsync(httt);
                return RedirectToAction("Index");
            }
            // Nếu model không hợp lệ, hiển thị lại form thêm bàn với thông báo lỗi
            return View(httt);
        }
        public async Task<IActionResult> Display(int id)
        {
            var htttoan = await _htttoanRepository.GetByIdAsync(id);
            if (htttoan == null)
            {
                return NotFound();
            }
            return View(htttoan);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var htttoan = await _htttoanRepository.GetByIdAsync(id);
            if (htttoan == null)
            {
                return NotFound();
            }
            return View(htttoan);
        }
        // Xử lý cập nhật bàn
        [HttpPost]
        public async Task<IActionResult> Update(int id, HTThanhToan httt)
        {
            if (id != httt.IdThanhToan)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _htttoanRepository.UpdateAsync(httt);
                return RedirectToAction(nameof(Index));
            }
            return View(httt);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var htttoan = await _htttoanRepository.GetByIdAsync(id);
            if (htttoan == null)
            {
                return NotFound();
            }
            return View(htttoan);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var htttoan = await _htttoanRepository.GetByIdAsync(id);
            if (htttoan != null)
            {
                // Xóa bản ghi khỏi cơ sở dữ liệu
                await _htttoanRepository.DeleteAsync(id);
            }
           
            // Redirect về action Index
            return RedirectToAction(nameof(Index));
        }

    }
}
