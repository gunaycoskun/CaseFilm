using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.CommentDTOs;

namespace MovieProject.Application.Features.CommentCQ.Queries
{
    public class GetCommentsByFilmIdQuery:IRequest<List<CommentDTO>>
    {
        public Guid FilmId { get; set; }
        public class GetCommentsByFilmIdQueryHandler : IRequestHandler<GetCommentsByFilmIdQuery, List<CommentDTO>>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            public GetCommentsByFilmIdQueryHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            public async Task<List<CommentDTO>> Handle(GetCommentsByFilmIdQuery request, CancellationToken cancellationToken)
            {
                var film=await _db.Film.Include(x=>x.Comments).FirstOrDefaultAsync(x=>x.Id==request.FilmId);
                return _mapper.Map<List<CommentDTO>>(film.Comments);
            }
        }
    }
}
