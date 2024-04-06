using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DOANCUOIKI.Models;
using DOANCUOIKI.Repository;
namespace DOANCUOIKI.Controllers
{
    public class BanController : Controller
    {
        private readonly IBanRepository _banRepository;

        public BanController(IBanRepository banRepository)
        {
            _banRepository = banRepository;
            
        }
        public async Task<IActionResult> SoDo()
        {
            var ban = await _banRepository.GetAllAsync();
            return View(ban);
        }


        public async Task<IActionResult> Index()
        {
            var ban = await _banRepository.GetAllAsync();
            return View(ban);
        }
        public async Task<IActionResult> Add()
        {
            var bans = await _banRepository.GetAllAsync();
            return View();
        }
        // Xử lý thêm sản phẩm mới
        
        [HttpPost]
        public async Task<IActionResult> Add(Ban ban)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện thêm bàn mới vào cơ sở dữ liệu
                await _banRepository.AddAsync(ban);
                return RedirectToAction("Index");
            }
            // Nếu model không hợp lệ, hiển thị lại form thêm bàn với thông báo lỗi
            return View(ban);
        }
        public async Task<IActionResult> Display(int id)
        {
            var ban = await _banRepository.GetByIdAsync(id);
            if (ban == null)
            {
                return NotFound();
            }
            return View(ban);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            
            var ban = await _banRepository.GetByIdAsync(id);
            if (ban == null)
            {
                return NotFound();
            }
            return View(ban);
        }
        // Xử lý cập nhật bàn
        [HttpPost]
        public async Task<IActionResult> Update(int id, Ban ban)
        {
            if (id != ban.SoBan)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var banupdate = await _banRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                // Cập nhật các thông tin khác của sản phẩm
                banupdate.SoBan = ban.SoBan;
                banupdate.SLNguoi = ban.SLNguoi;
                banupdate.status = ban.status;
                await _banRepository.UpdateAsync(banupdate);
                return RedirectToAction(nameof(Index));

            }
            return View(ban);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var ban = await _banRepository.GetByIdAsync(id);
            if (ban == null)
            {
                return NotFound();
            }
            return View(ban);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ban = await _banRepository.GetByIdAsync(id);
            if (ban != null)
            {
                // Xóa bản ghi khỏi cơ sở dữ liệu
                await _banRepository.DeleteAsync(id);
            }

            // Redirect về action Index
            return RedirectToAction(nameof(Index));
        }

    }
}
