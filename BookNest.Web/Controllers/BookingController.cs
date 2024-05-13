using BookNest.Application.Common.Interfaces;
using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Web.Controllers
{
	public class BookingController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookingController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult FinalizeBooking(int villaId, DateOnly checkInDate, int nights)
		{
			Booking booking = new()
			{
				VillaId = villaId,

				CheckInDate = checkInDate,
				Nights = nights,
				CheckOutDate = checkInDate.AddDays(nights),
			};
            return View(booking);
		}
	}
}
