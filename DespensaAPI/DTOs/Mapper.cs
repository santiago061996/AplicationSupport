using AutoMapper;
using IncidentesAPI.Models;

namespace ContosoUniversity.BL.DTOs
{
    public class AutoMapperProfle : Profile
    {
        public AutoMapperProfle()
        {
            CreateMap<IncidentesDto, Incidente>();
            CreateMap<Incidente, IncidentesDto>();

            CreateMap<AplicacionesDto, Aplicacion>();
            CreateMap<Aplicacion, AplicacionesDto>();

            CreateMap<AreasDto, Area>();
            CreateMap<Area, AreasDto>();

            CreateMap<RolesDto, Rol>();
            CreateMap<Rol, RolesDto>();

            CreateMap<UsuariosDto, Usuario>();
            CreateMap<Usuario, UsuariosDto>();
        }
    }
}
