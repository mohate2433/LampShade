﻿using _01_LampShadeQuery.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = _slideQuery.GetSlideQuery();
            return View(slides);
        }
    }
}
