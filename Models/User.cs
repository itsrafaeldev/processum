using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OctaPro.Models;

public partial class User : IdentityUser<long>
{
    public string? ProfilePhotoPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid IdPublic { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<JudicialProcessUser> JudicialProcessUsers { get; set; } = new List<JudicialProcessUser>();

    public virtual ICollection<LegalFee> LegalFees { get; set; } = new List<LegalFee>();

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();

}
