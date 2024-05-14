using BookNest.Application.Common.Interfaces;
using BookNest.Application.Common.Utility;
using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookNest.Web.Controllers
{
	public class BookingController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookingController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Authorize]
		public IActionResult FinalizeBooking(int villaId, DateOnly checkInDate, int nights)
		{
			var claims = (ClaimsIdentity)User.Identity;
			var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

			ApplicationUser user = _unitOfWork.User.Get(u => u.Id == userId);

			var villa = _unitOfWork.Villa.Get(u => u.Id == villaId); // Villa bilgilerini çekiyoruz
			if (villa == null)
			{
				// Villa bulunamadıysa kullanıcıya bir hata mesajı gösterilebilir
				return View("Error", "Villa not found");
			}

			Booking booking = new Booking
			{
				Villa = villa,
				VillaId = villaId,
				CheckInDate = checkInDate,
				Nights = nights,
				CheckOutDate = checkInDate.AddDays(nights),
				TotalCost = villa.Price * nights, // TotalCost hesaplanıyor
				UserId = userId,
				Phone = user.PhoneNumber,
				Email = user.Email,
				Name = user.Name,
			};

			return View(booking);
		}

		[Authorize]
		[HttpPost]
		public IActionResult FinalizeBooking(Booking booking)
		{
			var villa = _unitOfWork.Villa.Get(u => u.Id == booking.VillaId);
			booking.TotalCost = villa.Price * booking.Nights;

			booking.Status = SD.StatusPending;
			booking.BookingDate = DateTime.Now;

			_unitOfWork.Booking.Add(booking);
			_unitOfWork.Save();
			return RedirectToAction(nameof(BookingConfirmation), new { bookingId = booking.Id });
		}

		public IActionResult BookingConfirmation(int bookingId)
		{
			return View(bookingId);
		}

		#region API Calls
		[HttpGet]
		[Authorize]
		public IActionResult GetAll(string status)
		{
			// objBookings başlangıç değeri olarak boş bir liste atanıyor
			IEnumerable<Booking> objBookings = Enumerable.Empty<Booking>();
			string userId = "";

			if (string.IsNullOrEmpty(status))
			{
				status = "";
			}

			if (!User.IsInRole(SD.Role_Admin))
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

				objBookings = _unitOfWork.Booking.GetAll(u => u.UserId == userId, IncludeProperties: "User,Villa");
			}
			else
			{
				// Admin kullanıcı için tüm rezervasyonlar alınıyor
				objBookings = _unitOfWork.Booking.GetAll(IncludeProperties: "User,Villa");
			}

			return Json(new { data = objBookings });
		}
		#endregion


	}
}

