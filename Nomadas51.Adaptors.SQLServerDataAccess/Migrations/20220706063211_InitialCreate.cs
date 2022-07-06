using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nomadas51.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario_admin",
                columns: table => new
                {
                    id_usuario_admin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dir_correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_admin", x => x.id_usuario_admin);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario_cliente",
                columns: table => new
                {
                    id_usuario_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dir_correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_cliente", x => x.id_usuario_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_negocio",
                columns: table => new
                {
                    id_negocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario_admin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen_local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dir_correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_negocio", x => x.id_negocio);
                    table.ForeignKey(
                        name: "FK_tb_negocio_tb_usuario_admin_id_usuario_admin",
                        column: x => x.id_usuario_admin,
                        principalTable: "tb_usuario_admin",
                        principalColumn: "id_usuario_admin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_reserva_habitacion",
                columns: table => new
                {
                    id_reserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costo_total = table.Column<double>(type: "float", nullable: false),
                    dias_reservados = table.Column<int>(type: "int", nullable: false),
                    cancelado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reserva_habitacion", x => x.id_reserva);
                    table.ForeignKey(
                        name: "FK_tb_reserva_habitacion_tb_usuario_cliente_id_usuario_cliente",
                        column: x => x.id_usuario_cliente,
                        principalTable: "tb_usuario_cliente",
                        principalColumn: "id_usuario_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_habitacion",
                columns: table => new
                {
                    id_habitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_negocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dimensiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    renta_por_dia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_habitacion", x => x.id_habitacion);
                    table.ForeignKey(
                        name: "FK_tb_habitacion_tb_negocio_id_negocio",
                        column: x => x.id_negocio,
                        principalTable: "tb_negocio",
                        principalColumn: "id_negocio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_reseña_negocio",
                columns: table => new
                {
                    id_reseña = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_negocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valoracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reseña_negocio", x => x.id_reseña);
                    table.ForeignKey(
                        name: "FK_tb_reseña_negocio_tb_negocio_id_negocio",
                        column: x => x.id_negocio,
                        principalTable: "tb_negocio",
                        principalColumn: "id_negocio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_reseña_negocio_tb_usuario_cliente_id_usuario_cliente",
                        column: x => x.id_usuario_cliente,
                        principalTable: "tb_usuario_cliente",
                        principalColumn: "id_usuario_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_habitacion_imagenes",
                columns: table => new
                {
                    id_imagen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_habitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imagen_habitacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_habitacion_imagenes", x => x.id_imagen);
                    table.ForeignKey(
                        name: "FK_tb_habitacion_imagenes_tb_habitacion_id_habitacion",
                        column: x => x.id_habitacion,
                        principalTable: "tb_habitacion",
                        principalColumn: "id_habitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_reserva_detalles",
                columns: table => new
                {
                    id_habitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_reserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dias_reservados = table.Column<int>(type: "int", nullable: false),
                    renta_por_dia = table.Column<double>(type: "float", nullable: false),
                    costo_total = table.Column<double>(type: "float", nullable: false),
                    Habitacionid_habitacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reserva_Habitacionid_reserva = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reserva_detalles", x => new { x.id_reserva, x.id_habitacion });
                    table.ForeignKey(
                        name: "FK_tb_reserva_detalles_tb_habitacion_Habitacionid_habitacion",
                        column: x => x.Habitacionid_habitacion,
                        principalTable: "tb_habitacion",
                        principalColumn: "id_habitacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_reserva_detalles_tb_reserva_habitacion_Reserva_Habitacionid_reserva",
                        column: x => x.Reserva_Habitacionid_reserva,
                        principalTable: "tb_reserva_habitacion",
                        principalColumn: "id_reserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_habitacion_id_negocio",
                table: "tb_habitacion",
                column: "id_negocio");

            migrationBuilder.CreateIndex(
                name: "IX_tb_habitacion_imagenes_id_habitacion",
                table: "tb_habitacion_imagenes",
                column: "id_habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_tb_negocio_id_usuario_admin",
                table: "tb_negocio",
                column: "id_usuario_admin");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reseña_negocio_id_negocio",
                table: "tb_reseña_negocio",
                column: "id_negocio");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reseña_negocio_id_usuario_cliente",
                table: "tb_reseña_negocio",
                column: "id_usuario_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_detalles_Habitacionid_habitacion",
                table: "tb_reserva_detalles",
                column: "Habitacionid_habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_detalles_Reserva_Habitacionid_reserva",
                table: "tb_reserva_detalles",
                column: "Reserva_Habitacionid_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_habitacion_id_usuario_cliente",
                table: "tb_reserva_habitacion",
                column: "id_usuario_cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_habitacion_imagenes");

            migrationBuilder.DropTable(
                name: "tb_reseña_negocio");

            migrationBuilder.DropTable(
                name: "tb_reserva_detalles");

            migrationBuilder.DropTable(
                name: "tb_habitacion");

            migrationBuilder.DropTable(
                name: "tb_reserva_habitacion");

            migrationBuilder.DropTable(
                name: "tb_negocio");

            migrationBuilder.DropTable(
                name: "tb_usuario_cliente");

            migrationBuilder.DropTable(
                name: "tb_usuario_admin");
        }
    }
}
