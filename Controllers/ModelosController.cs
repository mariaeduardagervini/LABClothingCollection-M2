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
    public class ModelosController : ControllerBase
    {
        private readonly PessoaContext _context;

        public ModelosController(PessoaContext context)
        {
            _context = context;
        }

        
        [HttpGet("/api/modelos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarModelos([FromQuery] ListarModelosDto dto)
        {
           
            IQueryable<Modelo> query = _context.Modelos;

            if (!string.IsNullOrEmpty(dto.layout))
            {
                string layoutUpperCase = dto.layout.ToUpper();
                if (layoutUpperCase == "BORDADO")
                {
                    query = query.Where(m => m.Layout == LayoutModelo.BORDADO);
                }
                else if (layoutUpperCase == "ESTAMPA")
                {
                    query = query.Where(m => m.Layout == LayoutModelo.ESTAMPA);
                }
                else if (layoutUpperCase == "LISO")
                {
                    query = query.Where(m => m.Layout == LayoutModelo.LISO);
                }
                else
                {
                    return BadRequest("Valor inválido para o parâmetro 'layout'. Os valores possíveis são 'BORDADO', 'ESTAMPA' ou 'LISO'.");
                }
            }
            List<Modelo> modelos = await query.ToListAsync();

            return Ok(modelos);
        }

        [HttpGet("/api/modelos/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Modelo>> ListarModelo(int id)
        {

            var modelo = await _context.Modelos.FirstOrDefaultAsync(x => x.IdModelo == id).ConfigureAwait(true);

            if (modelo == null)
            {
                return NotFound("Modelo não encontrado!");
            }

            return Ok(modelo);
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
        public async Task<ActionResult<Modelo>> CadastroModelo([FromBody] Modelo modelo)
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


        [HttpDelete("/api/modelos/{id}")]
        public async Task<IActionResult> DeletarModelo(int id)
        {

            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound("Modelo não encontrado!");
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
