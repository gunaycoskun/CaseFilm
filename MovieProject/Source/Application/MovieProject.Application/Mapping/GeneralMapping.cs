using AutoMapper;
using MovieProject.Application.DTOs.ActorDTOs;
using MovieProject.Application.DTOs.CommentDTOs;
using MovieProject.Application.DTOs.FilmDTOs;
using MovieProject.Domain.Entity;

namespace MovieProject.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Film,CreateFilmDTO>().ReverseMap();
            CreateMap<Film,FilmDTO>().ReverseMap().ForMember(a=>a.Actors,opt=>opt.Ignore());
            CreateMap<Comment,CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Actor, CreateActorDTO>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Film, ActorFilmsDTO>().ReverseMap();
        }
    }
}
