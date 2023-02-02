using AutoMapper;
using MediatR;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.CommentDTOs;
using MovieProject.Domain.Entity;

namespace MovieProject.Application.Features.CommentCQ.Commands
{
    public class CreateCommentCommand : IRequest<CreateCommentDTO>
    {
        public CreateCommentDTO Comment { get; set; }
        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentDTO>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            public CreateCommentCommandHandler(IMovieDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }


            public async Task<CreateCommentDTO> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                await _db.Comment.AddAsync(_mapper.Map<Comment>(request.Comment));
                await _db.SaveChangesAsync(cancellationToken);
                return request.Comment;
            }
        }
    }
}
