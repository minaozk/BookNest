using BookNest.Domain.Entities;
using BookNest.Web.ViewModels;

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

        public static RadialBarChartDto GetRadialCartDataModel(int totalCount, double currentMonthCount, double prevMonthCount)
        {
            RadialBarChartDto RadialBarChartDto = new();


            int increaseDecreaseRatio = 100;

            if (prevMonthCount != 0)
            {
                increaseDecreaseRatio = Convert.ToInt32((currentMonthCount - prevMonthCount) / prevMonthCount * 100);
            }

            RadialBarChartDto.TotalCount = totalCount;
            RadialBarChartDto.CountInCurrentMonth = Convert.ToInt32(currentMonthCount);
            RadialBarChartDto.HasRatioIncreased = currentMonthCount > prevMonthCount;
            RadialBarChartDto.Series = new int[] { increaseDecreaseRatio };

            return RadialBarChartDto;
        }
    }
}
