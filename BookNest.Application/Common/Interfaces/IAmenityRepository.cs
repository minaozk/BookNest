using BookNest.Domain.Entities;

namespace BookNest.Application.Common.Interfaces
{
	public interface IAmenityRepository : IRepository<Amenity>
	{

		void Update(Amenity entity);



	}
}
