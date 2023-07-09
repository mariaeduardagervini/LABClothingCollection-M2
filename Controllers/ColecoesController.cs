using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClothingCollection.Context;
using LabClothingCollection.Models;

namespace LabClothingCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColecoesController : ControllerBase
    {
        private readonly PessoaContext _context;

        public ColecoesController(PessoaContext context)
        {
            _context = context;
        }

        // GET: api/Colecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecao>>> ListarColecoes()
        {
          if (_context.Colecao == null)
          {
              return NotFound();
          }
            return await _context.Colecao.ToListAsync();
        }

        // GET: api/Colecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colecao>> GetColecao(int id)
        {
          if (_context.Colecao == null)
          {
              return NotFound();
          }
            var colecao = await _context.Colecao.FindAsync(id);

            if (colecao == null)
            {
                return NotFound();
            }

            return colecao;
        }

        // PUT: api/Colecoes/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecao(int id, Colecao colecao)
        {
            if (id != colecao.IdColecao)
            {
                return BadRequest();
            }

            _context.Entry(colecao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecaoExists(id))
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

                
        [HttpPost("/api/colecoes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Colecao>> CadatroColecao(Colecao colecao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool colecaoCadastrada = await _context.Colecao.AnyAsync(c => c.NomeColecao == colecao.NomeColecao);
            if (colecaoCadastrada)
            {
                return Conflict("Nome da coleção já cadastrada!");
            }
            _context.Colecao.Add(colecao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ListarColecoes", new { id = colecao.IdColecao }, colecao);
        }

        // DELETE: api/Colecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecao(int id)
        {
            if (_context.Colecao == null)
            {
                return NotFound();
            }
            var colecao = await _context.Colecao.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }

            _context.Colecao.Remove(colecao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColecaoExists(int id)
        {
            return (_context.Colecao?.Any(e => e.IdColecao == id)).GetValueOrDefault();
        }
    }
}
