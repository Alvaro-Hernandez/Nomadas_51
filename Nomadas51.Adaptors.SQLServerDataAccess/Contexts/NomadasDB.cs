using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomadas51.Core.Domain.Models;
using Nomadas51.Adaptors.SQLServerDataAccess.Entities;
using Nomadas51.Adaptors.SQLServerDataAccess.Utils;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Contexts
{
    public class NomadasDB :DbContext
    {
        public DbSet<Usuario_Cliente> Usuarios_Cliente { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Habitacion_Imagenes> Habitacion_Imagenes { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Reserva_Habitacion> Reserva_Habitaciones { get; set; }
        public DbSet<Reseña_Negocio> Reseña_Negocios { get; set; }
        public DbSet<Usuario_Admin> Usuarios_Admin { get; set; }
        public DbSet<ReservaDetalles> ReservaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EUsuario_Cliente());
            builder.ApplyConfiguration(new EUsuario_Admin());
            builder.ApplyConfiguration(new EReserva_Habitacion());
            builder.ApplyConfiguration(new EReseña_Negocio());
            builder.ApplyConfiguration(new ENegocio());
            builder.ApplyConfiguration(new EHabitacion_Imagenes());
            builder.ApplyConfiguration(new EHabitacion());
            builder.ApplyConfiguration(new EReservaDetalles());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.sqlServerConnectionString);
        }
    }

}