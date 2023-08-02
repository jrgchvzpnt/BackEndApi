using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Models;

public partial class VentasContext : DbContext
{
    public VentasContext()
    {
    }

    public VentasContext(DbContextOptions<VentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TiposProducto> TiposProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0724A6D9EA");

            entity.ToTable("Producto");

            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Existencia).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FechaEliminado).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TipoProductoId).HasColumnName("TipoProducto_Id");

            entity.HasOne(d => d.TipoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoProductoId)
                .HasConstraintName("FK__Producto__TipoPr__398D8EEE");
        });

        modelBuilder.Entity<TiposProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposPro__3214EC07F34D14C5");

            entity.Property(e => e.DescripcionTipoProducto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcionTipoProducto");
            entity.Property(e => e.FechaEliminado).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreTipoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoProducto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
