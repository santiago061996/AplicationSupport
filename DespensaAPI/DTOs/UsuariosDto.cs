using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IncidentesAPI.Models
{
    public class UsuariosDto
    {
        //public UsuariosDto()
        //{
        //    Incidentes = new HashSet<Incidente>();
        //}
        [Key]
        public int UsuariosId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        //public int RolesId { get; set; }

        //public virtual Rol Roles { get; set; }
        //public virtual ICollection<Incidente> Incidentes { get; set; }

    }
}
