using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using processum.Data;

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
        public async Task<ActionResult<IEnumerable<string>>> GetEntities()
        {
            var entities = await _context.Entities.ToListAsync();
            return Ok(entities);
        }
    }
}