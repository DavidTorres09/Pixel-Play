using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class HistorialCompra
{
    public int HistorialId { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public DateTime FechaCompra { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioTotal { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
