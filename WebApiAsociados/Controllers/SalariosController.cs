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
    public class SalariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Salarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salarios>>> Getsalarios()
        {
            return await _context.salarios.ToListAsync();
        }

        // GET: api/Salarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarios>> GetSalarios(int id)
        {
            var salarios = await _context.salarios.FindAsync(id);

            if (salarios == null)
            {
                return NotFound();
            }

            return salarios;
        }

        // PUT: api/Salarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalarios(int id, Salarios salarios)
        {
            if (id != salarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(salarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalariosExists(id))
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

        // POST: api/Salarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salarios>> PostSalarios(Salarios salarios)
        {
            _context.salarios.Add(salarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalarios", new { id = salarios.Id }, salarios);
        }

        // DELETE: api/Salarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarios(int id)
        {
            var salarios = await _context.salarios.FindAsync(id);
            if (salarios == null)
            {
                return NotFound();
            }

            _context.salarios.Remove(salarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalariosExists(int id)
        {
            return _context.salarios.Any(e => e.Id == id);
        }
    }
}
