using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DOANCUOIKI.Models;
using DOANCUOIKI.Repositories;
using System;
using DOANCUOIKI.ViewModels;

namespace DOANCUOIKI.Controllers
{
    public class MonAnController : Controller
    {
        private readonly IMonAnRepository _monAnRepository;
        private readonly ILoaiThucPhamRepository _loaiThucPhamRepository;

        public MonAnController(IMonAnRepository monAnRepository, ILoaiThucPhamRepository loaiThucPhamRepository)
        {
            _monAnRepository = monAnRepository;
            _loaiThucPhamRepository = loaiThucPhamRepository;
        }

        public async Task<IActionResult> Index()
        {
            var monAns = await _monAnRepository.GetAllAsync();
            return View(monAns);
        }

        public async Task<IActionResult> Order(int Soban)
        {
            OrderViewModel orderViewModel = new OrderViewModel
            {
                ListMonAn = (List<MonAn>)await _monAnRepository.GetAllAsync(),
                SoBan = Soban
            };
            return View(orderViewModel);
        }

        public async Task<IActionResult> Add()
        {
            var loaitps = await _loaiThucPhamRepository.GetAllAsync();
            ViewBag.LoaiThucPhams = new SelectList(loaitps, "MaLoaiTP", "TenLoaiTP");
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(MonAn monan, IFormFile imageUrl)
        {

                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                    monan.ImageUrl = await SaveImage(imageUrl);
                }
                await _monAnRepository.AddAsync(monan);
                return RedirectToAction(nameof(Index));

            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var loaitps = await _loaiThucPhamRepository.GetAllAsync();
            ViewBag.LoaiThucPhams = new SelectList(loaitps, "MaLoaiTP", "TenLoaiTP");
            return View(monan);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }

        public async Task<IActionResult> Display(int id)
        {
            var monAn = await _monAnRepository.GetByIdAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }

        public async Task<IActionResult> Update(int id)
        {
            var monAn = await _monAnRepository.GetByIdAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            var loaiThucPhams = await _loaiThucPhamRepository.GetAllAsync();
            ViewBag.LoaiThucPhams = new SelectList(loaiThucPhams, "MaLoaiTP", "TenLoaiTP", monAn.LoaiThucPhamId);
            return View(monAn);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, MonAn monAn, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl");
            if (id != monAn.MaMon)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingMonAn = await _monAnRepository.GetByIdAsync(id);
                if (imageUrl == null)
                {
                    monAn.ImageUrl = existingMonAn.ImageUrl;
                }
                else
                {
                    monAn.ImageUrl = await SaveImage(imageUrl);
                }
                existingMonAn.TenMon = monAn.TenMon;
                existingMonAn.Gia = monAn.Gia;
                existingMonAn.DVT = monAn.DVT;
                existingMonAn.LoaiThucPhamId = monAn.LoaiThucPhamId;
                existingMonAn.ImageUrl = monAn.ImageUrl;
                await _monAnRepository.UpdateAsync(existingMonAn);
                return RedirectToAction(nameof(Index));
            }
            var loaiThucPhams = await _loaiThucPhamRepository.GetAllAsync();
            ViewBag.LoaiThucPhams = new SelectList(loaiThucPhams, "MaLoaiTP", "TenLoaiTP", monAn.LoaiThucPhamId);
            return View(monAn);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var monAn = await _monAnRepository.GetByIdAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _monAnRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
