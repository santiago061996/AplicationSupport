using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentesAPI.Models
{
    public class AplicacionesDto
    {
        //public AplicacionesDto()
        //{
        //    Incidentes = new HashSet<Incidente>();
        //}
        [Key]
        public int AplicacionesId { get; set; }
        public string TipoAplicativo { get; set; }
        public string Descripcion { get; set; }
        //public int AreasId { get; set; }

        //public virtual Area Areas { get; set; }
        //public virtual ICollection<Incidente> Incidentes { get; set; }


    }
}
