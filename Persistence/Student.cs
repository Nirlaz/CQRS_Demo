namespace Persistence
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FullName { get; set; }

        public int? Age { get; set; }
        public string? Class { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
