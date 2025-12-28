using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using processum.Data;
using processum.DTO;
using processum.DTO.Response;
using processum.Models;

namespace processum.Controllers
{
    [ApiController]
    [Route("api/process")]
    public class JudicialProcessController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public JudicialProcessController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JudicialProcessResponse>>> GetAll()
        {
            var processes = await _context.JudicialProcesses
                .Include(p => p.NatureAction)
                .Include(p => p.JudicialAction)
                .Include(p => p.User)
                .Include(p => p.JudicialProcessEntities)
                    .ThenInclude(jpe => jpe.Entity)
                .ToListAsync();

            var response = processes.Select(p => new JudicialProcessResponse
            {
                IdPublic = p.IdPublic,
                ProcessNumber = p.ProcessNumber,
                InitialDate = p.InitialDate,
                Respondent = p.Respondent,
                Description = p.Description,
                IsArchived = p.IsArchived,
                CreatedAt = p.CreatedAt,

                NatureAction = new SelectOptionResponse
                                {
                                    Id = p.NatureAction.Id,
                                    Text = p.NatureAction.Nature 
                                },

                JudicialAction = new SelectOptionResponse
                                {
                                    Id = p.JudicialAction.Id,
                                    Text = p.JudicialAction.Action 
                                },                                     
                User = p.User.Id,              

                Entities = p.JudicialProcessEntities
                    .Select(jpe => new EntityResponse
                    {
                        IdPublic = jpe.Entity.IdPublic,
                        Name = jpe.Entity.EntityType 
                    })
                    .ToList()
            }).ToList();
            return Ok(response);
        }

        [HttpGet("{idPublic:guid}")]
        public async Task<ActionResult<JudicialProcessResponse>> GetById(Guid idPublic)
        {
            var process = await _context.JudicialProcesses
                .Include(p => p.NatureAction)
                .Include(p => p.JudicialAction)
                .Include(p => p.User)
                .Include(p => p.JudicialProcessEntities)
                    .ThenInclude(jpe => jpe.Entity)
                .FirstOrDefaultAsync(p => p.IdPublic == idPublic);

            if (process == null)
                return NotFound();

            var response = new JudicialProcessResponse
            {
                IdPublic = process.IdPublic,
                ProcessNumber = process.ProcessNumber,
                InitialDate = process.InitialDate,
                Respondent = process.Respondent,
                Description = process.Description,
                IsArchived = process.IsArchived,
                CreatedAt = process.CreatedAt,

                NatureAction = new SelectOptionResponse
                {
                    Id = process.NatureAction.Id,
                    Text = process.NatureAction.Nature
                },

                JudicialAction = new SelectOptionResponse
                {
                    Id = process.JudicialAction.Id,
                    Text = process.JudicialAction.Action
                },

                User = process.User.Id,

                Entities = process.JudicialProcessEntities
                    .Select(jpe => new EntityResponse
                    {
                        IdPublic = jpe.Entity.IdPublic,
                        Name = jpe.Entity.EntityType
                    })
                    .ToList()
            };

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> saveProcess(JudicialProcessRequest request)
        {

            var entities = await _context.Entities
            .Where(e => request.EntityIds.Contains(e.IdPublic))
            .ToListAsync();

            
            if (entities.Count != request.EntityIds.Count)
                throw new Exception("Uma ou mais entidades não foram encontradas");

            var process = new JudicialProcess
            {
                ProcessNumber = request.ProcessNumber,
                InitialDate = request.InitialDate,
                Respondent = request.Respondent,
                Description = request.Description,
                NatureActionId = request.NatureActionId,
                JudicialActionId = request.JudicialActionId,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IdPublic = Guid.NewGuid(),
                
            };

              foreach (var entity in entities)
            {
                process.JudicialProcessEntities.Add(new JudicialProcessEntity
                {
                    Entity = entity
                });
            }

            _context.JudicialProcesses.Add(process);

            await _context.SaveChangesAsync();
      

            return StatusCode(201);
        }




    }
}