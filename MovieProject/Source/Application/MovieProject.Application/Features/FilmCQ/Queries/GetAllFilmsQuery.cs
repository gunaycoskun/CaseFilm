using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.FilmDTOs;

namespace MovieProject.Application.Features.FilmCQ.Queries
{
    public class GetAllFilmsQuery:IRequest<List<FilmDTO>>
    {
        public class GetAllFilmsQueryHandler : IRequestHandler<GetAllFilmsQuery, List<FilmDTO>>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;

            public GetAllFilmsQueryHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<List<FilmDTO>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
            {
               return _mapper.Map<List<FilmDTO>>(await _db.Film.ToListAsync(cancellationToken));              
            }
        }
    }
}
