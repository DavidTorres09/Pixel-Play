using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class CategoriasProducto
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
