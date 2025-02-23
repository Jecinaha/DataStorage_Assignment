using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<Result> CreateProductAsync(ProductRegistrationForm form);
        Task<IResult> DeleteProductAsync(int id);
        Task<Result<IEnumerable<Product>>> GetAllProductAsync();
        Task<IResult> GetProductByIdAsync(int id);
        Task<IResult> UpdateProductAsync(int id, ProductUpdateForm updateForm);
    }
}