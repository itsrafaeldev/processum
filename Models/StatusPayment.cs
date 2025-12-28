using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class StatusPayment
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<LegalFee> LegalFees { get; set; } = new List<LegalFee>();

    public virtual ICollection<LegalFeesInstallment> LegalFeesInstallments { get; set; } = new List<LegalFeesInstallment>();

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();
}
