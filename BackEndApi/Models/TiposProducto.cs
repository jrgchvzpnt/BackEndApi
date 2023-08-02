using System;
using System.Collections.Generic;

namespace BackEndApi.Models;

public partial class TiposProducto
{
    public int Id { get; set; }

    public string? NombreTipoProducto { get; set; }

    public string? DescripcionTipoProducto { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaEliminado { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
