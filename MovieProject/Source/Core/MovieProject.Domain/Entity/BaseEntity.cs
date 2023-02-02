namespace MovieProject.Domain.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }=Guid.NewGuid();
    }
}
