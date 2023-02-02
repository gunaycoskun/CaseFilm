namespace MovieProject.Domain.Entity
{
    public class Comment:BaseEntity
    {
        public Guid FilmId { get; set; }
        public Film Film { get; set; }
        public string CommenterName { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
