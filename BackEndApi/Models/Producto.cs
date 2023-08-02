using System;
using System.Collections.Generic;

namespace BackEndApi.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? NombreProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Existencia { get; set; }

    public int? TipoProductoId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaEliminado { get; set; }

    public virtual TiposProducto? TipoProducto { get; set; }
}
