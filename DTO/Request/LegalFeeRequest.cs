using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace processum.DTO.Request
{
    public class LegalFeeRequest
    {

        public string ProcessNumber { get; set; } = null!;

        // public decimal Amount { get; set; }

        // public int QuantityInstallment { get; set; }

        public int StatusPaymentId { get; set; }

        public string? Note { get; set; }

    }
}