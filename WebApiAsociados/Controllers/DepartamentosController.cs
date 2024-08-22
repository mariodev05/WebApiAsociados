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
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamentos>>> Getdepartamentos()
        {
            return await _context.departamentos.ToListAsync();
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamentos>> GetDepartamentos(int id)
        {
            var departamentos = await _context.departamentos.FindAsync(id);

            if (departamentos == null)
            {
                return NotFound();
            }

            return departamentos;
        }

        // PUT: api/Departamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentos(int id, Departamentos departamentos)
        {
            if (id != departamentos.Id)
            {
                return BadRequest();
            }

            _context.Entry(departamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentosExists(id))
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

        // POST: api/Departamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamentos>> PostDepartamentos(Departamentos departamentos)
        {
            _context.departamentos.Add(departamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamentos", new { id = departamentos.Id }, departamentos);
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamentos(int id)
        {
            var departamentos = await _context.departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }

            _context.departamentos.Remove(departamentos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentosExists(int id)
        {
            return _context.departamentos.Any(e => e.Id == id);
        }
    }
}
