using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using MovieProject.Application.Abstracts;
using MovieProject.Application.DTOs.FilmDTOs;
using MovieProject.Application.Options;
using MovieProject.Domain.Entity;

namespace MovieProject.Application.Features.FilmCQ.Commands
{
    public class CreateFilmQuery:IRequest<CreateFilmDTO>
    {
        public CreateFilmDTO film { get; set; }
        public class CreateFilmQueryHandler : IRequestHandler<CreateFilmQuery, CreateFilmDTO>
        {
            private readonly IMovieDbContext _db;
            private readonly IMapper _mapper;
            private readonly IFileUploadService _uploadService;
            private readonly string path;
            public CreateFilmQueryHandler(IMovieDbContext db, IMapper mapper, IFileUploadService uploadService, IOptions<FilePaths> opt)
            {
                _db = db;
                _mapper = mapper;
                _uploadService = uploadService;
                path = opt.Value.UploadPath;
            }

            public async Task<CreateFilmDTO> Handle(CreateFilmQuery request, CancellationToken cancellationToken)
            {             
                Film data=_mapper.Map<Film>(request.film);
                data.PosterUrl = await _uploadService.UploadFileAsync(request.film.Poster, path);
                await _db.Film.AddAsync(data);
                await _db.SaveChangesAsync();              
                return request.film;
            }
        }
    }
}
