using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace MovieProject.Application.DTOs.FilmDTOs
{
    public class CreateFilmDTO
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public IFormFile Poster { get; set; }
    }
}
