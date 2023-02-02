namespace MovieProject.Domain.Entity
{
    public class Film:BaseEntity
    {
     
        public string Name { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Actor> Actors { get; set; }

    }
}
