using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Enum;
using HealthyGarden.Service.Interfaces;

namespace HealthyGarden.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthStatus ValidateUser(User currentUser)
        {
            var user = _userRepository.GetByEmail(currentUser.Email);
            if (user == null)
                return AuthStatus.UserNotFound;

            if (user.Password != currentUser.Password)
                return AuthStatus.WrongPassword;
            
            return AuthStatus.Authorized;
        }
    }
}
