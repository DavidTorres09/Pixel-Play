﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PixelPlay.Models;

public partial class CarritoTemporal
{
    public int CarritoId { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Usuario Usuario { get; set; }
}