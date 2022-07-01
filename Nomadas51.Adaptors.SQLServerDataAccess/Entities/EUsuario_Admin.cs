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
    public class EUsuario_Admin : IEntityTypeConfiguration<Usuario_Admin>
    {
        public void Configure(EntityTypeBuilder<Usuario_Admin> builder)
        {
            builder.ToTable("tb_usuario_admin");
            builder.HasKey(u => u.id_usuario_admin);

            builder
                .HasMany(r => r.Negocios)
                .WithOne(r => r.Usuario_admin);
        }
    }
}
