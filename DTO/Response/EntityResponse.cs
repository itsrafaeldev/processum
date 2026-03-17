using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OctaPro.DTO.Response
{
    public class EntityResponse
    {
        public Guid IdPublic { get; set; }
        public string EntityType { get; set; } = null!;

         // PF
        
        
        public string? CPF { get; set; }

        
        public string? RG { get; set; }
        
        
        public string? Email { get; set; }
        
        public string? Mobile { get; set; }

        
        public string? Phone { get; set; }

        
        public DateOnly? BirthDate { get; set; }

        // PJ
        
        public string? CNPJ { get; set; }
        public string? TradeName { get; set; }


        // COMMON
        public string? Name { get; set; }

        public string? Address { get; set; }

        
        public string? Cep { get; set; }

        
        public string? HouseNumber { get; set; }

        
        public string? Complement { get; set; }

        
        public string? City { get; set; }

        
        public string? District { get; set; }

        
        public string? Uf { get; set; }
    }
}