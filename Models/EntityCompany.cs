using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class EntityCompany
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public string? Cnpj { get; set; }

    public string? CorporateName { get; set; }

    public string? TradeName { get; set; }

    public string? CorporateEmail { get; set; }

    public string? CorporateMobile { get; set; }

    public string? CorporatePhone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Entity Entity { get; set; } = null!;
}
