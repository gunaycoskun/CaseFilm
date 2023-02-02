using Microsoft.AspNetCore.Http;

namespace MovieProject.Application.DTOs.ActorDTOs
{
    public class CreateActorDTO
    {
        public string NameSurname { get; set; }
        public DateTime BornDate { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
