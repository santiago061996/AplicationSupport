// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace IncidentesAPI.Models
{
    public partial class Area
    {
        public Area()
        {
            Aplicaciones = new HashSet<Aplicacion>();
        }        
        public int AreasId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Aplicacion> Aplicaciones { get; set; }
    }
}