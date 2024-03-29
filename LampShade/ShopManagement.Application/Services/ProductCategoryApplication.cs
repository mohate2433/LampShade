﻿using _0_Framework.Application;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using ShopManagement.Domain.Services.Contracts;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;

namespace ShopManagement.Application.Services
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OprationResult Create(CreateProductCategoryDto productCategoryDto)
        {
            var opration = new OprationResult();
            if (_productCategoryRepository.Exists(E => E.Name == productCategoryDto.Name))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            
            var slug = productCategoryDto.Slug.Slugify();

            var productcategory = new ProductCategory(
                productCategoryDto.Name,
                productCategoryDto.Descripion,
                productCategoryDto.Picture,
                productCategoryDto.PictureAlt,
                productCategoryDto.PictureTitle,
                productCategoryDto.Keywords,
                productCategoryDto.MetaDescripion,
                slug
                );
            _productCategoryRepository.Create(productcategory);
            _productCategoryRepository.SaveChanges();
            return opration.Succedded();

        }

        public OprationResult Edite(EditeProductCategoryDto productCategoryDto)
        {
            var opration = new OprationResult();
            var productCategory = _productCategoryRepository.Get(productCategoryDto.ID);
            if (productCategory == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (_productCategoryRepository.Exists(E => E.Name == productCategoryDto.Name && E.ID != productCategoryDto.ID))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);

            var slug = productCategoryDto.Slug.Slugify();

            productCategory.Edite
                (
                productCategoryDto.Name,
                productCategoryDto.Descripion,
                productCategoryDto.Picture,
                productCategoryDto.PictureAlt,
                productCategoryDto.PictureTitle,
                productCategoryDto.Keywords,
                productCategoryDto.MetaDescripion,
                slug
                );
            _productCategoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditeProductCategoryDto GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryDto> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryDto> Search(SearchProductCategoryDto productCategoryDto)
        {
            return _productCategoryRepository.Search(productCategoryDto);
        }
    }
}
