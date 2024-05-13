using BookNest.Application.Common.Interfaces;
using BookNest.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM()
			{
				VillaList = _unitOfWork.Villa.GetAll(IncludeProperties: "VillaAmenity"),
				Nights = 1,
				CheckInDate = DateOnly.FromDateTime(DateTime.Now),
			};
			return View(homeVM);
		}

		[HttpPost]
		public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
		{
			var villaList = _unitOfWork.Villa.GetAll(IncludeProperties: "VillaAmenity").ToList();
			foreach (var villa in villaList)
			{
				if (villa.Id % 2 == 0)
				{
					villa.isAvailable = false;
				}
			}
			HomeVM homeVM = new HomeVM()
			{
				CheckInDate = checkInDate,
				VillaList = villaList,
				Nights = nights

			};

			return PartialView("_VillaList", homeVM);
		}

		public IActionResult Privacy()
		{
			return View();
		}


		public IActionResult Error()
		{
			return View();
		}
	}
}
