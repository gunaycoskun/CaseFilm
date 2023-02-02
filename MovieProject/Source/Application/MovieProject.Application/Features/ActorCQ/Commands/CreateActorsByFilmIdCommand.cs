using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.ActorDTOs;
using MovieProject.Application.Options;
using MovieProject.Domain.Entity;

namespace MovieProject.Application.Features.ActorCQ.Commands
{
    public class CreateActorsByFilmIdCommand : IRequest<List<CreateActorDTO>>
    {
        public Guid FilmId { get; set; }
        public List<CreateActorDTO> Actors { get; set; }
        public class CreateActorsByFilmIdCommandHandler : IRequestHandler<CreateActorsByFilmIdCommand, List<CreateActorDTO>>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            private readonly IFileUploadService _uploadService;
            private readonly string path;
            public CreateActorsByFilmIdCommandHandler(IMovieDbContext db, IMapper mapper, IFileUploadService uploadService, IOptions<FilePaths> opt)
            {
                _db = db;
                _mapper = mapper;
                _uploadService = uploadService;
                path = opt.Value.UploadPath;
            }

            public async Task<List<CreateActorDTO>> Handle(CreateActorsByFilmIdCommand request, CancellationToken cancellationToken)
            {
                var film = _db.Film.Include(x => x.Actors).FirstOrDefault(x => x.Id == request.FilmId);
                foreach (var item in request.Actors)
                {
                    var actor = await _db.Actor.Include(x=>x.Films).FirstOrDefaultAsync(x => x.NameSurname == item.NameSurname && x.BornDate == item.BornDate);
                    if (actor == null)
                    {
                        Actor newActor = new Actor
                        {
                            BornDate = item.BornDate,
                            NameSurname = item.NameSurname,
                            PictureUrl = await _uploadService.UploadFileAsync(item.Picture, path)
                        };
                        _db.Actor.Add(newActor);
                        film.Actors.Add(newActor);
                    }
                    if (actor!=null && !actor.Films.Any(x => x.Id == request.FilmId))
                    {
                        film.Actors.Add(actor);
                    }                  
                }
                await _db.SaveChangesAsync(cancellationToken);
                return request.Actors;
            }
        }
    }
}
