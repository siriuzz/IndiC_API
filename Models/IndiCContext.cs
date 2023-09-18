using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndiC_API.Models;

public partial class IndiCContext : DbContext
{
    public IndiCContext()
    {
    }

    public IndiCContext(DbContextOptions<IndiCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<ConfigCalif> ConfigCalifs { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteAsignatura> EstudianteAsignaturas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:IndicDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__Asignatu__33A22F4CFDB7BD12");

            entity.ToTable("Asignatura");

            entity.HasIndex(e => e.IdAsignatura, "UQ__Asignatu__33A22F4D4DFE0B0F").IsUnique();

            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            entity.Property(e => e.Activa).HasColumnName("activa");
            entity.Property(e => e.Asignatura1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("asignatura");
            entity.Property(e => e.Aula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aula");
            entity.Property(e => e.CalificacionBaseMt).HasColumnName("calificacion_base_mt");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.IdDocente).HasColumnName("id_docente");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdDocente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asignatura_id_docente");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carrera__82525F26CE27BDA6");

            entity.ToTable("Carrera");

            entity.HasIndex(e => e.IdCarrera, "UQ__Carrera__82525F270EBF8C87").IsUnique();

            entity.Property(e => e.IdCarrera)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_carrera");
            entity.Property(e => e.AsignaturasTotales).HasColumnName("asignaturas_totales");
            entity.Property(e => e.Carrera1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("carrera");
            entity.Property(e => e.PeriodosTotales).HasColumnName("periodos_totales");
        });

        modelBuilder.Entity<ConfigCalif>(entity =>
        {
            entity.HasKey(e => e.IdConfig).HasName("PK__Config_C__8F0A1FB2385D4C01");

            entity.ToTable("Config_Calif");

            entity.HasIndex(e => e.IdConfig, "UQ__Config_C__8F0A1FB3DD4EF9CD").IsUnique();

            entity.Property(e => e.IdConfig).HasColumnName("id_config");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docente__300DB2115A5FEA57");

            entity.ToTable("Docente");

            entity.HasIndex(e => e.IdDocente, "UQ__Docente__300DB2109BD72B08").IsUnique();

            entity.Property(e => e.IdDocente)
                .ValueGeneratedNever()
                .HasColumnName("id_docente");
            entity.Property(e => e.CedulaDocente).HasColumnName("cedula_docente");
            entity.Property(e => e.Configuracion)
                .IsUnicode(false)
                .HasColumnName("configuracion");
            entity.Property(e => e.CorreoDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_docente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_docente");
            entity.Property(e => e.PasswordDocente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password_docente");
            entity.Property(e => e.TelefonoDocente).HasColumnName("telefono_docente");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_docente_id_estado");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_docente_id_rol");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__86989FB2EADA1F11");

            entity.ToTable("Estado");

            entity.HasIndex(e => e.IdEstado, "UQ__Estado__86989FB3C0230024").IsUnique();

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnName("id_estado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__E0B2763CAAFCEE2A");

            entity.ToTable("Estudiante");

            entity.HasIndex(e => e.IdEstudiante, "UQ__Estudian__E0B2763DD27DB5B3").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.CedulaEstudiante).HasColumnName("cedula_estudiante");
            entity.Property(e => e.Configuracion)
                .IsUnicode(false)
                .HasColumnName("configuracion");
            entity.Property(e => e.CorreoEstudiante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_estudiante");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            entity.Property(e => e.IdCarrera)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_carrera");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_estudiante");
            entity.Property(e => e.PasswordEstudiante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password_estudiante");
            entity.Property(e => e.PeriodosCursados).HasColumnName("periodos_cursados");
            entity.Property(e => e.TelefonoEstudiante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono_estudiante");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estudiante_id_carrera");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estudiante_id_estado");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estudiante_id_rol");
        });

        modelBuilder.Entity<EstudianteAsignatura>(entity =>
        {
            entity.HasKey(e => new { e.IdEstudiante, e.IdAsignatura }).HasName("PK__Estudian__338854C86CB64904");

            entity.ToTable("Estudiante_Asignatura");

            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            entity.Property(e => e.CalificacionFinal).HasColumnName("calificacion_final");
            entity.Property(e => e.CalificacionMt).HasColumnName("calificacion_mt");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estudiante_asignatura_id_asignatura");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.EstudianteAsignaturas)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estudiante_asignatura_id_estudiante");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("PK__Roles__C73330E761BE5708");

            entity.HasIndex(e => e.IdRoles, "UQ__Roles__C73330E6227C042A").IsUnique();

            entity.Property(e => e.IdRoles)
                .ValueGeneratedNever()
                .HasColumnName("id_roles");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
