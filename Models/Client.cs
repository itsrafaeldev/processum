using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class Client
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long LawyerId { get; set; }

    public long EntityId { get; set; }

    public virtual Entity Entity { get; set; } = null!;

    public virtual User Lawyer { get; set; } = null!;
}
