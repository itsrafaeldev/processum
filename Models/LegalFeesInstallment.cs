using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class LegalFeesInstallment
{
    public int Id { get; set; }

    public Guid IdPublic { get; set; }

    public int CurrentInstallment { get; set; }

    public int LegalFeeId { get; set; }

    public decimal ValueInstallment { get; set; }

    public int StatusPaymentId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long EntityId { get; set; }

    public virtual Entity Entity { get; set; } = null!;

    public virtual StatusPayment StatusPayment { get; set; } = null!;
}
