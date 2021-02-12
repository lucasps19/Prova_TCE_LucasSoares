using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJunior_LucasSoares_V2.Mappings;

namespace PJunior_LucasSoares_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaAlunosController : ControllerBase
    {
        private readonly pjunior_ls_dbContext _context;

        public TurmaAlunosController(pjunior_ls_dbContext context)
        {
            _context = context;
        }

        // GET: api/TurmaAlunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurmaAluno>>> GetTurmaAlunos()
        {
            return await _context.TurmaAlunos.ToListAsync();
        }

        // GET: api/TurmaAlunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaAluno>> GetTurmaAluno(int id)
        {
            var turmaAluno = await _context.TurmaAlunos.FindAsync(id);

            if (turmaAluno == null)
            {
                return NotFound();
            }

            return turmaAluno;
        }

        // PUT: api/TurmaAlunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurmaAluno(int id, TurmaAluno turmaAluno)
        {
            if (id != turmaAluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(turmaAluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaAlunoExists(id))
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

        // POST: api/TurmaAlunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TurmaAluno>> PostTurmaAluno(TurmaAluno turmaAluno)
        {
            _context.TurmaAlunos.Add(turmaAluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurmaAluno", new { id = turmaAluno.Id }, turmaAluno);
        }

        // DELETE: api/TurmaAlunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurmaAluno(int id)
        {
            var turmaAluno = await _context.TurmaAlunos.FindAsync(id);
            if (turmaAluno == null)
            {
                return NotFound();
            }

            _context.TurmaAlunos.Remove(turmaAluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurmaAlunoExists(int id)
        {
            return _context.TurmaAlunos.Any(e => e.Id == id);
        }
    }
}
