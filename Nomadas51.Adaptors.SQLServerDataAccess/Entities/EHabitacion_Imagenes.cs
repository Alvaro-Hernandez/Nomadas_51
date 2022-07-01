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
    internal class EHabitacion_Imagenes : IEntityTypeConfiguration<Habitacion_Imagenes>
    {
        public void Configure(EntityTypeBuilder<Habitacion_Imagenes> builder)
        {
            builder.ToTable("tb_habitacion_imagenes");
            builder.HasKey(hi => hi.id_imagen);

            builder
                .HasOne(hi => hi.Habitacion)
                .WithMany(hi => hi.Habitacion_Imagenes);
        }
    }
}
