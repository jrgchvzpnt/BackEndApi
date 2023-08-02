using BackEndApi.Models;

namespace BackEndApi.Services.Contrato
{

    public interface IProductoService
    {
        Task<List<Producto>> GetList();
        Task<Producto> Get(int idproducto);
        Task<Producto> Add(Producto modelo);
        Task<bool> Update(Producto modelo);
        Task<bool> Delete(Producto modelo);
    }
}
