using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctaPro.Models;

public partial class EntityIndividual
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public string? Name { get; set; }

    public string? Cpf { get; set; }

    public string? Rg { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

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
