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
    public class IncidentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public IncidentesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Incidentes
        [HttpGet]
        public async Task<List<IncidentesDto>> GetIncidentes()
        {
            var incidentes = await _context.Incidentes.ToListAsync();
            return _mapper.Map<List<IncidentesDto>>(incidentes);
        }

        // GET: api/Incidentes
        [HttpGet("{id}")]
        public ActionResult<IncidentesDto> GetIncidentesById(int id)
        {
            var incidentes =  _context.Incidentes.Find(id);
            return _mapper.Map<IncidentesDto>(incidentes);
            //return _mapper.Map<ActionResult<IncidentesDto>>(incidentes);
        }

        //POST: api/Incidentes
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<IncidentesDto> PostIncidente(IncidentesDto incidenteDto)
        {
            var incidente = _mapper.Map<Incidente>(incidenteDto);
            _context.Incidentes.Add(incidente);
            _context.SaveChanges();

            return CreatedAtAction("GetIncidentesById", new { id = incidente.IncidenteId }, incidente);
        }

        // PUT: api/Incidentes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidente(int id, IncidentesDto incidenteDto)
        {
            var incidente = _context.Incidentes.Find(id);
            if (incidente is null)
            {
                return NotFound();
            }

            incidente.Descripcion = incidenteDto.Descripcion;
            incidente.Estado = incidenteDto.Estado;
            incidente.Prioridad = incidenteDto.Prioridad;
            incidente.Fecha = incidenteDto.Fecha;
            incidente.UsuariosId = incidenteDto.usuariosid;
            incidente.AplicacionesId = incidenteDto.aplicacionesid;
            incidente.Usuarios = incidenteDto.usuarios;
            incidente.Aplicaciones = incidenteDto.aplicaciones;


            _context.Entry(incidente).State = EntityState.Modified;
            _context.SaveChanges();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                {
                    throw;
                }
            }
            return NoContent();
            //return CreatedAtAction("GetIncidentesById", new { id = incidente.IncidenteId }, incidente);

            //return CreatedAtAction("GetIncidentesById", new { id = incidente.IncidenteId }, incidente);
        }

    }
}
