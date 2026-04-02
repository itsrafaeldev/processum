using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctaPro.DTO.Request
{
    public class SettlementFilterRequest
    {
        public string? ProcessNumber { get; set; }
              
        public string? Status { get; set; }
    }
}