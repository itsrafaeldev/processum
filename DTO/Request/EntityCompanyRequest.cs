using System.ComponentModel.DataAnnotations;

namespace processum.DTO
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
        
    }
}   