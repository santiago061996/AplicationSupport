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
    public class AplicacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public AplicacionesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Aplicaciones
        [HttpGet]
        public async Task<List<AplicacionesDto>> GetAplicaciones()
        {
            var aplicaciones = await _context.Aplicaciones.ToListAsync();
            return _mapper.Map<List<AplicacionesDto>>(aplicaciones);
        }

        //// GET: api/Aplicaciones/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Aplicacion>> GetAplicacion(int id)
        //{
        //    var aplicacion = await _context.Aplicaciones.FindAsync(id);

        //    if (aplicacion == null)
        //    {
        //        return NotFound();
        //    }

        //    return aplicacion;
        //}

        //// PUT: api/Aplicaciones/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAplicacion(int id, Aplicacion aplicacion)
        //{
        //    if (id != aplicacion.AplicacionesId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(aplicacion).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AplicacionExists(id))
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

        //// POST: api/Aplicaciones
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Aplicacion>> PostAplicacion(Aplicacion aplicacion)
        //{
        //    _context.Aplicaciones.Add(aplicacion);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAplicacion", new { id = aplicacion.AplicacionesId }, aplicacion);
        //}

        //// DELETE: api/Aplicaciones/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAplicacion(int id)
        //{
        //    var aplicacion = await _context.Aplicaciones.FindAsync(id);
        //    if (aplicacion == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Aplicaciones.Remove(aplicacion);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AplicacionExists(int id)
        //{
        //    return _context.Aplicaciones.Any(e => e.AplicacionesId == id);
        //}
    }
}
