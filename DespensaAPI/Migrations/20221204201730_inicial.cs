using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentesAPI.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplicacionesDto",
                columns: table => new
                {
                    AplicacionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAplicativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacionesDto", x => x.AplicacionesId);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreasId);
                });

            migrationBuilder.CreateTable(
                name: "AreasDto",
                columns: table => new
                {
                    AreasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDto", x => x.AreasId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentesDto",
                columns: table => new
                {
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentesDto", x => x.Descripcion);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "RolesDto",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDto", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosDto",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosDto", x => x.UsuariosId);
                });

            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                columns: table => new
                {
                    AplicacionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAplicativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.AplicacionesId);
                    table.ForeignKey(
                        name: "FK_Aplicaciones_Areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Areas",
                        principalColumn: "AreasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidente",
                columns: table => new
                {
                    IncidenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false),
                    AplicacionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidente", x => x.IncidenteId);
                    table.ForeignKey(
                        name: "FK_Incidente_Aplicaciones_AplicacionesId",
                        column: x => x.AplicacionesId,
                        principalTable: "Aplicaciones",
                        principalColumn: "AplicacionesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidente_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreasId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Contabilidad" },
                    { 2, "Comercial" },
                    { 3, "Legal" },
                    { 4, "Tributario" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolesId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Interno" },
                    { 2, "Externo" },
                    { 3, "Soporte" }
                });

            migrationBuilder.InsertData(
                table: "Aplicaciones",
                columns: new[] { "AplicacionesId", "AreasId", "Descripcion", "TipoAplicativo" },
                values: new object[,]
                {
                    { 1, 1, "Contabilidad", "Interno" },
                    { 2, 2, "Comercial", "Interno" },
                    { 3, 3, "Legal", "Interno" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuariosId", "Apellidos", "Email", "Nombre", "RolesId" },
                values: new object[,]
                {
                    { 1, "Rodriguez", "alber@gmaill.com", "Alberto", 1 },
                    { 2, "Palacio", "josep@gmail.com", "Jose", 1 },
                    { 3, "Ramirez", "mariar@gmail.com", "Maria", 2 },
                    { 4, "Salas", "danisa@gmail.com", "Daniel", 3 }
                });

            migrationBuilder.InsertData(
                table: "Incidente",
                columns: new[] { "IncidenteId", "AplicacionesId", "Descripcion", "Estado", "Fecha", "Prioridad", "UsuariosId" },
                values: new object[] { 1, 1, "No funciona la herramienta contable", "Pendiente", new DateTime(2022, 12, 4, 15, 17, 29, 845, DateTimeKind.Local).AddTicks(6381), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicaciones_AreasId",
                table: "Aplicaciones",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_AplicacionesId",
                table: "Incidente",
                column: "AplicacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_UsuariosId",
                table: "Incidente",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolesId",
                table: "Usuarios",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacionesDto");

            migrationBuilder.DropTable(
                name: "AreasDto");

            migrationBuilder.DropTable(
                name: "Incidente");

            migrationBuilder.DropTable(
                name: "IncidentesDto");

            migrationBuilder.DropTable(
                name: "RolesDto");

            migrationBuilder.DropTable(
                name: "UsuariosDto");

            migrationBuilder.DropTable(
                name: "Aplicaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
