using BookNest.Domain.Entities;

namespace BookNest.Application.Common.Utility
{
	public static class SD
	{
		public const string Role_Customer = "Müşteri";
		public const string Role_Admin = "Admin";

		public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusCheckIn = "StatusCheckIn";
		public const string StatusCompleted = "Completed";
		public const string StatusCancelled = "Cancelled";
		public const string StatusRefunded = "Refunded";


		public static int VillaRoomsAvailable_Count(int villaId, List<VillaNumber> villaNumberList, DateOnly checkInDate, int nights, List<Booking> bookings)
		{
			List<int> bookingInDate = new();
			int finalAvailableRoomForAllNights = int.MaxValue;

			var roomsInVilla = villaNumberList.Where(x => x.VillaId == villaId).Count();

			for (int i = 0; i < nights; i++)
			{
				var villaBooked = bookings.Where(u => u.CheckInDate <= checkInDate.AddDays(i) && u.CheckOutDate >= checkInDate.AddDays(1) && u.VillaId == villaId);

				foreach (var booking in villaBooked)
				{
					if (!bookingInDate.Contains(booking.Id))
					{
						bookingInDate.Add(booking.Id);
					}
				}

				var totalAavailableRooms = roomsInVilla - bookingInDate.Count();
				if (totalAavailableRooms == 0)
				{
					return 0;
				}
				else
				{
					if (finalAvailableRoomForAllNights > totalAavailableRooms)
					{
						finalAvailableRoomForAllNights = totalAavailableRooms;
					}
				}

			}
			return finalAvailableRoomForAllNights;
		}
	}
}
