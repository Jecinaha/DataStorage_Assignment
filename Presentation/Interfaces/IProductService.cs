using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductRegistrationForm form);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<Product> UpdateProductAsync(ProductUpdateForm form);
    }
}