using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.DTOs.ActorDTOs;
using MovieProject.Application.DTOs.FilmDTOs;
using MovieProject.Application.Features.ActorCQ.Commands;
using MovieProject.Application.Features.ActorCQ.Queries;

namespace MovieProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<List<CreateActorDTO>> Post([FromForm] List<CreateActorDTO> Value, Guid FilmId)
        {

            if (ModelState.IsValid)
            {
                return await _mediator.Send(new CreateActorsByFilmIdCommand { Actors = Value, FilmId = FilmId });
            }
            else
            {
                return Value;
            }
        }

        [HttpGet]
        public async Task<List<ActorDTO>> Get()
        {
            return await _mediator.Send(new GetAllActorsQuery());
        }

        [HttpGet("GetActorFilms")]
        public async Task<List<ActorFilmsDTO>> GetActorFilms(GetActorWithFilmByIdQuery comment)
        {
            return await _mediator.Send(comment);
        }
    }
}
