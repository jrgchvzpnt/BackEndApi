using Microsoft.EntityFrameworkCore;
using BackEndApi.Models;
using BackEndApi.Services.Contrato;

namespace BackEndApi.Services.Implementacion
{
    public class ProductoService : IProductoService
    {
        private VentasContext _dbContext;

        public ProductoService(VentasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Producto>> GetList()
        {
            try
            {
               List<Producto> lista = new List<Producto>();    
               lista = await _dbContext.Productos.Include(opt => opt.TipoProducto).ToListAsync();
                return lista;

                /*
                List<Producto> lista = new List<Producto>();
                lista = await _dbContext.Productos.ToListAsync();
                return lista;
                */
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Producto> Get(int idproducto)
        {
            try
            {
                Producto? encontrado = new Producto();
                encontrado = await _dbContext.Productos.Include(dpt => dpt.TipoProductoId)
                    .Where(p => p.Id == idproducto).FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Producto> Add(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Producto modelo)
        {
            try
            {
                _dbContext.Productos.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
