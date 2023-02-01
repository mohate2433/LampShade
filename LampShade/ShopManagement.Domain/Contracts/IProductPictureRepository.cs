using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Contracts
{
    public interface IProductPictureRepository : IRepository<long,ProductPicture>
    {
        EditProductPictureDto GetDetails(long id);
        List<ProductPictureDto> Search(SearchProductPictureDto search);
    }
}
