using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string UrlImagen { get; set; } = null!;

    public int CategoriaId { get; set; }

    public virtual ICollection<CarritoTemporal> CarritoTemporals { get; set; } = new List<CarritoTemporal>();

    public virtual CategoriasProducto Categoria { get; set; } = null!;

    public virtual ICollection<ComentariosProducto> ComentariosProductos { get; set; } = new List<ComentariosProducto>();

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual ICollection<HistorialCompra> HistorialCompras { get; set; } = new List<HistorialCompra>();
}
