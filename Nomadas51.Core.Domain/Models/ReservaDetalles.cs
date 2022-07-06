using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class ReservaDetalles
    {
        public Guid id_habitacion { get; set; }
        public Guid id_reserva { get; set; }
        public int dias_reservados { get; set; }
        public double renta_por_dia { get; set; }
        public double costo_total { get; set; }
        public Habitacion Habitacion { get; set; }
        public Reserva_Habitacion Reserva_Habitacion { get; set; }
    }
}

