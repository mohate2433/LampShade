using _0_Framework.Application;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;

namespace ShopManagement.Application.Services
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OprationResult Create(CreateProductPictureDto command)
        {
            var Opration = new OprationResult();
            if (_productPictureRepository.Exists(x => x.ProductID == command.ProductID && x.Picture == command.Picture))
                return Opration.Failed(ApplicationMessages.DuplicatedMessage);
            var productPicture = new ProductPicture(command.ProductID, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return Opration.Succedded();
        }

        public OprationResult Edit(EditProductPictureDto command)
        {
            var opration = new OprationResult();
            var productPicture = _productPictureRepository.Get(command.ID);
            if (productPicture == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (_productPictureRepository.Exists(x => x.Picture == productPicture.Picture && x.ProductID == productPicture.ProductID && x.ID != productPicture.ID))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            productPicture.Edite
                (
                command.ProductID,
                command.Picture,
                command.PictureAlt,
                command.PictureTitle
                );
            _productPictureRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditProductPictureDto GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OprationResult Remove(long id)
        {
            var opration = new OprationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult Restore(long id)
        {
            var opration = new OprationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return opration.Failed(ApplicationMessages.NotFoundMessage);
            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return opration.Succedded();
        }

        public List<ProductPictureDto> Search(SearchProductPictureDto search)
        {
            return _productPictureRepository.Search(search);
        }
    }
}
