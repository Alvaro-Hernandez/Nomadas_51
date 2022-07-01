using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Reserva_Habitacion
    {
        public Guid id_reserva { get; set; }
        public int dias_reservados { get; set; }
        public DateTime fecha_entrada { get; set; }
        public DateTime fecha_salida { get; set; }
        public double costo_total { get; set; }
        public Guid id_habitacion { get; set; }
        public Guid id_usuario_cliente { get; set; }

        [ForeignKey("id_habitacion")]
        public Habitacion Habitacion { get; set; }

        [ForeignKey("id_usuario_cliente")]
        public Usuario_Cliente Usuario_Cliente { get; set; }
    }
}
