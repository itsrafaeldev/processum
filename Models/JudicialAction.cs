using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class JudicialAction
{
    public int Id { get; set; }

    public string Action { get; set; } = null!;

    public int NatureActionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual NatureAction NatureAction { get; set; } = null!;
}
