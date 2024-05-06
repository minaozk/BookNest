using BookNest.Application.Common.Interfaces;
using BookNest.Domain.Entities;
using BookNest.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookNest.Web.Controllers
{

	public class AmenityController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public AmenityController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			var amenities = _unitOfWork.Amenity.GetAll(IncludeProperties: "Villa");
			return View(amenities);
		}

		public IActionResult Create()
		{

			AmenityVM amenityVM = new()
			{
				VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				})
			};

			return View(amenityVM);
		}

		[HttpPost]
		public IActionResult Create(AmenityVM obj)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Amenity.Add(obj.Amenity);
				_unitOfWork.Save();
				TempData["success"] = "Villa özellikleri başarıyla oluşturuldu";
				return RedirectToAction("Index", "Amenity");
			}



			obj.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});

			return View(obj);

		}

		public IActionResult Update(int amenityId)
		{
			AmenityVM amenityVM = new()
			{
				VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
			};
			if (amenityVM.Amenity == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(amenityVM);
		}

		[HttpPost]
		public IActionResult Update(AmenityVM amenityVM)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Amenity.Update(amenityVM.Amenity);
				_unitOfWork.Save();
				TempData["success"] = "Villa özellikleri başarıyla güncellendi.";
				return RedirectToAction("Index", "Amenity");
			}



			amenityVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});

			return View(amenityVM);
		}

		public IActionResult Delete(int amenityId)
		{
			AmenityVM amenityVM = new()
			{
				VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
			};
			if (amenityVM.Amenity == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(amenityVM);
		}

		[HttpPost]
		public IActionResult Delete(AmenityVM amenityVM)
		{
			Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == amenityVM.Amenity.Id);

			if (amenityVM is not null)
			{
				_unitOfWork.Amenity.Remove(objFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Villa özellikleri başarıyla silindi.";
				return RedirectToAction("Index", "Amenity");
			}

			TempData["error"] = "Villa özellikleri silinemedi";

			return View(amenityVM);
		}
	}
}
