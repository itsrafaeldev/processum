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

        [StringLength(8)]
        public string? Cep { get; set; }

        public string? HouseNumber { get; set; }
        
        [MaxLength(200)]
        public string? Complement { get; set; }

        [MaxLength(255)]
        public string? City { get; set; }

        [MaxLength(255)]
        public string? District { get; set; }

        [StringLength(2)]
        public string? Uf { get; set; }

        
        
    }
}   