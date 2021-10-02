﻿using System.ComponentModel.DataAnnotations;

namespace HealthyGarden.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
