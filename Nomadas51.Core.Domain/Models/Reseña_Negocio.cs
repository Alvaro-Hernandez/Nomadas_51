using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomadas51.Core.Domain.Models
{
    public class Reseña_Negocio
    {
        public Guid id_reseña { get; set; }
        public Guid id_negocio { get; set; }
        public Guid id_usuario_cliente { get; set; }
        public string opinion { get; set; }
        public int valoracion { get; set; }

        [ForeignKey("id_usuario_cliente")]
        public Usuario_Cliente Usuario_Cliente { get; set; }


        [ForeignKey("id_negocio")]
        public Negocio Negocio { get; set; }
    }
}
