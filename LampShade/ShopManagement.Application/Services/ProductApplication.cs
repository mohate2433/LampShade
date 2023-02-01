using _0_Framework.Application;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductDtos;

namespace ShopManagement.Application.Services
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OprationResult Create(CreateProductDto createProductDto)
        {
            var opration = new OprationResult();
            if (_productRepository.Exists(E => E.Name == createProductDto.Name))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);

            var slug = createProductDto.Slug.Slugify();
            var product = new Product(
                createProductDto.Name ,
                createProductDto.Code,
                createProductDto.UnitPrice,
                createProductDto.ShortDescription,
                createProductDto.Description,
                createProductDto.Picture,
                createProductDto.PictureAlt,
                createProductDto.PictureTitle,
                createProductDto.Keywords,
                createProductDto.MetaDescription,
                slug,
                createProductDto.CategoryID
                );
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult Edit(EditProductDto editProductDto)
        {
            var opration = new OprationResult();
            var product = _productRepository.Get(editProductDto.ID);
            if (product == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (_productRepository.Exists(E => E.Name == editProductDto.Name && E.ID != editProductDto.ID))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);

            var slug = editProductDto.Slug.Slugify();

            product.Edit
            (
                editProductDto.Name,
                editProductDto.Code,
                editProductDto.UnitPrice,
                editProductDto.ShortDescription,
                editProductDto.Description,
                editProductDto.Picture,
                editProductDto.PictureAlt,
                editProductDto.PictureTitle,
                editProductDto.Keywords,
                editProductDto.MetaDescription,
                slug,
                editProductDto.CategoryID
            );
            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditProductDto GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OprationResult IsStock(long id)
        {
            var opration = new OprationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (product.IsInStock==true)
                return opration.Succedded();

            product.InStock();

            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult NotInStock(long id)
        {
            var opration = new OprationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (product.IsInStock == false)
                return opration.Succedded();

            product.NotInstock();

            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public List<ProductDto> Search(SearechProductDto searech)
        {
            return _productRepository.Search(searech);
        }
    }
}
