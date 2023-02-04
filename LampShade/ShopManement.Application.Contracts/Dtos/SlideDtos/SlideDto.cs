namespace ShopManement.Application.Contracts.Dtos.SlideDtos
{
    public class SlideDto
    {
        public long ID { get; set; }
        public string? Picture { get; set; }
        public string? Heading { get; set; }
        public string? Title { get; set; }
        public string? CreationDate { get; set; }
        public string? Link { get; set; }
        public bool IsRemoved { get; set; }

    }
}
