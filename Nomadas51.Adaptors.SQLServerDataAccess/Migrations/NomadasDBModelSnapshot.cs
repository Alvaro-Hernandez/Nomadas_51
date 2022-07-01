﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Migrations
{
    [DbContext(typeof(NomadasDB))]
    partial class NomadasDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Habitacion", b =>
                {
                    b.Property<Guid>("id_habitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dimensiones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_negocio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("renta_por_dia")
                        .HasColumnType("float");

                    b.HasKey("id_habitacion");

                    b.HasIndex("id_negocio");

                    b.ToTable("tb_habitacion");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Habitacion_Imagenes", b =>
                {
                    b.Property<Guid>("id_imagen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_habitacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imagen_habitacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_imagen");

                    b.HasIndex("id_habitacion");

                    b.ToTable("tb_habitacion_imagenes");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Negocio", b =>
                {
                    b.Property<Guid>("id_negocio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dir_correoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_usuario_admin")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imagen_local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_negocio");

                    b.HasIndex("id_usuario_admin");

                    b.ToTable("tb_negocio");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Reserva_Habitacion", b =>
                {
                    b.Property<Guid>("id_reserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("costo_total")
                        .HasColumnType("float");

                    b.Property<int>("dias_reservados")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_entrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_salida")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_habitacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_usuario_cliente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id_reserva");

                    b.HasIndex("id_habitacion");

                    b.HasIndex("id_usuario_cliente");

                    b.ToTable("tb_reserva_habitacion");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Reseña_Negocio", b =>
                {
                    b.Property<Guid>("id_reseña")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_negocio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_usuario_cliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("opinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valoracion")
                        .HasColumnType("int");

                    b.HasKey("id_reseña");

                    b.HasIndex("id_negocio");

                    b.HasIndex("id_usuario_cliente");

                    b.ToTable("tb_reseña_negocio");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Usuario_Admin", b =>
                {
                    b.Property<Guid>("id_usuario_admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dir_correoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario_admin");

                    b.ToTable("tb_usuario_admin");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Usuario_Cliente", b =>
                {
                    b.Property<Guid>("id_usuario_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dir_correoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario_cliente");

                    b.ToTable("tb_usuario_cliente");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Habitacion", b =>
                {
                    b.HasOne("Nomadas51.Core.Domain.Models.Negocio", "Negocio")
                        .WithMany("Habitacion")
                        .HasForeignKey("id_negocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Negocio");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Habitacion_Imagenes", b =>
                {
                    b.HasOne("Nomadas51.Core.Domain.Models.Habitacion", "Habitacion")
                        .WithMany("Habitacion_Imagenes")
                        .HasForeignKey("id_habitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Negocio", b =>
                {
                    b.HasOne("Nomadas51.Core.Domain.Models.Usuario_Admin", "Usuario_admin")
                        .WithMany("Negocios")
                        .HasForeignKey("id_usuario_admin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario_admin");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Reserva_Habitacion", b =>
                {
                    b.HasOne("Nomadas51.Core.Domain.Models.Habitacion", "Habitacion")
                        .WithMany("Reserva_Habitacion")
                        .HasForeignKey("id_habitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nomadas51.Core.Domain.Models.Usuario_Cliente", "Usuario_Cliente")
                        .WithMany("Reserva_Habitacion")
                        .HasForeignKey("id_usuario_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habitacion");

                    b.Navigation("Usuario_Cliente");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Reseña_Negocio", b =>
                {
                    b.HasOne("Nomadas51.Core.Domain.Models.Negocio", "Negocio")
                        .WithMany("Reseña_Negocios")
                        .HasForeignKey("id_negocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nomadas51.Core.Domain.Models.Usuario_Cliente", "Usuario_Cliente")
                        .WithMany("Reseña_Negocios")
                        .HasForeignKey("id_usuario_cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Negocio");

                    b.Navigation("Usuario_Cliente");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Habitacion", b =>
                {
                    b.Navigation("Habitacion_Imagenes");

                    b.Navigation("Reserva_Habitacion");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Negocio", b =>
                {
                    b.Navigation("Habitacion");

                    b.Navigation("Reseña_Negocios");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Usuario_Admin", b =>
                {
                    b.Navigation("Negocios");
                });

            modelBuilder.Entity("Nomadas51.Core.Domain.Models.Usuario_Cliente", b =>
                {
                    b.Navigation("Reseña_Negocios");

                    b.Navigation("Reserva_Habitacion");
                });
#pragma warning restore 612, 618
        }
    }
}