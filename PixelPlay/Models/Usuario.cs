using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<CarritoTemporal> CarritoTemporals { get; set; } = new List<CarritoTemporal>();

    public virtual ICollection<ComentariosProducto> ComentariosProductos { get; set; } = new List<ComentariosProducto>();

    public virtual ICollection<HistorialCompra> HistorialCompras { get; set; } = new List<HistorialCompra>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
