using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.FilmDTOs;

namespace MovieProject.Application.Features.FilmCQ.Queries
{
    public class GetFilmByIdQuery:IRequest<FilmDTO>
    {
        public Guid Id { get; set; }
        public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDTO>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            public GetFilmByIdQueryHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            public async Task<FilmDTO> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
            {              
                return _mapper.Map<FilmDTO>(await _db.Film.Include(a=>a.Actors).FirstOrDefaultAsync(x=>x.Id==request.Id));
            }
        }
    }
}
