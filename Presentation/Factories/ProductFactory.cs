

using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;


public static class ProductFactory
{
        public static ProductRegistrationForm Create() => new();

        public static ProductEntity Create(ProductRegistrationForm form) => new()
        {
            ProductName = form.ProductName,
        };

        public static Product Create(ProductEntity entity) => new()
        {
            Id = entity.Id,
            ProductName = entity.ProductName
        };

        public static ProductEntity Create(ProductEntity productEntity, ProductUpdateForm updateForm) => new()
        {
            Id = productEntity.Id,
            ProductName = updateForm.ProductName,

        };



    }
