using Microsoft.EntityFrameworkCore;
using PixelPlay.Models;

public class PixelPlayContext : DbContext
{
    public PixelPlayContext(DbContextOptions<PixelPlayContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CategoriasProducto> CategoriasProductos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<DetallesPedido> DetallesPedido { get; set; }
    public DbSet<ComentariosProducto> ComentariosProductos { get; set; }
    public DbSet<CarritoTemporal> CarritoTemporal { get; set; }
    public DbSet<HistorialCompra> HistorialCompras { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //primary keys

        modelBuilder.Entity<Usuario>()
            .HasKey(ct => ct.UsuarioId);

        modelBuilder.Entity<CategoriasProducto>()
            .HasKey(ct => ct.CategoriaId);

        modelBuilder.Entity<Producto>()
            .HasKey(ct => ct.ProductoId); 

        modelBuilder.Entity<Pedido>()
            .HasKey(ct => ct.PedidoId); 

        modelBuilder.Entity<DetallesPedido>()
            .HasKey(ct => ct.DetalleId);

        modelBuilder.Entity<ComentariosProducto>()
            .HasKey(ct => ct.ComentarioId);

        modelBuilder.Entity<CarritoTemporal>()
            .HasKey(ct => ct.CarritoId);

        modelBuilder.Entity<HistorialCompra>()
            .HasKey(ct => ct.HistorialId);

        //Foreign Keys

        // producto -> Categoria
        modelBuilder.Entity<Producto>()
       .HasOne(p => p.Categoria)
       .WithMany(c => c.Productos)
       .HasForeignKey(p => p.CategoriaId);

        // Pedidos -> Usuarios
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Pedidos)
            .HasForeignKey(p => p.UsuarioId);

        // DetallesPedido -> Pedidos
        modelBuilder.Entity<DetallesPedido>()
            .HasOne(dp => dp.Pedido)
            .WithMany(p => p.DetallesPedidos)
            .HasForeignKey(dp => dp.PedidoId);

        // DetallesPedido -> Productos
        modelBuilder.Entity<DetallesPedido>()
            .HasOne(dp => dp.Producto)
            .WithMany()
            .HasForeignKey(dp => dp.ProductoId);

        // ComentariosProductos -> Productos
        modelBuilder.Entity<ComentariosProducto>()
            .HasOne(cp => cp.Producto)
            .WithMany(p => p.ComentariosProductos)
            .HasForeignKey(cp => cp.ProductoId);

        // ComentariosProductos -> Usuarios
        modelBuilder.Entity<ComentariosProducto>()
            .HasOne(cp => cp.Usuario)
            .WithMany(u => u.ComentariosProductos)
            .HasForeignKey(cp => cp.UsuarioId);

        // CarritoTemporal -> Usuarios
        modelBuilder.Entity<CarritoTemporal>()
            .HasOne(ct => ct.Usuario)
            .WithMany(u => u.CarritoTemporals)
            .HasForeignKey(ct => ct.UsuarioId);

        // CarritoTemporal -> Productos
        modelBuilder.Entity<CarritoTemporal>()
            .HasOne(ct => ct.Producto)
            .WithMany()
            .HasForeignKey(ct => ct.ProductoId);

        //  HistorialCompras -> Usuarios
        modelBuilder.Entity<HistorialCompra>()
            .HasOne(hc => hc.Usuario)
            .WithMany(u => u.HistorialCompras)
            .HasForeignKey(hc => hc.UsuarioId);

        // HistorialCompras -> Productos
        modelBuilder.Entity<HistorialCompra>()
            .HasOne(hc => hc.Producto)
            .WithMany()
            .HasForeignKey(hc => hc.ProductoId);

        //Restrictions
        modelBuilder.Entity<CarritoTemporal>()
            .HasIndex(ct => new { ct.UsuarioId, ct.ProductoId })
            .IsUnique()
            .HasName("UQ_UsuarioProducto_CarritoTemporal");

        modelBuilder.Entity<ComentariosProducto>()
            .HasIndex(cp => new { cp.UsuarioId, cp.ProductoId })
            .IsUnique()
            .HasName("UQ_UsuarioProducto_ComentariosProductos");

        modelBuilder.Entity<DetallesPedido>()
             .Property(dp => dp.PrecioUnitario)
             .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<HistorialCompra>()
            .Property(hc => hc.PrecioTotal)
            .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(10, 2)");
    }

}
