using BackEndApi.Models;

namespace BackEndApi.Services.Contrato
{
    public interface ITipoProductoService
    {
        Task<List<TiposProducto>> GetList();
    }
}
