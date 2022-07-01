using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomadas51.Core.Domain.Models;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Entities
{
    public class EUsuario_Cliente : IEntityTypeConfiguration<Usuario_Cliente>
    {
        public void Configure(EntityTypeBuilder<Usuario_Cliente> builder)
        {
            builder.ToTable("tb_usuario_cliente");
            builder.HasKey(u => u.id_usuario_cliente);


            builder
                .HasMany(u => u.Reserva_Habitacion)
                .WithOne(u => u.Usuario_Cliente);

            builder
                .HasMany(p => p.Reseña_Negocios)
                .WithOne(p => p.Usuario_Cliente);
        }
    }
}
