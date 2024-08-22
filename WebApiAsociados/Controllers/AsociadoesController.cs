using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAsociados.Context;
using WebApiAsociados.Models;

namespace WebApiAsociados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociadoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsociadoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Asociadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asociado>>> Getasociados()
        {
            return await _context.asociados.ToListAsync();
        }

        // GET: api/Asociadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asociado>> GetAsociado(int id)
        {
            var asociado = await _context.asociados.FindAsync(id);

            if (asociado == null)
            {
                return NotFound();
            }

            return asociado;
        }

        // PUT: api/Asociadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsociado(int id, Asociado asociado)
        {
            if (id != asociado.Id)
            {
                return BadRequest();
            }

            _context.Entry(asociado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsociadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Asociadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asociado>> PostAsociado(Asociado asociado)
        {
            _context.asociados.Add(asociado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsociado", new { id = asociado.Id }, asociado);
        }

        // DELETE: api/Asociadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsociado(int id)
        {
            var asociado = await _context.asociados.FindAsync(id);
            if (asociado == null)
            {
                return NotFound();
            }

            _context.asociados.Remove(asociado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsociadoExists(int id)
        {
            return _context.asociados.Any(e => e.Id == id);
        }
    }
}
