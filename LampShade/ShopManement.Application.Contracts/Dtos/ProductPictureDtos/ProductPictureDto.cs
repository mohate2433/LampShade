using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManement.Application.Contracts.Dtos.ProductPictureDtos
{
    public class ProductPictureDto
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string? Product { get; set; }
        public string? Picture { get; set; }
        public string? CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
