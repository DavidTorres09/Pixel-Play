using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class DetallesPedido
{
    public int DetalleId { get; set; }

    public int PedidoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
