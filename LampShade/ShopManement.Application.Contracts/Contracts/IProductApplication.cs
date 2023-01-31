using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManement.Application.Contracts.Contracts
{
    public interface IProductApplication
    {
        OprationResult Create(CreateProductDto createProductDto);
        OprationResult Edit(EditProductDto editProductDto);
        EditProductDto GetDetails(long id);
        List<ProductDto> Search(SearechProductDto searech);
        public OprationResult IsStock(long id);
        public OprationResult NotInStock(long id);
    }
}
