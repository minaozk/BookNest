using BookNest.Application.Common.Interfaces;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Data;

namespace BookNest.Infrastructure.Repository
{
	public class BookingRepository : Repository<Booking>, IBookingRepository
	{
		private readonly ApplicationDbContext _db;
		public BookingRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}



		public void Update(Booking entity)
		{
			_db.Bookings.Update(entity);
		}
	}
}
