using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class LegalFee
{
    public long Id { get; set; }

    public decimal Amount { get; set; }

    public int QuantityInstallment { get; set; }

    public long JudicialProcessId { get; set; }

    public int StatusPaymentId { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid IdPublic { get; set; }

    public long UserId { get; set; }

    public virtual JudicialProcess JudicialProcess { get; set; } = null!;

    public virtual StatusPayment StatusPayment { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public ICollection<LegalFeeEntity> LegalFeeEntities { get; set; } = new List<LegalFeeEntity>();

    public LegalFee()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        QuantityInstallment = 1;
        Amount = 0.0m;
    }
}
