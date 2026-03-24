using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctaPro.DTO.Request
{
    public class ProcessFilterRequest
    {
        public string? ProcessNumber { get; set; }
        
        public Guid? IdPublicEntity { get; set; }
      
        public string? Status { get; set; }

        public DateOnly? InitialDate { get; set; }
    }
}