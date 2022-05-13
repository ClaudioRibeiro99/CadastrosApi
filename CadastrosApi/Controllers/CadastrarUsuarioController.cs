using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastrosApi.Models;

namespace CadastrosApi.Controllers
{
    public class MinhaClasse
    {
        public string message { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class CadastrarUsuarioController : ControllerBase
    {
        private readonly _context _context;

        public CadastrarUsuarioController(_context context)
        {
            _context = context;
        }

        // GET: api/CadastrarUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastrarUsuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/CadastrarUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadastrarUsuario>> GetCadastrarUsuario(int id)
        {
            var cadastrarUsuario = await _context.Usuarios.FindAsync(id);

            if (cadastrarUsuario == null)
            {
                return NotFound();
            }

            return cadastrarUsuario;
        }

        // PUT: api/CadastrarUsuarios/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastrarUsuario(int id, CadastrarUsuario cadastrarUsuario)
        {
            if (id != cadastrarUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadastrarUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastrarUsuarioExists(id))
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

        // POST: api/CadastrarUsuarios
        [HttpPost]
        public async Task<ActionResult<CadastrarUsuario>> PostCadastrarUsuario(CadastrarUsuario cadastrarUsuario)
        {

            if(cadastrarUsuario.Nome == null || cadastrarUsuario.Nome == "")
            {
                return UnprocessableEntity(new MinhaClasse() { message = "O nome é obrigatório!" });
            }
            if (cadastrarUsuario.Email == null)
            {
                return UnprocessableEntity(new MinhaClasse() { message = "O Email é obrigatório!" });
            }
            if (cadastrarUsuario.Password == null)
            {
                return UnprocessableEntity(new MinhaClasse() { message = "A senha é obrigatório!" });
            }
            if (cadastrarUsuario.Password != cadastrarUsuario.ConfirmarPassword)
            {
                return UnprocessableEntity(new MinhaClasse() { message = "As senhas não conferem!" });
            }
            if (cadastrarUsuario.Email == _context.Usuarios.FirstOrDefault().Email)
            {
                return UnprocessableEntity(new MinhaClasse() { message = "Por favor utilize outro email!" });
            }            
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastrarUsuario", new { id = cadastrarUsuario.Id }, cadastrarUsuario);
        }

        // DELETE: api/CadastrarUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastrarUsuario(int id)
        {
            var cadastrarUsuario = await _context.Usuarios.FindAsync(id);
            if (cadastrarUsuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(cadastrarUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastrarUsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
