namespace Vitasmart.Domain
{
    public class Visiting : BaseEntity
    {
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string? Diagnose { get; set; }
        public Patient? Patient { get; set; }
    }
}
