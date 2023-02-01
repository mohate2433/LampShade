using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.SlideAggregate;
using ShopManement.Application.Contracts.Dtos.SlideDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Contracts
{
    public interface ISlideRepository :IRepository<long , Slide>
    {
        EditSlideDto GetDetails(long id);
        List<SlideDto> GetSlides();
    }
}
