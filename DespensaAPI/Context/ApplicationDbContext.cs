using IncidentesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace IncidentesAPI.Context
{
    public class ApplicationDbContext: DbContext
    {
        //public DbSet<Incidentes> Incidente { get; set; }
        //public DbSet<Areas> Areas { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        //public DbSet<Usuarios> Usuarios { get; set; }
        //public DbSet<Aplicaciones> Aplicaciones { get; set; }

        public virtual DbSet<Aplicacion> Aplicaciones { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Incidente> Incidentes { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public DbSet<IncidentesAPI.Models.AreasDto> AreasDto { get; set; }
        public DbSet<IncidentesAPI.Models.AplicacionesDto> AplicacionesDto { get; set; }
        public DbSet<IncidentesAPI.Models.RolesDto> RolesDto { get; set; }
        public DbSet<IncidentesAPI.Models.IncidentesDto> IncidentesDto { get; set; }
        //public DbSet<IncidentesAPI.Models.IncidentesRequestDto> IncidentesRequestDto { get; set; }
        public DbSet<IncidentesAPI.Models.UsuariosDto> UsuariosDto { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>(entity =>
            {
                entity.HasKey(e => e.AplicacionesId);

                entity.HasIndex(e => e.AreasId);

                entity.HasOne(d => d.Areas)
                    .WithMany(p => p.Aplicaciones)
                    .HasForeignKey(d => d.AreasId);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreasId);
            });

            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.ToTable("Incidente");

                entity.HasIndex(e => e.AplicacionesId);

                entity.HasIndex(e => e.UsuariosId);

                entity.HasOne(d => d.Aplicaciones)
                    .WithMany(p => p.Incidentes)
                    .HasForeignKey(d => d.AplicacionesId);

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.Incidentes)
                    .HasForeignKey(d => d.UsuariosId);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolesId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuariosId);

                entity.HasIndex(e => e.RolesId);

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolesId);
            });

            modelBuilder.Entity<Area>()
                .HasData(new { AreasId = 1, Descripcion = "Contabilidad" },
                         new { AreasId = 2, Descripcion = "Comercial" },
                         new { AreasId = 3, Descripcion = "Legal" },
                         new { AreasId = 4, Descripcion = "Tributario" }
                         ) ;

            modelBuilder.Entity<Rol>()
               .HasData(new { RolesId = 1, Descripcion = "Interno" },
                        new { RolesId = 2, Descripcion = "Externo" },
                        new { RolesId = 3, Descripcion = "Soporte" }                        
                        );

            modelBuilder.Entity<Usuario>()
               .HasData(new { UsuariosId = 1, Nombre = "Alberto", Apellidos = "Rodriguez", Email = "alber@gmaill.com", RolesId = 1 },
                        new { UsuariosId = 2, Nombre = "Jose", Apellidos = "Palacio", Email = "josep@gmail.com", RolesId = 1 },
                        new { UsuariosId = 3, Nombre = "Maria", Apellidos = "Ramirez", Email = "mariar@gmail.com", RolesId = 2 },
                        new { UsuariosId = 4, Nombre = "Daniel", Apellidos = "Salas", Email = "danisa@gmail.com", RolesId = 3 }
                        );

            modelBuilder.Entity<Aplicacion>()
            .HasData(new { AplicacionesId = 1, TipoAplicativo = "Interno", Descripcion = "Contabilidad", AreasId = 1 },
                     new { AplicacionesId = 2, TipoAplicativo = "Interno", Descripcion = "Comercial", AreasId = 2 },
                     new { AplicacionesId = 3, TipoAplicativo = "Interno", Descripcion = "Legal", AreasId = 3 }
                     );

            modelBuilder.Entity<Incidente>()
          .HasData(new { IncidenteId = 1, Descripcion = "No funciona la herramienta contable",Estado = "Pendiente", Prioridad = 1, Fecha = DateTime.Now, UsuariosId = 1 ,AplicacionesId = 1 }                   
                   );



            //if (modelBuilder == null)
            //{
            //    return;
            //}


            //base.OnModelCreating(modelBuilder);
        }


        //public DbSet<IncidentesAPI.Models.IncidentesMesa> IncidentesMesa { get; set; }

    }
}
