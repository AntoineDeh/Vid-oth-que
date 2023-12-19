using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class BluRayViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("titre")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("duree")]
        [Required]
        public long Duration { get; set; }

        [JsonPropertyName("acteur-principal")]
        [Required]
        public int IdFirstActor { get; set; }

        [JsonPropertyName("realisateur")]
        [Required]
        public int IdDirector { get; set; }

        [JsonPropertyName("scenariste")]
        [Required]
        public int IdScenarist { get; set; }

        [JsonPropertyName("age-rating")]
        [Required]
        public int IdAgeRating { get; set; }

        [JsonPropertyName("genre")]
        [Required]
        public int IdGenre { get; set; }

        [JsonPropertyName("available")]
        [Required]
        public bool IsAvailable { get; set; }

        [JsonPropertyName("owner")]
        [Required]
        public int? IdOwner { get; set; }

        public BluRayDto ToDto()
        {
            return new BluRayDto
            {
                Id = this.Id,
                Title = this.Title,
                Duration = this.Duration,
                IdFirstActor = this.IdFirstActor,
                IdDirector = this.IdDirector,
                IdScenarist = this.IdScenarist,
                IdAgeRating= this.IdAgeRating,
                IdGenre = this.IdGenre,
                IsAvailable= this.IsAvailable,
                IdOwner = this.IdOwner,
            };
        }

        public static BluRayViewModel ToModel(BluRayDto dto)
        {
            return new BluRayViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Duration = dto.Duration,
                IdFirstActor = dto.IdFirstActor,
                IdDirector = dto.IdDirector,
                IdScenarist = dto.IdScenarist,
                IdAgeRating = dto.IdAgeRating,
                IdGenre = dto.IdGenre,
                IsAvailable = dto.IsAvailable,
                IdOwner = dto.IdOwner,
            };
        }
    }
}
