using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class EntitiesRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<EntitiesRolesMap> EntitiesRolesMaps { get; set; } = new List<EntitiesRolesMap>();
}
