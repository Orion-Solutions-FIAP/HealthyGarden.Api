using HealthyGarden.Domain.Entities;

namespace HealthyGarden.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Insert(User user);
        User GetById(int id);
        int GetNumberOfUsers();
    }
}
