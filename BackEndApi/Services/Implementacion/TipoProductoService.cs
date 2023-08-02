using Microsoft.EntityFrameworkCore;
using BackEndApi.Models;
using BackEndApi.Services.Contrato;
using System.Collections.Generic;

namespace BackEndApi.Services.Implementacion
{ 
    public class TipoProductoService : ITipoProductoService
    {
        private VentasContext _dbContext;

        public TipoProductoService(VentasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TiposProducto>> GetList()
        {
            try
            {
                List<TiposProducto> lista = new List<TiposProducto>();
                lista = await _dbContext.TiposProductos.ToListAsync();
                 return lista;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
