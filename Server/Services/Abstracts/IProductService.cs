using Server.Entities.DTOs;

namespace Server.Services.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetByIdProductAsync(int id);
        Task AddProductAsync(ProductCreateDto productCreateDto);
        Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
        Task DeleteProductAsync(int id);
    }
}