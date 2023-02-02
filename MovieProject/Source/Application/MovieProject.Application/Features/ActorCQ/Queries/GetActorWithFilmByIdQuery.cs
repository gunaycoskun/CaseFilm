using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.FilmDTOs;

namespace MovieProject.Application.Features.ActorCQ.Queries
{
    public class GetActorWithFilmByIdQuery:IRequest<List<ActorFilmsDTO>>
    {
        public Guid Id { get; set; }
        public class GetActorWithFilmByIdQueryHandler : IRequestHandler<GetActorWithFilmByIdQuery, List<ActorFilmsDTO>>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            public GetActorWithFilmByIdQueryHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            public async Task<List<ActorFilmsDTO>> Handle(GetActorWithFilmByIdQuery request, CancellationToken cancellationToken)
            {
                List<ActorFilmsDTO> result = new();
                var actor=await _db.Actor.Include(x=>x.Films).FirstOrDefaultAsync(x=>x.Id==request.Id);
                if (actor != null)
                {
                    result= _mapper.Map<List<ActorFilmsDTO>>(actor.Films);
                }
                return result;
            }
        }
    }
}
