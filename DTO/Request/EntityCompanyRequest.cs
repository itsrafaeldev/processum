using System.ComponentModel.DataAnnotations;

namespace OctaPro.DTO
{
    public class EntityCompanyRequest
    {
        [Required]
        [MaxLength(14)]
        public string? Cnpj { get; set; }

        [Required]
        [MaxLength(200)]
        public string? CorporateName { get; set; }

        [Required]
        [MaxLength(200)]
        public string? TradeName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string? CorporateEmail { get; set; }
        
        [MaxLength(50)]
        public string? CorporateMobile { get; set; }

        [MaxLength(50)]
        public string? CorporatePhone { get; set; }

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