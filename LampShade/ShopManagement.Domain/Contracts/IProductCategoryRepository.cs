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
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory productCategory);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
        bool Exists(Expression<Func<ProductCategory, bool>> expression);
        void SaveChanges();
        EditeProductCategoryDto GetDetails(long id);
        List<ProductCategoryDto> Search(SearchProductCategoryDto searchProduct);
    }
}
