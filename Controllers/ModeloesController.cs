using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClothingCollection.Context;
using LabClothingCollection.Models;
using LabClothingCollection.DTOs;

namespace LabClothingCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloesController : ControllerBase
    {
        private readonly PessoaContext _context;

        public ModeloesController(PessoaContext context)
        {
            _context = context;
        }

        // GET: api/Modeloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos()
        {
          if (_context.Modelos == null)
          {
              return NotFound();
          }
            return await _context.Modelos.ToListAsync();
        }

        // GET: api/Modeloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
          if (_context.Modelos == null)
          {
              return NotFound();
          }
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        [HttpPut("/api/modelos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarModelo(int id, [FromBody] ModeloAtualizadoDto modeloDto)
        {
            var modelo = await _context.Modelos.FirstOrDefaultAsync(u => u.IdModelo == id);

            if (modelo == null)
            {
                return NotFound("Modelo não encontrado!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                modelo.NomeModelo = modeloDto.NomeModelo;
                modelo.Tipo = modeloDto.Tipo;
                modelo.Layout = modeloDto.Layout;
                
                await _context.SaveChangesAsync();
                _context.Entry(modelo).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
                {
                    return NotFound("Modelo não encontrado!");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Os dados de modelo foram atualizados com sucesso!");
        }



        [HttpPost("/api/modelos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Modelo>> CadastroModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool modeloCadastrado = await _context.Modelos.AnyAsync(c => c.NomeModelo == modelo.NomeModelo);
            if (modeloCadastrado)
            {
                return Conflict("Nome do modelo já cadastrado!");
            }
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ListarModelos", new { id = modelo.IdModelo }, modelo);
        }


        // DELETE: api/Modeloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            if (_context.Modelos == null)
            {
                return NotFound();
            }
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return (_context.Modelos?.Any(e => e.IdModelo == id)).GetValueOrDefault();
        }
    }
}
