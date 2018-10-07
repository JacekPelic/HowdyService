using AutoMapper;
using HowdyService.Dal.Entities;
using HowdyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyService.Configuration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Question, QuestionAnwserView>()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Text));
            CreateMap<Gif, GifView>()
                .ForMember(dest => dest.GiphySource, opt => opt.ResolveUsing<CustomResolver>());
        }
    }

    public class CustomResolver : IValueResolver<Gif, GifView, string>
    {
        public string Resolve(Gif source, GifView destination, string destMember, ResolutionContext context)
        {
            return $"https://media.giphy.com/media/{source.GiphyId}/giphy.gif";
        }
    }
}
