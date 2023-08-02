namespace BackEndApi.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? NombreProducto { get; set; }

        public string? DescripcionProducto { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Existencia { get; set; }

        public int? TipoProductoId { get; set; }
        public string? NombreTipoProducto { get; set; }

        public string? FechaRegistro { get; set; }
    }
}
