using BookNest.Domain.Entities;

namespace BookNest.Application.Common.Interfaces
{
    public interface IVillaRepository : IRepository<Villa>
    {

        void Update(Villa entity);



    }
}
