using Microsoft.AspNetCore.Mvc;
using processum.DTO;
using processum.DTO.Response;
using processum.Services.interfaces;

namespace processum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _service;

        public EntityController(IEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetEntities()
        {
            return Ok(await _service.GetEntitiesAsync());
        }

        [HttpGet("{idPublic:guid}")]
        public async Task<ActionResult<EntityResponse>> GetById(Guid idPublic)
        {
            var entity = await _service.GetByIdAsync(idPublic);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost("pf")]
        public async Task<IActionResult> CreatePF(EntityIndividualRequest request)
        {
            await _service.CreateEntityIndividualAsync(request);
            return StatusCode(201);
        }

        [HttpPost("pj")]
        public async Task<IActionResult> CreatePJ(EntityCompanyRequest request)
        {
            await _service.CreateEntityCompanyAsync(request);
            return StatusCode(201);
        }

        [HttpPut("pf/{entityId:guid}")]
        public async Task<IActionResult> UpdatePF(Guid entityId, EntityIndividualRequest request)
        {
            if (!await _service.UpdateEntityIndividualAsync(entityId, request))
                return NotFound();

            return NoContent();
        }

        [HttpPut("pj/{entityId:guid}")]
        public async Task<IActionResult> UpdatePJ(Guid entityId, EntityCompanyRequest request)
        {
            if (!await _service.UpdateEntityCompanyAsync(entityId, request))
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{entityId:guid}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            if (!await _service.DeleteEntityAsync(entityId))
                return NotFound();

            return NoContent();
        }
    }
}
