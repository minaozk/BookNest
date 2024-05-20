using BookNest.Application.Services.Interface;
using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Web.Controllers
{
    [Authorize]
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            var villas = _villaService.GetAllVillas();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("description", "Açıklama, Villa Adı ile aynı olamaz.");
            }
            if (ModelState.IsValid)
            {
                _villaService.CreateVilla(obj);

                TempData["success"] = "Villa başarıyla oluşturuldu";
                return RedirectToAction("Index", "Villa");
            }
            TempData["error"] = "Villa oluşturulamadı";
            return View(obj);

        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _villaService.GetVillaById(villaId);

            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _villaService.UpdateVilla(obj);
                TempData["success"] = "Villa başarıyla güncellendi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Villa güncellenemedi";
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaService.GetVillaById(villaId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            bool deleted = _villaService.DeleteVilla(obj.Id);
            if (deleted)
            {
                TempData["success"] = "Villa başarıyla silindi.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Villa silinemedi";
            }

            return View();
        }
    }
}
