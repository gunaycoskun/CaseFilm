using MovieProject.Domain.Entity;

namespace MovieProject.Application.DTOs.FilmDTOs
{
    public class FilmDTO
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string PosterUrl { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
