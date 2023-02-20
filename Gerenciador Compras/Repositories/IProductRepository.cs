using Gerenciador_Compras.Models;

namespace Gerenciador_Compras.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
