using GigFlow.Domain.Enums;

namespace GigFlow.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public virtual FreelancerProfile? FreelancerProfile { get; set; }
        public virtual ClientProfile? ClientProfile { get; set; }
    }
}
