﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabClothingCollection.Context;
using LabClothingCollection.Models;
using LabClothingCollection.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LabClothingCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PessoaContext _context;

        public UsuariosController(PessoaContext context)
        {
            _context = context;
        }

        
        [HttpGet("/api/usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarUsuarios([FromQuery] ListarUsuariosDto dto)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            if (!string.IsNullOrEmpty(dto.Status))
            {
                if (dto.Status.ToUpper() == "ATIVO")
                {
                    query = query.Where(u => u.Status == StatusUsuario.Ativo);
                }
                else if (dto.Status.ToUpper() == "INATIVO")
                {
                    query = query.Where(u => u.Status == StatusUsuario.Inativo);
                }
                else
                {
                    return BadRequest("Valor inválido para o parâmetro 'status'. Os valores possíveis são 'ATIVO' ou 'INATIVO'.");
                }
            }

            List<Usuario> usuarios = await query.ToListAsync();

            return Ok(usuarios);
        }


        [HttpGet("/api/usuario/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true) ;

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            return Ok(usuario);
        }

       
        
        [HttpPut("/api/usuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarUsuario(int id,[FromBody] UsuarioAtualizadoDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuario.Nome = usuarioDto.Nome;
                usuario.Genero = usuarioDto.Genero;
                usuario.DataNascimento = usuarioDto.DataNascimento;
                usuario.Telefone = usuarioDto.Telefone;
                usuario.Tipo = usuarioDto.Tipo;
                await _context.SaveChangesAsync();
                 _context.Entry(usuario).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("Usuário não encontrado!");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Os dados foram atualizados com sucesso!");
        }

        
        [HttpPut("/api/usuario/{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarStatusUsuario(int id, [FromBody] AtualizacaoStatusDto atualizacaoStatusDto)
        {
          
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                        
            usuario.Status = (StatusUsuario)Enum.Parse(typeof(StatusUsuario), atualizacaoStatusDto.Status);

            try
            {
                await _context.SaveChangesAsync();
                _context.Entry(usuario).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Id))
                {
                    return NotFound("Usuário não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Os dados de status de usuário foram atualizados!");
        }

        

        [HttpPost("/api/usuarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status409Conflict)] 
        public async Task<ActionResult<Usuario>> CriarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool cpfCadastrado = await _context.Usuarios.AnyAsync(u => u.CpfCnpj == usuario.CpfCnpj);
            if (cpfCadastrado)
            {
                return Conflict("CPF ou CNPJ já cadastrado.");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);

        }

       
        [HttpDelete("/api/usuario/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
           
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    
}
