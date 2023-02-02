namespace MovieProject.Application.DTOs.CommentDTOs
{
    public record CommentDTO(Guid FilmId, string CommenterName, string Contents, DateTime CreatedDate);
   
}
