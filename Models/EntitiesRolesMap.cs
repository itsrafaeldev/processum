using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class EntitiesRolesMap
{
    public long Id { get; set; }

    public long EntityId { get; set; }

    public int RoleId { get; set; }

    public DateTime AssignedAt { get; set; }

    public long? AssignedBy { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Entity Entity { get; set; } = null!;

    public virtual EntitiesRole Role { get; set; } = null!;
}
