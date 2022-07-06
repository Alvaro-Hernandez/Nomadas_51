using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomadas51.Core.Domain.Models;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Entities
{
    public class ENegocio : IEntityTypeConfiguration<Negocio>
    {
        public void Configure(EntityTypeBuilder<Negocio> builder)
        {
            builder.ToTable("tb_negocio");
            builder.HasKey(n => n.id_negocio);

            builder
                .HasOne(n => n.Usuario_admin)
                .WithMany(n => n.Negocios);
            builder
                .HasMany(n => n.Reseña_Negocios)
                .WithOne(n => n.Negocio);
            builder
                .HasMany(n => n.Habitacion)
                .WithOne(n => n.Negocio);
        }
    }
}
