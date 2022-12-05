using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentesAPI.Models
{
    public class AreasDto
    {
        //public AreasDto()
        //{
        //    Aplicaciones = new HashSet<Aplicacion>();
        //}

        [Key]
        public int AreasId { get; set; }
        public string Descripcion { get; set; }

        //public virtual ICollection<Aplicacion> Aplicaciones { get; set; }

    }
}
