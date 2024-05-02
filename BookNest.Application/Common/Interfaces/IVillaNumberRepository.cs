using BookNest.Domain.Entities;

namespace BookNest.Application.Common.Interfaces
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {

        void Update(VillaNumber entity);



    }
}
