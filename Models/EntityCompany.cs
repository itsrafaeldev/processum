using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctaPro.Models;

[Table("entities_company")]
public partial class EntityCompany
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public string? Cnpj { get; set; }
    [Column("corporate_name")]
    public string? CorporateName { get; set; }

    public string? TradeName { get; set; }

    [Column("email")]
    public string? CorporateEmail { get; set; }

    [Column("mobile")]
    public string? CorporateMobile { get; set; }

    [Column("phone")]
    public string? CorporatePhone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Entity Entity { get; set; } = null!;
    [Column("address")]
    public string? Address { get; set; }

    [StringLength(8)]
    [Column("cep")]
    public string? Cep { get; set; }
    [Column("house_number")]
    public string? HouseNumber { get; set; }
    [StringLength(200)]
    [Column("complement")]
    public string? Complement { get; set; }
    [Column("city")]
    public string? City { get; set; }
    [Column("district")]
    public string? District { get; set; }
    
    [StringLength(2)]
    [Column("uf")]

    public string? Uf { get; set; }
}
