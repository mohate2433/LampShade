using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Services.Contracts
{
    public interface IProductCategoryRepository : IRepository<long , ProductCategory>
    {
        EditeProductCategoryDto GetDetails(long id);
        List<ProductCategoryDto> Search(SearchProductCategoryDto searchProduct);
    }
}
