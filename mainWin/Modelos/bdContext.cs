using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace mainWin.Modelos;

public partial class bdContext : DbContext
{
    string conn;
    public bdContext(string conn)
    {
        this.conn = conn;
        MessageBox.Show(conn);
    }

    public bdContext(DbContextOptions<bdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<Pendiente> Pendientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies().UseMySql(conn, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
    //.UseLazyLoadingProxies()
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity
                .ToTable("categorias")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Categoria1)
                .HasMaxLength(45)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PRIMARY");

            entity
                .ToTable("citas")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ClienteId, "idCliente");

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Desc)
                .HasMaxLength(100)
                .HasColumnName("desc");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("citas_ibfk_1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity
                .ToTable("clientes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.IdConfig).HasName("PRIMARY");

            entity
                .ToTable("configuracion")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.IdConfig).HasColumnName("idConfig");
            entity.Property(e => e.Opcion2)
                .HasMaxLength(45)
                .HasColumnName("opcion2");
            entity.Property(e => e.RutaFs)
                .HasMaxLength(45)
                .HasColumnName("rutaFS");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Configuracions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("configuracion_ibfk_1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity
                .ToTable("empleados")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.RolId, "rol_id");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity
                .ToTable("estados")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(45)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PRIMARY");

            entity
                .ToTable("marcas")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PRIMARY");

            entity
                .ToTable("ordenes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AsignadoId, "asignado_id");

            entity.HasIndex(e => e.ClienteId, "cliente_id");

            entity.HasIndex(e => e.EstadoId, "estado_id");

            entity.HasIndex(e => e.ProductoId, "producto_id");

            entity.HasIndex(e => e.ServicioId, "servicio_id");

            entity.Property(e => e.IdOrden).HasColumnName("idOrden");
            entity.Property(e => e.AsignadoId).HasColumnName("asignado_id");
            entity.Property(e => e.Averia).HasColumnName("averia");
            entity.Property(e => e.CliDni).HasMaxLength(45);
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.ClienteStr).HasMaxLength(45);
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaComp).HasColumnName("fecha_comp");
            entity.Property(e => e.FechaEnt).HasColumnName("fecha_ent");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .HasColumnName("modelo");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(45)
                .HasColumnName("prioridad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.RowVersion).HasColumnType("timestamp");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.Solucion).HasColumnName("solucion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Asignado).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.AsignadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_3");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_1");

            entity.HasOne(d => d.Estado).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_5");

            entity.HasOne(d => d.Producto).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_4");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_ibfk_2");
        });

        modelBuilder.Entity<Pendiente>(entity =>
        {
            entity.HasKey(e => e.IdPendientes).HasName("PRIMARY");

            entity
                .ToTable("pendientes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.EstadoId, "estado_id");

            entity.Property(e => e.IdPendientes).HasColumnName("idPendientes");
            entity.Property(e => e.Anticipo)
                .HasPrecision(10, 2)
                .HasColumnName("anticipo");
            entity.Property(e => e.Completado).HasColumnName("completado");
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Pedido)
                .HasMaxLength(45)
                .HasColumnName("pedido");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.RowVersion).HasColumnType("timestamp");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Estado).WithMany(p => p.Pendientes)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pendientes_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity
                .ToTable("productos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CategoriaId, "categoria_id");

            entity.HasIndex(e => e.MarcaId, "marca_id");

            entity.HasIndex(e => e.ProveedorId, "proveedor_id");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Costo)
                .HasPrecision(10, 2)
                .HasColumnName("costo");
            entity.Property(e => e.Existencias).HasColumnName("existencias");
            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Producto1)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_2");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_3");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity
                .ToTable("proveedores")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Desc)
                .HasMaxLength(200)
                .HasColumnName("desc");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Empresa)
                .HasMaxLength(100)
                .HasColumnName("empresa");
            entity.Property(e => e.PersonaCont)
                .HasMaxLength(100)
                .HasColumnName("personaCont");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .HasColumnName("sitioWeb");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Rol)
                .HasMaxLength(45)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity
                .ToTable("servicios")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Servicio1)
                .HasMaxLength(45)
                .HasColumnName("servicio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity
                .ToTable("usuarios")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.EmpleadoId, "empleado_id");

            entity.HasIndex(e => e.RolId, "rol_id");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.Nick)
                .HasMaxLength(45)
                .HasColumnName("nick");
            entity.Property(e => e.PasswordHash).HasColumnType("blob");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Salt).HasColumnType("blob");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_2");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
