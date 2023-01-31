using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Contracts
{
    public interface IProductRepository : IRepository<long , Product>
    {
        List<ProductDto> Search(SearechProductDto searech);
        EditProductDto GetDetails(long id);
    }
}
