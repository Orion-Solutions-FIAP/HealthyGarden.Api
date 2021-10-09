using System.Collections.Generic;
using HealthyGarden.Domain.Entities;

namespace HealthyGarden.Domain.Interfaces
{
    public interface IHistoricRepository : IRepositoryBase<Historic>
    {
        IEnumerable<Historic> GetByGardenId(int gardenId);
    }
}
