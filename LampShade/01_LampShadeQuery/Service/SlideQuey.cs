using _01_LampShadeQuery.Contract;
using _01_LampShadeQuery.Model;
using ShopManagement.Infrastructure;

namespace _01_LampShadeQuery.Service
{
    public class SlideQuey : ISlideQuery
    {
        private readonly ShopDbContext _context;

        public SlideQuey(ShopDbContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlideQuery()
        {
            return _context.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Text = x.Text,
                BtnText = x.BtnText,
                Link = x.Link,
                Title = x.Title
            }).ToList();
        }
    }
}
