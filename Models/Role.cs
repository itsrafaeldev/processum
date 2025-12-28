using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Role1 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
