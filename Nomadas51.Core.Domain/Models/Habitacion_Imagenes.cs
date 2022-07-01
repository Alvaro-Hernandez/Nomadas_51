using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Habitacion_Imagenes
    {
        public Guid id_imagen { get; set; }
        public string imagen_habitacion { get; set; }
        public Guid id_habitacion { get; set; }

        [ForeignKey("id_habitacion")]
        public Habitacion Habitacion { get; set; }
    }
}
