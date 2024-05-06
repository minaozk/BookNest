using BookNest.Application.Common.Interfaces;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Data;

namespace BookNest.Infrastructure.Repository
{
	public class AmenityRepository : Repository<Amenity>, IAmenityRepository
	{
		private readonly ApplicationDbContext _db;
		public AmenityRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}



		public void Update(Amenity entity)
		{
			_db.Amenities.Update(entity);
		}
	}
}
