using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NOMIN.Models;

public partial class NominaContext : DbContext
{
    public NominaContext()
    {
    }

    public NominaContext(DbContextOptions<NominaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Clasesriesgo> Clasesriesgos { get; set; }

    public virtual DbSet<Empledo> Empledos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Motivoscambioscargo> Motivoscambioscargos { get; set; }

    public virtual DbSet<Motivoscambiossueldo> Motivoscambiossueldos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Tipossueldo> Tipossueldos { get; set; }

    public virtual DbSet<Tiposunidade> Tiposunidades { get; set; }

    public virtual DbSet<Unidade> Unidades { get; set; }

    public virtual DbSet<Vigenciascargo> Vigenciascargos { get; set; }

    public virtual DbSet<Vigenciassueldo> Vigenciassueldos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0PAI4P6R\\SQLEXPRESS; Database=NOMINA; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__CARGOS__4E234EF8A1DE0545");

            entity.ToTable("CARGOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Empresa).HasColumnName("EMPRESA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.EmpresaNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.Empresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CARGOS__EMPRESA__2E1BDC42");
        });

        modelBuilder.Entity<Clasesriesgo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__CLASESRI__4E234EF82DFF8EF6");

            entity.ToTable("CLASESRIESGOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Porcentaje)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("PORCENTAJE");
        });

        modelBuilder.Entity<Empledo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__EMPLEDOS__4E234EF844E59001");

            entity.ToTable("EMPLEDOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigoempleado).HasColumnName("CODIGOEMPLEADO");
            entity.Property(e => e.Empresa).HasColumnName("EMPRESA");
            entity.Property(e => e.Persona).HasColumnName("PERSONA");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");

            entity.HasOne(d => d.EmpresaNavigation).WithMany(p => p.Empledos)
                .HasForeignKey(d => d.Empresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEDOS__EMPRES__29572725");

            entity.HasOne(d => d.PersonaNavigation).WithMany(p => p.Empledos)
                .HasForeignKey(d => d.Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEDOS__PERSON__286302EC");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__EMPRESAS__4E234EF844B377BA");

            entity.ToTable("EMPRESAS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Codigoalternativo).HasColumnName("CODIGOALTERNATIVO");
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Motivoscambioscargo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__MOTIVOSC__4E234EF8043C7361");

            entity.ToTable("MOTIVOSCAMBIOSCARGOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Motivoscambiossueldo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__MOTIVOSC__4E234EF8F7798CC3");

            entity.ToTable("MOTIVOSCAMBIOSSUELDOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__PERSONAS__4E234EF8BF63537F");

            entity.ToTable("PERSONAS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Ciudaddocumento).HasColumnName("CIUDADDOCUMENTO");
            entity.Property(e => e.Ciudadnacimiento).HasColumnName("CIUDADNACIMIENTO");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Factorrh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FACTORRH");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("date")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Gruposanguineo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GRUPOSANGUINEO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Numerodocumento).HasColumnName("NUMERODOCUMENTO");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRIMERAPELLIDO");
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SEGUNDOAPELLIDO");
            entity.Property(e => e.Segundonombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SEGUNDONOMBRE");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEXO");
            entity.Property(e => e.Tipodocumento).HasColumnName("TIPODOCUMENTO");
        });

        modelBuilder.Entity<Tipossueldo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__TIPOSSUE__4E234EF8725C5EFD");

            entity.ToTable("TIPOSSUELDOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Tiposunidade>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__TIPOSUNI__4E234EF8C9ADD426");

            entity.ToTable("TIPOSUNIDADES");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__UNIDADES__4E234EF84E271734");

            entity.ToTable("UNIDADES");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Codigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Tipounidad).HasColumnName("TIPOUNIDAD");

            entity.HasOne(d => d.TipounidadNavigation).WithMany(p => p.Unidades)
                .HasForeignKey(d => d.Tipounidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UNIDADES__TIPOUN__49C3F6B7");
        });

        modelBuilder.Entity<Vigenciascargo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__VIGENCIA__4E234EF8D4027FF1");

            entity.ToTable("VIGENCIASCARGOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Cargo).HasColumnName("CARGO");
            entity.Property(e => e.Claseriesgo).HasColumnName("CLASERIESGO");
            entity.Property(e => e.Empleado).HasColumnName("EMPLEADO");
            entity.Property(e => e.Fechavigencia)
                .HasColumnType("date")
                .HasColumnName("FECHAVIGENCIA");
            entity.Property(e => e.Motivocambiocargo).HasColumnName("MOTIVOCAMBIOCARGO");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Vigenciascargos)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__CARGO__3E52440B");

            entity.HasOne(d => d.ClaseriesgoNavigation).WithMany(p => p.Vigenciascargos)
                .HasForeignKey(d => d.Claseriesgo)
                .HasConstraintName("FK__VIGENCIAS__CLASE__412EB0B6");

            entity.HasOne(d => d.EmpleadoNavigation).WithMany(p => p.Vigenciascargos)
                .HasForeignKey(d => d.Empleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__EMPLE__3F466844");

            entity.HasOne(d => d.MotivocambiocargoNavigation).WithMany(p => p.Vigenciascargos)
                .HasForeignKey(d => d.Motivocambiocargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__MOTIV__403A8C7D");
        });

        modelBuilder.Entity<Vigenciassueldo>(entity =>
        {
            entity.HasKey(e => e.Secuencia).HasName("PK__VIGENCIA__4E234EF873758819");

            entity.ToTable("VIGENCIASSUELDOS");

            entity.Property(e => e.Secuencia).HasColumnName("SECUENCIA");
            entity.Property(e => e.Empleado).HasColumnName("EMPLEADO");
            entity.Property(e => e.Fechavigencia)
                .HasColumnType("date")
                .HasColumnName("FECHAVIGENCIA");
            entity.Property(e => e.Motivocambiosueldo).HasColumnName("MOTIVOCAMBIOSUELDO");
            entity.Property(e => e.Tiposueldo).HasColumnName("TIPOSUELDO");
            entity.Property(e => e.Unidadpago).HasColumnName("UNIDADPAGO");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(17, 2)")
                .HasColumnName("VALOR");

            entity.HasOne(d => d.EmpleadoNavigation).WithMany(p => p.Vigenciassueldos)
                .HasForeignKey(d => d.Empleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__EMPLE__5165187F");

            entity.HasOne(d => d.MotivocambiosueldoNavigation).WithMany(p => p.Vigenciassueldos)
                .HasForeignKey(d => d.Motivocambiosueldo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__MOTIV__52593CB8");

            entity.HasOne(d => d.TiposueldoNavigation).WithMany(p => p.Vigenciassueldos)
                .HasForeignKey(d => d.Tiposueldo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__TIPOS__534D60F1");

            entity.HasOne(d => d.UnidadpagoNavigation).WithMany(p => p.Vigenciassueldos)
                .HasForeignKey(d => d.Unidadpago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VIGENCIAS__UNIDA__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
