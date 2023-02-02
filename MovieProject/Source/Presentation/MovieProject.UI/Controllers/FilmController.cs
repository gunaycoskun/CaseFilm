using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.FilmDTOs;
using MovieProject.Application.Features.FilmCQ.Commands;
using MovieProject.Application.Features.FilmCQ.Queries;
using MovieProject.Domain.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieProject.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<List<FilmDTO>> Get()
        {
            return await _mediator.Send(new GetAllFilmsQuery());
        }

    
        [HttpGet("{id}")]
        public async Task<FilmDTO> Get(Guid id)
        {
            return await _mediator.Send(new GetFilmByIdQuery { Id=id});
        }

       
        [HttpPost]
        public async Task<CreateFilmDTO> Post([FromForm] CreateFilmDTO value)
        {
            if (ModelState.IsValid)
            {
               return await _mediator.Send(new CreateFilmQuery { film = value }); 
            }
            else
            {
                return value;
            }
        }

     
       
    }
}
