using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.ActorDTOs;

namespace MovieProject.Application.Features.ActorCQ.Queries
{
    public class GetAllActorsQuery:IRequest<List<ActorDTO>>
    {
        public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, List<ActorDTO>>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            public GetAllActorsQueryHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            public async Task<List<ActorDTO>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<ActorDTO>>(await _db.Actor.ToListAsync());
            }
        }
    }
}
