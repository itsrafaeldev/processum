using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class JudicialProcessEntity
{
    public long JudicialProcessId { get; set; }
    public JudicialProcess JudicialProcess { get; set; } = null!;

    public long EntityId { get; set; }
    public Entity Entity { get; set; } = null!;

    public JudicialProcessEntity()
    {
        
    }
}
