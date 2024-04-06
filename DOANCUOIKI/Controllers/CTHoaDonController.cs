using DOANCUOIKI.Repositories;
using DOANCUOIKI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DOANCUOIKI.Controllers
{
    public class CTHoaDonController : Controller
    {
        private readonly ICTHoaDonRepository _cthoadonRepository;

        public CTHoaDonController(ICTHoaDonRepository cthoadonRepository)
        {
            _cthoadonRepository = cthoadonRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cthoadon = await _cthoadonRepository.GetAllAsync();
            return View(cthoadon);
        }

    }
}
