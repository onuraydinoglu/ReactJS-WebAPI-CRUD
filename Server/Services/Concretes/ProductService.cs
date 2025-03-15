using AutoMapper;
using Server.Entities;
using Server.Entities.DTOs;
using Server.Repositories.Abstracts;
using Server.Services.Abstracts;

namespace Server.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (!products.Any())
                throw new Exception("Ürün bulunamadı!");

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task AddProductAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);  // ProductCreateDto -> Entity

            if (product.Price <= 0)
                throw new Exception("Ürün fiyatı sıfır veya negatif olamaz.");

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);  // productUpdateDto -> Entity

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new Exception("Ürün ismi boş olamaz.");

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}