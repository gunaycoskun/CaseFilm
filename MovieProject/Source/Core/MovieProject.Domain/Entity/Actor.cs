namespace MovieProject.Domain.Entity
{
    public class Actor:BaseEntity
    {
        public ICollection<Film> Films { get; set; }
        public string NameSurname { get; set; }
        public DateTime BornDate { get; set; }
        public string PictureUrl { get; set; }

    }
}
