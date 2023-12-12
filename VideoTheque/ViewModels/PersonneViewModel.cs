using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class PersonneViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("prenom")]
        [Required]
        public string FirstName { get; set;}

        [JsonPropertyName("nom")]
        [Required]
        public string LastName { get; set; }

        [JsonPropertyName("nationalite")]
        [Required]
        public string Nationality { get; set; }

        [JsonPropertyName("date-naissance")]
        [Required]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("nom-prenom")]
        [Required]
        public string FullName => $"{FirstName} {LastName}";

        public PersonneDto ToDto()
        {
            return new PersonneDto
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Nationality = this.Nationality,
                BirthDay = this.Birthday
            };
        }

        public static PersonneViewModel ToModel(PersonneDto dto)
        {
            return new PersonneViewModel
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Nationality = dto.Nationality,
                Birthday = dto.BirthDay
            };
        }
    }
}
