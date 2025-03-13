using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Repositories.Abstracts;
using Server.Repositories.Context;

namespace Server.Repositories.Concretes
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var updateProduct = await GetByIdAsync(product.Id);
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;

            _context.Products.Update(updateProduct);
            await SaveAsync();
        }
    }
}