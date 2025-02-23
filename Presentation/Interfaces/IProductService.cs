using Business.Dtos;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public interface IProductService
    {
        Task<IResult> CreateDefaultProducts();
        Task<Result> CreateProductAsync(ProductRegistrationForm form);
        Task<IResult> DeleteProductAsync(int id);
        Task<Result<IEnumerable<Product>>> GetAllProductAsync();
        Task<IResult> GetProductByIdAsync(int id);
        Task<IResult> GetProductByNameAsync(string productName);
    }
}