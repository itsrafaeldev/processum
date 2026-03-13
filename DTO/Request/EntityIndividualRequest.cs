using System.ComponentModel.DataAnnotations;

namespace OctaPro.DTO
{
    public class EntityIndividualRequest
    {
        [Required]
        public long EntityId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [MaxLength(11)]
        [Required]
        public string? Cpf { get; set; }
        
        [MaxLength(20)]
        public string? Rg { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(11)]
        [Required]
        public string? Mobile { get; set; }

        [MaxLength(11)]
        public string? Phone { get; set; }

        [Required]
        public DateOnly? BirthDate { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        
        
    }
}   