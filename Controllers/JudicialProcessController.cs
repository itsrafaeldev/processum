using Microsoft.AspNetCore.Mvc;
using processum.DTO;
using processum.DTO.Response;
using processum.Services.interfaces;

namespace processum.Controllers
{
    [ApiController]
    [Route("api/process")]
    public class JudicialProcessController : ControllerBase
    {
        private readonly IJudicialProcessService _service;

        public JudicialProcessController(IJudicialProcessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JudicialProcessResponse>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{idPublic:guid}")]
        public async Task<ActionResult<JudicialProcessResponse>> GetById(Guid idPublic)
        {
            var process = await _service.GetByIdAsync(idPublic);
            if (process == null)
                return NotFound();

            return Ok(process);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProcess(JudicialProcessRequest request)
        {
            await _service.CreateAsync(request);
            return StatusCode(201);
        }

        [HttpDelete("{idPublic:guid}")]
        public async Task<IActionResult> DeleteEntity(Guid idPublic)
        {
            if (!await _service.DeleteAsync(idPublic))
                return NotFound("Entidade não encontrada.");

            return NoContent();
        }
    }
}
