using HealthyGarden.Domain.Entities;
namespace HealthyGarden.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        int GetNumberOfUsers();
    }
}
