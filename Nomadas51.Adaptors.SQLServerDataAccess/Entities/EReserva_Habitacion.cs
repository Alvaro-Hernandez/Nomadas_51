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
    public class EReserva_Habitacion : IEntityTypeConfiguration<Reserva_Habitacion>
    {
        public void Configure(EntityTypeBuilder<Reserva_Habitacion> builder)
        {
            builder.ToTable("tb_reserva_habitacion");
            builder.HasKey(rh => rh.id_reserva);

            builder
                .HasMany(rh => rh.ReservaDetalles)
                .WithOne(rh => rh.Reserva_Habitacion);

            builder
                .HasOne(rh => rh.Usuario_Cliente)
                .WithMany(rh => rh.Reserva_Habitacion);
        }
    }
}
