using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Usuario_Cliente
    {
        public Guid id_usuario_cliente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dir_correoElectronico { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public List<Reseña_Negocio> Reseña_Negocios { get; set; }
        public List<Reserva_Habitacion> Reserva_Habitacion { get; set; }

    }
}
