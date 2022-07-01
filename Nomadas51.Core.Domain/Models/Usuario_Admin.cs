using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Usuario_Admin
    {
        public Guid id_usuario_admin { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dir_correoElectronico { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public List<Negocio> Negocios { get; set; }
    }
}
