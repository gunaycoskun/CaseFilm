using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.DTOs.CommentDTOs;
using MovieProject.Application.Features.CommentCQ.Commands;
using MovieProject.Application.Features.CommentCQ.Queries;

namespace MovieProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateCommentDTO> Post([FromBody] CreateCommentDTO Value)
        {
            if (ModelState.IsValid)
            {
                return await _mediator.Send(new CreateCommentCommand { Comment = Value });
            }
            else
            {
                return Value;
            }
        }

        [HttpGet("GetComments")]
        public async Task<List<CommentDTO>> GetComments(GetCommentsByFilmIdQuery comment)
        {            
            return await _mediator.Send(comment);
        }
      
    }
}
