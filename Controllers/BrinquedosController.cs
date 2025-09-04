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

    // PUT: api/brinquedos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBrinquedo(int id, Brinquedo brinquedo)
    {
        if (id != brinquedo.Id_brinquedo)
        {
            return BadRequest("O ID do brinquedo na URL não corresponde ao ID do objeto.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var brinquedoExistente = await _context.Brinquedos.FindAsync(id);
        if (brinquedoExistente == null)
        {
            return NotFound("Brinquedo não encontrado.");
        }

        _context.Entry(brinquedoExistente).CurrentValues.SetValues(brinquedo);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BrinquedoExists(id))
            {
                return NotFound("Brinquedo não encontrado.");
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/brinquedos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrinquedo(int id)
    {
        var brinquedo = await _context.Brinquedos.FindAsync(id);
        if (brinquedo == null)
        {
            return NotFound("Brinquedo não encontrado.");
        }

        _context.Brinquedos.Remove(brinquedo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Método auxiliar para verificar se o brinquedo existe
    private bool BrinquedoExists(int id)
    {
        return _context.Brinquedos.Any(e => e.Id_brinquedo == id);
    }

}
