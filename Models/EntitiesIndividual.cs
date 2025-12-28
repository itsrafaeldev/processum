using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class EntitiesIndividual
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public string? Cpf { get; set; }

    public string? Rg { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Address { get; set; }

    public string? Name { get; set; }

    public virtual Entity Entity { get; set; } = null!;
}
