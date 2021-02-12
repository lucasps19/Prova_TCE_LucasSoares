using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJunior_LucasSoares_V2.Mappings;

namespace PJunior_LucasSoares_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudantesController : ControllerBase
    {
        private readonly pjunior_ls_dbContext _context;

        public EstudantesController(pjunior_ls_dbContext context)
        {
            _context = context;
        }

        // GET: api/Estudantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudante(string nome = "")
        {
            if(!string.IsNullOrWhiteSpace(nome)) {
                return await _context.Estudantes.Where(o => o.Nome.Trim().ToUpper().Contains(nome.Trim().ToUpper())).ToListAsync();
            } else
            {
                return await _context.Estudantes.ToListAsync();
            }
        }

        // GET: api/Estudantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudante(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);

            if (estudante == null)
            {
                return NotFound();
            }

            return estudante;
        }

        // PUT: api/Estudantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudante(int id, Estudante estudante)
        {
            if (id != estudante.Matricula)
            {
                return BadRequest();
            }

            _context.Entry(estudante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudanteExists(id))
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

        // POST: api/Estudantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudante", new { id = estudante.Matricula }, estudante);
        }

        // DELETE: api/Estudantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudante(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }

            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.Matricula == id);
        }
    }
}
