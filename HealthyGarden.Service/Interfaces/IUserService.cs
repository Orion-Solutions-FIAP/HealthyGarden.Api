using HealthyGarden.Domain.Entities;
using HealthyGarden.Infrastructure.Enum;

namespace HealthyGarden.Service.Interfaces
{
    public interface IUserService
    {
        AuthStatus ValidateUser(User user);
    }
}
