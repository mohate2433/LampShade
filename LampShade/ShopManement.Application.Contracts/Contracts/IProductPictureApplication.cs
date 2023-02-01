using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManement.Application.Contracts.Contracts
{
    public interface IProductPictureApplication
    {
        OprationResult Create(CreateProductPictureDto command);
        OprationResult Edit(EditProductPictureDto command);
        OprationResult Remove(long id);
        OprationResult Restore(long id);
        EditProductPictureDto GetDetails(long id);
        List<ProductPictureDto> Search(SearchProductPictureDto search);
    }
}
