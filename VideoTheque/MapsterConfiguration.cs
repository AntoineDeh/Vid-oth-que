using Mapster;
using System;
using System.Reflection;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;

namespace VideoTheque
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<FilmDto, FilmViewModel>
                .NewConfig()
                .Map(dest => dest.Director, src => $"{src.Director.FirstName} {src.Director.LastName}")
                .Map(dest => dest.Scenarist, src => $"{src.Scenarist.FirstName} {src.Scenarist.LastName}")
                .Map(dest => dest.Support, src => $"{src.Support.Name}")
                .Map(dest => dest.AgeRating, src => $"{src.AgeRating.Name}")
                .Map(dest => dest.Genre, src => src.Genre.Name)
                .Map(dest => dest.FirstActor, src => $"{src.FirstActor.FirstName} {src.FirstActor.LastName}");

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
