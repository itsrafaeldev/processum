using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class JudicialProcessUser
{
    public long Id { get; set; }

    public long JudicialProcessId { get; set; }

    public long UserId { get; set; }

    public string? AccessLevel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual JudicialProcess JudicialProcess { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
