using System;
using System.ComponentModel.DataAnnotations;

namespace IncidentesAPI.Models
{
    public class IncidentesDto
    {
        [Key]
        //public int IncidenteId { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int Prioridad { get; set; }
        public DateTime Fecha { get; set; }
        public int usuariosid { get; set; }
        public int aplicacionesid { get; set; }

        public virtual Aplicacion aplicaciones { get; set; }
        public virtual Usuario usuarios { get; set; }
    }
}
