using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Negocio
    {
        public Guid id_negocio { get; set; }
        public Guid id_usuario_admin { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen_local { get; set; }
        public string direccion { get; set; }
        public string ubicacion { get; set; }
        public string telefono { get; set; }
        public string dir_correoElectronico { get; set; }

        [ForeignKey("id_usuario_admin")]
        public Usuario_Admin Usuario_admin{ get; set; }
        public List<Reseña_Negocio> Reseña_Negocios { get; set; }
        public List<Habitacion> Habitacion { get; set; }

    }
}
