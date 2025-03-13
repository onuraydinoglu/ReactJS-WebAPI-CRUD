using Server.Entities;

namespace Server.Repositories.Abstracts
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task UpdateProductAsync(Product product);
    }
}