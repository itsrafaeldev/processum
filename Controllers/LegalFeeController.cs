using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using processum.Data;
using processum.DTO.Response;
using processum.DTO.Request;
using processum.Models;

namespace processum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegalFeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LegalFeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalFeeResponse>>> GetLegalFees()
        {
            var legalFees = await _context.LegalFees
                .Select(lf => new LegalFeeResponse
                {
                    IdPublic = lf.IdPublic,
                    UserId = lf.UserId,
                    Amount = lf.Amount,
                    QuantityInstallment = lf.QuantityInstallment,
                    JudicialProcessId = lf.JudicialProcessId,
                    StatusPaymentId = lf.StatusPaymentId,
                    Note = lf.Note,
                    Entities = lf.LegalFeeEntities
                        .Select(lfe => new EntityResponse
                        {
                            IdPublic = lfe.Entity.IdPublic,
                            EntityType = lfe.Entity.EntityType,
                            Name = lfe.Entity.EntityIndividual != null ? lfe.Entity.EntityIndividual.Name : null,
                            CorporateName = lfe.Entity.EntityCompany != null ? lfe.Entity.EntityCompany.CorporateName : null
                        })
                        .ToList(),
                    CreatedAt = lf.CreatedAt,
                    UpdatedAt = lf.UpdatedAt
                })
                .ToListAsync();
            
            return Ok(legalFees);
        }

        [HttpGet("{idPublic:guid}")]
        public async Task<ActionResult<LegalFeeResponse>> GetLegalFeeById(Guid idPublic)
        {
            var entity = await _context.LegalFees
                .Where(e => e.IdPublic == idPublic)
                .Select(lf => new LegalFeeResponse
                {
                    IdPublic = lf.IdPublic,
                    UserId = lf.UserId,
                    Amount = lf.Amount,
                    QuantityInstallment = lf.QuantityInstallment,
                    JudicialProcessId = lf.JudicialProcessId,
                    StatusPaymentId = lf.StatusPaymentId,
                    Note = lf.Note,
                    Entities = lf.LegalFeeEntities
                        .Select(lfe => new EntityResponse
                        {
                            IdPublic = lfe.Entity.IdPublic,
                            EntityType = lfe.Entity.EntityType,
                            Name = lfe.Entity.EntityIndividual != null ? lfe.Entity.EntityIndividual.Name : null,
                            CorporateName = lfe.Entity.EntityCompany != null ? lfe.Entity.EntityCompany.CorporateName : null
                        })
                        .ToList(),
                    CreatedAt = lf.CreatedAt,
                    UpdatedAt = lf.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> saveLegalFee(LegalFeeRequest request)
        {

            var process = await _context.JudicialProcesses
            .Include(p => p.JudicialProcessEntities)
            .Where(e => e.ProcessNumber.Contains(request.ProcessNumber))
            .FirstOrDefaultAsync();

            if (process == null)
                throw new Exception("Processo judicial não encontrado.");

            if (process.IsArchived)
            {
                return BadRequest("Não é possível lançar honorários em um processo encerrado.");
            }

            var clientes = process.JudicialProcessEntities;
            

            var legalFee = new LegalFee
            {
                IdPublic = Guid.NewGuid(),
                JudicialProcess = process,
                StatusPaymentId = request.StatusPaymentId,
                Note = request.Note,
                UserId = 1,
                LegalFeeEntities = clientes.Select(c => new LegalFeeEntity
                {
                    EntityId = c.EntityId
                }).ToList()         
            };

            _context.LegalFees.Add(legalFee);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }


        [HttpPut("{legalFeeId:guid}")]
        public async Task<IActionResult> UpdateLegalFee(
            Guid legalFeeId,
            LegalFeeRequest request)
        {
            var legalFee = await _context.LegalFees
                .FirstOrDefaultAsync(e => e.IdPublic == legalFeeId);

            if (legalFee == null)
                return NotFound("Registro de honorário não encontrado.");

            legalFee.Note = request.Note;
            legalFee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpDelete("{legalFeeId:guid}")]
        public async Task<IActionResult> DeleteEntity(Guid legalFeeId)
        {
            var legalFee = await _context.LegalFees
                .FirstOrDefaultAsync(e => e.IdPublic == legalFeeId);

            if (legalFee == null)
                return NotFound("Entidade não encontrada.");

            _context.LegalFees.Remove(legalFee);
            await _context.SaveChangesAsync();

            return NoContent();
        }














    }
}