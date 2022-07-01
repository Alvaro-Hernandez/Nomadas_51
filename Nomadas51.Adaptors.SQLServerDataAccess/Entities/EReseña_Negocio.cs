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
    public class EReseña_Negocio : IEntityTypeConfiguration<Reseña_Negocio>
    {
        public void Configure(EntityTypeBuilder<Reseña_Negocio> builder)
        {
            builder.ToTable("tb_reseña_negocio");
            builder.HasKey(rn => rn.id_reseña);

            builder
                .HasOne(r => r.Usuario_Cliente)
                .WithMany(r => r.Reseña_Negocios);

            builder
                .HasOne(rn => rn.Negocio)
                .WithMany(rn => rn.Reseña_Negocios);
        }
    }
}
