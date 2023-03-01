namespace Vitasmart.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
