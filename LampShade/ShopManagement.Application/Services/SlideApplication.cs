using _0_Framework.Application;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.SlideAggregate;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.SlideDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Services
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OprationResult Create(CreateSlideDto command)
        {
            var Operation = new OprationResult();
            var slide = new Slide
                (
                    command.Picture,
                    command.PictureAlt,
                    command.PictureTitle,
                    command.Heading,
                    command.Title,
                    command.Text,
                    command.BtnText,
                    command.Link
                );
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OprationResult Edit(EditSlideDto command)
        {
            var Operation = new OprationResult();
            var slide = _slideRepository.Get(command.ID);
            if (slide == null)
                return Operation.Failed(ApplicationMessages.NotFoundMessage);
            slide.Edit
                (
                    command.Picture,
                    command.PictureAlt,
                    command.PictureTitle,
                    command.Heading,
                    command.Title,
                    command.Text,
                    command.BtnText,
                    command.Link
                );
            _slideRepository.SaveChanges();
            return Operation.Succedded();
        }

        public EditSlideDto GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideDto> GetSlides()
        {
            return _slideRepository.GetSlides();
        }

        public OprationResult Remove(long id)
        {
            var Operation = new OprationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return Operation.Failed(ApplicationMessages.NotFoundMessage);
            slide.Remove();
            _slideRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OprationResult Restore(long id)
        {
            var Operation = new OprationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return Operation.Failed(ApplicationMessages.NotFoundMessage);
            slide.Restore();
            _slideRepository.SaveChanges();
            return Operation.Succedded();
        }
    }
}
