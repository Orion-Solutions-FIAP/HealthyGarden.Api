using HealthyGarden.Domain.Entities;

namespace HealthyGarden.Domain.Interfaces
{
    public interface IGardenRepository : IRepositoryBase<Garden>
    {
        Garden GetByUserId(int userId);
    }
}
