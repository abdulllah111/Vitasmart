namespace Vitasmart.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateOnly DateAdded { get; set; }
        public DateOnly? DateUpdated { get; set; }
    }
}
