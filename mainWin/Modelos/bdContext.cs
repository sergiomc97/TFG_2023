using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using K4os.Compression.LZ4.Streams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;

namespace mainWin.Modelos;

public partial class bdContext : DbContext {
    string conn;
    public bdContext(string conn) {
        this.conn = conn;
    }


    public bdContext(DbContextOptions<bdContext> options)
        : base(options) {
    }

    public virtual DbSet<__efmigrationshistory> __efmigrationshistories { get; set; }

    public virtual DbSet<Categoria> categorias { get; set; }

    public virtual DbSet<Cita> citas { get; set; }

    public virtual DbSet<Cliente> clientes { get; set; }

    public virtual DbSet<Configuracion> configuracions { get; set; }

    public virtual DbSet<Empleado> empleados { get; set; }

    public virtual DbSet<Estado> estados { get; set; }

    public virtual DbSet<Marca> marcas { get; set; }

    public virtual DbSet<Ordene> ordenes { get; set; }

    public virtual DbSet<Pendiente> pendientes { get; set; }

    public virtual DbSet<Producto> productos { get; set; }

    public virtual DbSet<Proveedore> proveedores { get; set; }

    public virtual DbSet<Role> roles { get; set; }

    public virtual DbSet<Servicio> servicios { get; set; }

    public virtual DbSet<Usuario> usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    //    optionsBuilder.UseMySql("server=localhost;user id=root;password=060989;database=app1",
    //         Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"))
    //        .LogTo(message => Debug.WriteLine(message)).EnableSensitiveDataLogging();

    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseLazyLoadingProxies()
                           .UseMySql(conn, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<__efmigrationshistory>(entity => {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Categoria>(entity => {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Categoria1)
                .HasMaxLength(45)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Cita>(entity => {
            entity.HasKey(e => e.IdCita).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Cliente_id, "idCliente");

            entity.Property(e => e.Desc).HasMaxLength(100);
            entity.Property(e => e.Hora).HasColumnType("time");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("citas_ibfk_1");
        });

        modelBuilder.Entity<Cliente>(entity => {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Direccion).HasMaxLength(45);
            entity.Property(e => e.Dni).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<Configuracion>(entity => {
            entity.HasKey(e => e.IdConfig).HasName("PRIMARY");

            entity
                .ToTable("configuracion")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Usuario_id, "usuario_id");

            entity.Property(e => e.Opcion2).HasMaxLength(45);
            entity.Property(e => e.RutaFS).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Configuracions)
                .HasForeignKey(d => d.Usuario_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("configuracion_ibfk_1");
        });

        modelBuilder.Entity<Empleado>(entity => {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<Estado>(entity => {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Estado1)
                .HasMaxLength(45)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Marca>(entity => {
            entity.HasKey(e => e.IdMarca).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Ordene>(entity => {
            entity.HasKey(e => e.IdOrden).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Asignado_id, "asignado_id");

            entity.HasIndex(e => e.Cliente_id, "cliente_id");

            entity.HasIndex(e => e.Estado_id, "estado_id");

            entity.HasIndex(e => e.Producto_id, "producto_id");

            entity.HasIndex(e => e.Servicio_id, "servicio_id");

            entity.Property(e => e.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Modelo).HasMaxLength(255);
            entity.Property(e => e.Prioridad).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(45);

            entity.HasOne(d => d.Asignado).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Asignado_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_3");

            entity.HasOne(d => d.Producto).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_1");

            entity.HasOne(d => d.Estado).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Estado_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_5");

            entity.HasOne(d => d.Producto).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Producto_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_4");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Servicio_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_2");
            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Cliente_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_1");
        });

        modelBuilder.Entity<Pendiente>(entity => {
            entity.HasKey(e => e.IdPendientes).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Estado_id, "estado_id");

            entity.Property(e => e.RowVersion).HasColumnType("timestamp");
            entity.Property(e => e.Anticipo).HasPrecision(10, 2);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pedido).HasMaxLength(45);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
            entity.Property(e => e.Telefono).HasMaxLength(45);

            entity.HasOne(d => d.Estado).WithMany(p => p.Pendientes)
                .HasForeignKey(d => d.Estado_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pendientes_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity => {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Categoria_id, "categoria_id");

            entity.HasIndex(e => e.Marca_id, "marca_id");

            entity.HasIndex(e => e.Proveedor_id, "proveedor_id");

            entity.Property(e => e.Costo).HasPrecision(10, 2);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
            entity.Property(e => e.Producto1)
                .HasMaxLength(100)
                .HasColumnName("producto");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoria_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_2");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Marca_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Proveedor_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_3");
        });

        modelBuilder.Entity<Proveedore>(entity => {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Desc).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Empresa).HasMaxLength(100);
            entity.Property(e => e.PersonaCont).HasMaxLength(100);
            entity.Property(e => e.SitioWeb).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<Role>(entity => {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Rol).HasMaxLength(45);
        });

        modelBuilder.Entity<Servicio>(entity => {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Servicio1)
                .HasMaxLength(45)
                .HasColumnName("servicio");
        });

        modelBuilder.Entity<Usuario>(entity => {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Empleado_id, "empleado_id");

            entity.HasIndex(e => e.Rol_id, "rol_id");

            entity.Property(e => e.PasswordHash).HasColumnType("blob");
            entity.Property(e => e.Salt).HasColumnType("blob");
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Nick).HasMaxLength(45);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Empleado_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_2");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
