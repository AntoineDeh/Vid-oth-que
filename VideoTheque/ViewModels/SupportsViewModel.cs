using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class SupportsViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        
        [JsonPropertyName("nom")]
        [Required]
        public string Name { get; set; }


        public SupportsDto ToDto()
        {
            return new SupportsDto
            {
                Id = this.Id,
                Name = this.Name
            };
        }

        public static SupportsViewModel ToModel(SupportsDto dto)
        {
            return new SupportsViewModel
            {
                Id = dto.Id,
                Name = dto.Name

            };
        }
    }
}
