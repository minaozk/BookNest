using BookNest.Application.Common.Interfaces;
using BookNest.Application.Common.Utility;
using BookNest.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Web.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		static int previousMonth = DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1;
		readonly DateTime previousMonthStartDate = new(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
		readonly DateTime currentMonthStartDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);

		public DashboardController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{

			return View();
		}

		public async Task<IActionResult> GetTotalBookingRadialChartData()
		{
			var totalBookings = _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusPending);
			var countCurrentMonth = totalBookings.Count(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now);

			var countPreviousMonth = totalBookings.Count(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now);

			RadialBarChartVM radialBarChartVM = new RadialBarChartVM();

			int increaseDecreaseRatio = 100;
			if (countPreviousMonth != 0)
			{
				increaseDecreaseRatio = Convert.ToInt32((countCurrentMonth - countPreviousMonth / countPreviousMonth * 100));

			}
			radialBarChartVM.TotalCount = totalBookings.Count();
			radialBarChartVM.CountInCurrentMonth = countCurrentMonth;
			radialBarChartVM.HasRatioIncreased = currentMonthStartDate > previousMonthStartDate;
			radialBarChartVM.Series = new int[] { increaseDecreaseRatio };

			return Json(radialBarChartVM);
		}
	}
}
