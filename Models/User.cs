using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public string? ProfilePhotoPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? TwoFactorSecret { get; set; }

    public string? TwoFactorRecoveryCodes { get; set; }

    public DateTime? TwoFactorConfirmedAt { get; set; }

    public Guid IdPublic { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<JudicialProcessUser> JudicialProcessUsers { get; set; } = new List<JudicialProcessUser>();

    public virtual ICollection<JudicialProcess> JudicialProcesses { get; set; } = new List<JudicialProcess>();

    public virtual ICollection<LegalFee> LegalFees { get; set; } = new List<LegalFee>();

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
