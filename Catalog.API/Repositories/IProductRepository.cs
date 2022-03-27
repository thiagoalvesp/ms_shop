using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> GetProducts();
         Task<Product> GetProduct(string id);
         Task<IEnumerable<Product>> GetByName(string name);
         Task<IEnumerable<Product>> GetByCategory(string category);
         Task CreateProduct(Product product);
         Task<bool> UpdateProduct(Product product);
         Task<bool> DeleteProduct(string id);

    }
}