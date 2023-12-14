using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class ComentariosProducto
{
    public int ComentarioId { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public string Comentario { get; set; } = null!;

    public DateTime FechaComentario { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
