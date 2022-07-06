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
    public class EHabitacion : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.ToTable("tb_habitacion");
            builder.HasKey(h => h.id_habitacion);

            builder
                .HasOne(h => h.Negocio)
                .WithMany(h => h.Habitacion);
            builder
                .HasMany(h => h.Habitacion_Imagenes)
                .WithOne(h => h.Habitacion);
            builder
                .HasMany(h => h.ReservaDetalles)
                .WithOne(h => h.Habitacion);
        }
    }
}
