using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class Settlement
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public int QuantityInstallment { get; set; }

    public int CurrentInstallment { get; set; }

    public long JudicialProcessId { get; set; }

    public decimal? ValueInstallment { get; set; }

    public int StatusPaymentId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string Competence { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Note { get; set; }

    public Guid IdPublic { get; set; }

    public long UserId { get; set; }

    public virtual JudicialProcess JudicialProcess { get; set; } = null!;

    public virtual StatusPayment StatusPayment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
