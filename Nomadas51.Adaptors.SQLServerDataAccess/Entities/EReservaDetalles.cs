using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomadas51.Core.Domain.Models;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Entities
{
    public class EReservaDetalles : IEntityTypeConfiguration<ReservaDetalles>
    {
        public void Configure(EntityTypeBuilder<ReservaDetalles> builder)
        {
            builder.ToTable("tb_reserva_detalles");
            builder.HasKey(r => new {r.id_reserva, r.id_habitacion});

            builder
                .HasOne(r => r.Habitacion)
                .WithMany( r => r.ReservaDetalles);

            builder
                .HasOne(r => r.Reserva_Habitacion)
                .WithMany(r => r.ReservaDetalles);

        }
    }
}
