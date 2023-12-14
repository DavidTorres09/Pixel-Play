using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class CarritoTemporal
{
    public int CarritoId { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
