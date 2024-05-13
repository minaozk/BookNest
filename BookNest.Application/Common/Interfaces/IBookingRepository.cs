using BookNest.Domain.Entities;

namespace BookNest.Application.Common.Interfaces
{
	public interface IBookingRepository : IRepository<Booking>
	{

		void Update(Booking entity);



	}
}
