using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using processum.Data;
using processum.DTO;
using processum.DTO.Response;
using processum.Models;

namespace processum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntityController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetEntities()
        {
            var entities = await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .Select(e => new EntityResponse
                {
                    IdPublic = e.IdPublic,
                    EntityType = e.EntityType,

                    Name = e.EntityIndividual.Name,
                    CPF = e.EntityIndividual.Cpf,
                    RG = e.EntityIndividual.Rg,
                    Email = e.EntityIndividual.Email,
                    Mobile =  e.EntityIndividual.Mobile,
                    Phone = e.EntityIndividual.Phone,

                    CorporateName = e.EntityCompany.CorporateName,
                    CNPJ = e.EntityCompany.Cnpj,
                    CorporateEmail = e.EntityCompany.CorporateEmail,
                    CorporateMobile = e.EntityCompany.CorporateMobile,
                    CorporatePhone = e.EntityCompany.CorporatePhone,

                })
                .ToListAsync();
            
            return Ok(entities);
        }

        [HttpGet("{idPublic:guid}")]
        public async Task<ActionResult<EntityResponse>> GetById(Guid idPublic)
        {
            var entity = await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .Where(e => e.IdPublic == idPublic)
                .Select(e => new EntityResponse
                {
                    IdPublic = e.IdPublic,
                    EntityType = e.EntityType,

                    // PF
                    Name   = e.EntityIndividual.Name,
                    CPF    = e.EntityIndividual.Cpf,
                    RG     = e.EntityIndividual.Rg,
                    Email  = e.EntityIndividual.Email,
                    Mobile = e.EntityIndividual.Mobile,
                    Phone  = e.EntityIndividual.Phone,

                    // PJ
                    CorporateName   = e.EntityCompany.CorporateName,
                    CNPJ            = e.EntityCompany.Cnpj,
                    CorporateEmail  = e.EntityCompany.CorporateEmail,
                    CorporateMobile = e.EntityCompany.CorporateMobile,
                    CorporatePhone  = e.EntityCompany.CorporatePhone,
                })
                .FirstOrDefaultAsync();

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost("pf")]
        public async Task<IActionResult> saveEntityIndividual(EntityIndividualRequest request)
        {

            var entity = new Entity
            {
                IdPublic = Guid.NewGuid(),
                EntityType = "PF",
                StatusId = 1
            };

            var entityIndividual = new EntityIndividual
            {
                Entity = entity,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Email = request.Email,
                Mobile = request.Mobile,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                Address = request.Address,
                Name = request.Name
            };
             _context.EntitiesIndividuals.Add(entityIndividual);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpPost("pj")]
        public async Task<IActionResult> saveEntityCompany(EntityCompanyRequest request)
        {

            var entity = new Entity
            {
                IdPublic = Guid.NewGuid(),
                EntityType = "PJ",
                StatusId = 1
            };

            var entityCompany = new EntityCompany
            {
                Entity = entity,
                Cnpj = request.Cnpj,
                CorporateName = request.CorporateName,
                TradeName = request.TradeName,
                CorporateEmail = request.CorporateEmail,
                CorporateMobile = request.CorporateMobile,
                CorporatePhone = request.CorporatePhone
            };
             _context.EntitiesCompanies.Add(entityCompany);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpPut("pf/{entityId:guid}")]
        public async Task<IActionResult> UpdateEntityIndividual(
            Guid entityId,
            EntityIndividualRequest request)
        {
            var entityIndividual = await _context.EntitiesIndividuals
                .Include(e => e.Entity)
                .FirstOrDefaultAsync(e => e.Entity.IdPublic == entityId);

            if (entityIndividual == null)
                return NotFound("Pessoa física não encontrada.");

            // Atualiza dados da PF
            entityIndividual.Cpf = request.Cpf;
            entityIndividual.Rg = request.Rg;
            entityIndividual.Email = request.Email;
            entityIndividual.Mobile = request.Mobile;
            entityIndividual.Phone = request.Phone;
            entityIndividual.BirthDate = request.BirthDate;
            entityIndividual.Address = request.Address;
            entityIndividual.Name = request.Name;

            // Atualiza dados comuns
            entityIndividual.Entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpPut("pj/{entityId:guid}")]
        public async Task<IActionResult> UpdateEntityCompany(
            Guid entityId,
            EntityCompanyRequest request)
        {
            var entityCompany = await _context.EntitiesCompanies
                .Include(e => e.Entity)
                .FirstOrDefaultAsync(e => e.Entity.IdPublic == entityId);

            if (entityCompany == null)
                return NotFound("Pessoa jurídica não encontrada!");
            
            if (entityCompany.Entity.EntityType != "PJ")
                return BadRequest("A entidade informada não é uma pessoa jurídica!");

            // Atualiza dados da PJ
            entityCompany.Cnpj = request.Cnpj;
            entityCompany.CorporateName = request.CorporateName;
            entityCompany.TradeName = request.TradeName;
            entityCompany.CorporateEmail = request.CorporateEmail;
            entityCompany.CorporateMobile = request.CorporateMobile;
            entityCompany.CorporatePhone = request.CorporatePhone;

            // Atualiza dados comuns
            entityCompany.Entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpDelete("{entityId:guid}")]
        public async Task<IActionResult> DeleteEntity(Guid entityId)
        {
            var entity = await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .FirstOrDefaultAsync(e => e.IdPublic == entityId);

            if (entity == null)
                return NotFound("Entidade não encontrada.");

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        









    }
}