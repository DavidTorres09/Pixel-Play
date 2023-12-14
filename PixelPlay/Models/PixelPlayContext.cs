using Microsoft.EntityFrameworkCore;
using PixelPlay.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<CategoriasProducto> categorias { get; set; }
    public DbSet<Producto> producto { get; set; }
    public DbSet<Pedido> pedidos { get; set; }
    public DbSet<DetallesPedido> detallesPedidos { get; set; }
    public DbSet<ComentariosProducto> comentariosProductos { get; set; }
    public DbSet<CarritoTemporal> carritoTemporal { get; set; }
    public DbSet<HistorialCompra> historialCompras { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Configuración para la restricción única en CarritoTemporal
        modelBuilder.Entity<CarritoTemporal>()
            .HasIndex(ct => new { ct.UsuarioId, ct.ProductoId })
            .IsUnique()
            .HasName("UQ_UsuarioProducto_CarritoTemporal");

        // Configuración para la restricción única en ComentariosProductos
        modelBuilder.Entity<ComentariosProducto>()
            .HasIndex(cp => new { cp.UsuarioId, cp.ProductoId })
            .IsUnique()
            .HasName("UQ_UsuarioProducto_ComentariosProductos");
    }

}
