using LojaBrinquedos.Data;
using LojaBrinquedos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaBrinquedos.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrinquedosController : ControllerBase
{
    private readonly AppDbContext _context;

    public BrinquedosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/brinquedos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brinquedo>>> GetBrinquedos()
    {
        var brinquedos = await _context.Brinquedos.ToListAsync();
        return Ok(brinquedos);
    }

    // GET: api/brinquedos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Brinquedo>> GetBrinquedo(int id)
    {
        var brinquedo = await _context.Brinquedos.FindAsync(id);

        if (brinquedo == null)
        {
            return NotFound("Brinquedo não encontrado.");
        }

        return Ok(brinquedo);
    }

    // POST: api/brinquedos
    [HttpPost]
    public async Task<ActionResult<Brinquedo>> PostBrinquedo(Brinquedo brinquedo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Brinquedos.Add(brinquedo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBrinquedo), new { id = brinquedo.Id_brinquedo }, brinquedo);
    }
}
