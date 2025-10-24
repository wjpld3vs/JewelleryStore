using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Compras> Compras { get; set; }

    public virtual DbSet<DetalleCompras> DetalleCompras { get; set; }

    public virtual DbSet<DetalleDevoluciones> DetalleDevoluciones { get; set; }

    public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }

    public virtual DbSet<DetallesCompletosVentasImagenes> DetallesCompletosVentasImagenes { get; set; }

    public virtual DbSet<Devoluciones> Devoluciones { get; set; }

    public virtual DbSet<Imagenes> Imagenes { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Reembolsos> Reembolsos { get; set; }

    public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Vendedores> Vendedores { get; set; }

    public virtual DbSet<Ventas> Ventas { get; set; }

    public virtual DbSet<VentasTotalesPorPais> VentasTotalesPorPais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5CB894A45");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A71EDF22C6");
        });

        modelBuilder.Entity<Compras>(entity =>
        {
            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Proveedores");
        });

        modelBuilder.Entity<DetalleCompras>(entity =>
        {
            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompras_Compras");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompras_Productos");
        });

        modelBuilder.Entity<DetalleDevoluciones>(entity =>
        {
            entity.HasOne(d => d.IdDetalleVentaNavigation).WithMany(p => p.DetalleDevoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDevoluciones_DetalleVentas");

            entity.HasOne(d => d.IdDevolucionNavigation).WithMany(p => p.DetalleDevoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDevoluciones_Devoluciones");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleDevoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDevoluciones_Productos");
        });

        modelBuilder.Entity<DetalleVentas>(entity =>
        {
            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVentas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVentas_Productos");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVentas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVentas_Ventas");
        });

        modelBuilder.Entity<DetallesCompletosVentasImagenes>(entity =>
        {
            entity.ToView("DetallesCompletosVentas_imagenes");
        });

        modelBuilder.Entity<Imagenes>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__Imagenes__0C7D20D73D9A19A6");

            entity.HasOne(d => d.Producto).WithMany(p => p.Imagenes).HasConstraintName("FK__Imagenes__Produc__29572725");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83BABB41D1");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos).HasConstraintName("FK__Productos__Categ__267ABA7A");
        });

        modelBuilder.Entity<Reembolsos>(entity =>
        {
            entity.HasOne(d => d.IdDevolucionNavigation).WithMany(p => p.Reembolsos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reembolsos_Devoluciones");
        });

        modelBuilder.Entity<Ubicaciones>(entity =>
        {
            entity.HasKey(e => e.UbicacionId).HasName("PK__Ubicacio__10375DF5E78340B3");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_Usuario");
        });

        modelBuilder.Entity<Vendedores>(entity =>
        {
            entity.HasKey(e => e.VendedorId).HasName("PK__Vendedor__2033EECC78F581C3");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__5B41514C31CECBC7");

            entity.ToTable(tb => tb.HasTrigger("trg_AfterInsertUpdateVentas"));

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ventas).HasConstraintName("FK__Ventas__ClienteI__33D4B598");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Ventas).HasConstraintName("FK__Ventas__Ubicacio__34C8D9D1");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Ventas).HasConstraintName("FK__Ventas__Vendedor__32E0915F");
        });

        modelBuilder.Entity<VentasTotalesPorPais>(entity =>
        {
            entity.ToView("VentasTotalesPorPais");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
