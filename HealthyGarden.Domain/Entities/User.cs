using HealthyGarden.Domain.Helpers;
using System;

namespace HealthyGarden.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public void GenerateSalt()
        {
            Salt = CryptographyHelper.GenerateSalt();
        }

        public void EncryptPassword()
        {
            Password = CryptographyHelper.EncryptPassword(Password, Salt);
        }
    }
}
