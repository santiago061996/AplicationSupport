using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IncidentesAPI.Models
{
    public class RolesDto
    {
        //public RolesDto()
        //{
        //    Usuarios = new HashSet<Usuario>();
        //}
        [Key]
        public int RolesId { get; set; }
        public string Descripcion { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
