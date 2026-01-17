using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace processum.DTO.Response
{
    public class LegalFeeResponse
    {
        public Guid IdPublic { get; set; }

        public long UserId { get; set; }

        public decimal Amount { get; set; }

        public int QuantityInstallment { get; set; }

        public long JudicialProcessId { get; set; }

        public int StatusPaymentId { get; set; }

        public string? Note { get; set; }

        public List<EntityResponse> Entities { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}