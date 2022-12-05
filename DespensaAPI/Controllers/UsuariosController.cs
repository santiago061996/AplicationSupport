using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentesAPI.Context;
using IncidentesAPI.Models;
using AutoMapper;

namespace IncidentesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public UsuariosController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<List<UsuariosDto>> GetUsuarios()
        {
            var usuarios =  await _context.Usuarios.ToListAsync();
            return _mapper.Map<List<UsuariosDto>>(usuarios);
        }

        //// GET: api/Usuarios/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuario(int id)
        //{
        //    var usuario = await _context.Usuarios.FindAsync(id);

        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuario;
        //}

        //// PUT: api/Usuarios/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        //{
        //    if (id != usuario.UsuariosId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(usuario).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Usuarios
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        //{
        //    _context.Usuarios.Add(usuario);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUsuario", new { id = usuario.UsuariosId }, usuario);
        //}

        //// DELETE: api/Usuarios/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUsuario(int id)
        //{
        //    var usuario = await _context.Usuarios.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Usuarios.Remove(usuario);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UsuarioExists(int id)
        //{
        //    return _context.Usuarios.Any(e => e.UsuariosId == id);
        //}
    }
}
