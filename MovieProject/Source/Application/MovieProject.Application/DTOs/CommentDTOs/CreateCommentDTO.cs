namespace MovieProject.Application.DTOs.CommentDTOs
{
    public record CreateCommentDTO(Guid FilmId, string CommenterName, string Contents, DateTime CreatedDate);
}
