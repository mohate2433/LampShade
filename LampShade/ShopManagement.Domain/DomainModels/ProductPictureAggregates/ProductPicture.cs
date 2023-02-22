using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductAggregate;

namespace ShopManagement.Domain.DomainModels.ProductPictureAggregates
{
    public class ProductPicture :EntityBase
    {
        public long ProductID { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }
        public Product Product { get; private set; }


        public ProductPicture(long productID, string? picture, string? pictureAlt, string? pictureTitle)
        {
            ProductID = productID;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }
        public void Edite(long productID, string? picture, string? pictureAlt, string? pictureTitle)
        {
            ProductID = productID;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
         
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
