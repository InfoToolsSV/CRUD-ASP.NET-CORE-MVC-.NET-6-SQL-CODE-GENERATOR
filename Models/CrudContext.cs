using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF.Models;

public partial class CrudContext : DbContext
{
    public CrudContext(DbContextOptions<CrudContext> options)
        : base(options)
    {
        Clientes = Set<Cliente>();
        Pedidos = Set<Pedido>();
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD087FE2705FC");

            entity.ToTable("Cliente");

            entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedido__09BA14304E05834D");

            entity.ToTable("Pedido");

            entity.Property(e => e.Descripcion).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");

            entity
                .HasOne(d => d.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Cliente_Pedido_ClienteId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
