using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result> CreateProductAsync(ProductRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Product registration form is required");

        try
        {
            if (await _productRepository.GetAsync(x => ((ProductEntity)x).ProductName == form.ProductName) != null)
                return Result.AlreadyExists("Product with this email already exists");

            var productEntity = ProductFactory.Create(form);

            var result = await _productRepository.CreateAsync(productEntity);
            return result != null ? Result.Ok() : Result.BadRequest("Product registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("Product registration failed");
        }
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProductAsync()
    {
        var productEntities = await _productRepository.GetAllAsync();
        var product = productEntities?.Select(ProductFactory.Create);
        return Result<IEnumerable<Product>>.Ok(product);
    }

    public async Task<IResult> GetProductByIdAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(x => x.Id == id);

        if (productEntity == null)
            return Result.NotFound("Product not found");

        var product = ProductFactory.Create(productEntity);
        return Result<Product>.Ok(product);
    }
    public async Task<IResult> UpdateProductAsync(int id, ProductUpdateForm updateForm)
    {
        var productEntity = await _productRepository.GetAsync(x => x.Id == id);
        if (productEntity == null)
            return Result.NotFound("Product not found");

        productEntity = ProductFactory.Create(productEntity, updateForm);
        var result = await _productRepository.UpdateAsync(x => x.Id == id, productEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Product update failed");
    }

    public async Task<IResult> DeleteProductAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(x => x.Id == id);
        if (productEntity == null)
            return Result.NotFound("Product not found");

        var result = await _productRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Product update failed");
    }

