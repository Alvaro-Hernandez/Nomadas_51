using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Habitacion
    {
        public Guid id_habitacion { get; set; }
        public string dimensiones { get; set; }
        public string descripcion { get; set; }
        public double renta_por_dia { get; set; }
        public Guid id_negocio { get; set; }

        [ForeignKey("id_negocio")]
        public Negocio Negocio { get; set; }
        public List<Habitacion_Imagenes> Habitacion_Imagenes { get; set; }
        public List<Reserva_Habitacion> Reserva_Habitacion { get; set; }

    }
}
