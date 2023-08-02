using AutoMapper;
using BackEndApi.DTOs;
using BackEndApi.Models;
using System.Globalization;

namespace BackEndApi.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        //< >
        public AutoMapperProfile()
        {
            #region TipoProducto
            CreateMap<TiposProducto,TiposProductoDTO>().ReverseMap();
            #endregion

            #region Producto

            CreateMap<Producto, ProductoDTO>()
               .ForMember(destino =>
               destino.NombreTipoProducto,
               opt => opt.MapFrom(origen => origen.NombreProducto))
              .ForMember(destino =>
               destino.FechaRegistro,
               opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyy"))
             );

            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                    destino.Id,
                    opt => opt.Ignore()
                )
                .ForMember(destino => destino.FechaRegistro,
                    opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaRegistro, "yy/MM/yyyy", 
                    CultureInfo.InvariantCulture))
                );

            #endregion
        }
    }
}
