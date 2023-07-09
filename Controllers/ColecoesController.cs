using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClothingCollection.Context;
using LabClothingCollection.Models;
using LabClothingCollection.DTOs;

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

        
        [HttpGet("/api/colecoes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarColecoes([FromQuery] ListarColecoesDto dto)
        {
            IQueryable<Colecao> query = _context.Colecao;

            if (!string.IsNullOrEmpty(dto.status))
            {
                if (dto.status.ToUpper() == "ATIVA")
                {
                    query = query.Where(u => u.Estado == EstadoNoSistema.ATIVA);
                }
                else if (dto.status.ToUpper() == "INATIVA")
                {
                    query = query.Where(u => u.Estado == EstadoNoSistema.INATIVA);
                }
                else
                {
                    return BadRequest("Valor inválido para o parâmetro 'status'. Os valores possíveis são 'ATIVA' ou 'INATIVA'.");
                }
            }

            List<Colecao> colecoes = await query.ToListAsync();

            return Ok(colecoes);
        }


        [HttpPut("/api/colecoes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarColecao(int id, [FromBody] ColecaoAtualizadaDto colecaoDto)
        {
            var colecao = await _context.Colecao.FirstOrDefaultAsync(u => u.IdColecao == id);

            if (colecao == null)
            {
                return NotFound("Coleção não encontrada!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                colecao.NomeColecao = colecaoDto.NomeColecao;
                colecao.Marca = colecaoDto.Marca;
                colecao.Orcamento = colecaoDto.Orcamento;
                colecao.AnoLancamento = colecaoDto.AnoLancamento;
                colecao.Estacao = colecaoDto.Estacao;
                colecao.Estado = colecaoDto.Estado;
                await _context.SaveChangesAsync();
                _context.Entry(colecao).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecaoExists(id))
                {
                    return NotFound("Coleção não encontrada!");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Os dados de coleção foram atualizados com sucesso!");
        }

        [HttpPut("/api/colecoes/{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarEstadoColecao(int id, [FromBody] AtualizacaoEstadoColecaoDto estadoDto)
        {
            var colecao = _context.Colecao.FirstOrDefault(c => c.IdColecao == id);
            if (colecao == null)
            {
                return NotFound("Coleção não encontrada.");
            }

            if (!Enum.IsDefined(typeof(EstadoNoSistema), estadoDto.Estado))
            {
                return BadRequest("Valor inválido para o campo 'status'.");
            }

            colecao.Estado = estadoDto.Estado;

            _context.SaveChanges();

            string statusAtualizado = colecao.Estado == 0 ? "Ativo" : "Inativo";

            return Ok("Os dados de estado no sistema da coleção foram alterados para: " + statusAtualizado);
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
