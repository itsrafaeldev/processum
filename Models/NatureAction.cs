using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class NatureAction
{
    public int Id { get; set; }

    public string Nature { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<JudicialProcess> JudicialProcesses { get; set; } = new List<JudicialProcess>();

    public virtual ICollection<JudicialAction> JudicialAction { get; set; } = new List<JudicialAction>();
}
