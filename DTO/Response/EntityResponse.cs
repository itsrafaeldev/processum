using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace processum.DTO.Response
{
    public class EntityResponse
    {
        public Guid IdPublic { get; set; }
        public string Name { get; set; } = null!;
    }
}