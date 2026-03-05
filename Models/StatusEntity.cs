using System;
using System.Collections.Generic;

namespace OctaPro.Models;

public partial class StatusEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
