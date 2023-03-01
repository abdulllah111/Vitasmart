﻿namespace Vitasmart.Domain
{
    public class Patient : BaseEntity
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }
        public long PhoneNumber { get; set; }
        public ICollection<Visiting>? Visitings { get; set; }
    }
}
