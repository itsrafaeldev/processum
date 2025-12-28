using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class EntitiesCompany
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public string? Cnpj { get; set; }

    public string? Ie { get; set; }

    public string? CorporateName { get; set; }

    public string? TradeName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Entity Entity { get; set; } = null!;
}
