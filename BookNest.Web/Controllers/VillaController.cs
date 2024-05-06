using BookNest.Application.Common.Interfaces;
using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Web.Controllers
{

	public class VillaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			var villas = _unitOfWork.Villa.GetAll();
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
				if (obj.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
					string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");
					using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
						obj.Image.CopyTo(fileStream);

					obj.ImageUrl = @"\images\VillaImage\" + fileName;

				}
				else
				{
					obj.ImageUrl = "https://placehold.co/600x400";
				}
				_unitOfWork.Villa.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Villa başarıyla oluşturuldu";
				return RedirectToAction("Index", "Villa");
			}
			TempData["error"] = "Villa oluşturulamadı";
			return View(obj);

		}

		public IActionResult Update(int villaId)
		{
			Villa? obj = _unitOfWork.Villa.Get(x => x.Id == villaId);

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
				if (obj.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
					string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

					if (!string.IsNullOrEmpty(obj.ImageUrl))
					{
						var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}
					using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
						obj.Image.CopyTo(fileStream);

					obj.ImageUrl = @"\images\VillaImage\" + fileName;

				}

				_unitOfWork.Villa.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Villa başarıyla güncellendi";
				return RedirectToAction("Index");
			}
			TempData["error"] = "Villa güncellenemedi";
			return View();
		}

		public IActionResult Delete(int villaId)
		{
			Villa? obj = _unitOfWork.Villa.Get(x => x.Id == villaId);

			if (obj is null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(obj);
		}

		[HttpPost]
		public IActionResult Delete(Villa obj)
		{
			Villa? objFromDb = _unitOfWork.Villa.Get(u => u.Id == obj.Id);
			if (objFromDb is not null)
			{
				if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
				{
					var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));
					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}
				}

				_unitOfWork.Villa.Remove(objFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Villa başarıyla silindi.";
				return RedirectToAction("Index");
			}
			TempData["error"] = "Villa silinemedi.";
			return View();
		}
	}
}
