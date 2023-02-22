namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long ID { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
