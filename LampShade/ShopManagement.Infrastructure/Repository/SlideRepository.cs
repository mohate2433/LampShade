﻿using _0_Framework.Infrastructure;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.SlideAggregate;
using ShopManement.Application.Contracts.Dtos.SlideDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class SlideRepository : Repository<long, Slide>, ISlideRepository
    {
        private readonly ShopDbContext _context;

        public SlideRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public EditSlideDto GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlideDto
            {
                BtnText = x.BtnText,
                Heading = x.Heading,
                ID = x.ID,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Text = x.Text
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<SlideDto> GetSlides()
        {
            return _context.Slides.Select(x => new SlideDto
            {
                ID = x.ID,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsRemoved = x.IsRemoved
            }).OrderByDescending(x => x.ID).ToList();
        }
    }
}
