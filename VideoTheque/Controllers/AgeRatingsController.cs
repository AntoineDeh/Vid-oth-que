namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.AgeRatings;
    using VideoTheque.Businesses.Genres;
    using VideoTheque.DTOs;
    using VideoTheque.Repositories.AgeRatings;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("age-ratings")]
    public class AgeRatingsController : ControllerBase
    {
        private readonly IAgeRatingsBusiness _ageRatingsBusiness;
        protected readonly ILogger<AgeRatingsController> _logger;

        public AgeRatingsController(ILogger<AgeRatingsController> logger, IAgeRatingsBusiness ageRatingsBusiness)
        {
            _logger = logger;
            _ageRatingsBusiness = ageRatingsBusiness;
        }

        [HttpGet]
        public async Task<List<AgeRatingsViewModel>> GetAgeRatings() => (await _ageRatingsBusiness.GetAgeRatings()).Adapt<List<AgeRatingsViewModel>>();

        [HttpGet("{id}")]
        public async Task<AgeRatingsViewModel> GetAgeRating([FromRoute] int id) => _ageRatingsBusiness.GetAgeRating(id).Adapt<AgeRatingsViewModel>();

        [HttpPost]
        public async Task<IResult> InsentAgeRating([FromBody] AgeRatingsViewModel ageRatingVM)
        {
            var created = _ageRatingsBusiness.InsertAgeRating(ageRatingVM.Adapt<AgeRatingDto>());
            return Results.Created($"/age-ratings/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateAgeRating([FromRoute] int id, [FromBody] AgeRatingsViewModel ageRatingsVM)
        {
            _ageRatingsBusiness.UpdateAgeRating(id, ageRatingsVM.Adapt<AgeRatingDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAgeRating([FromRoute] int id)
        {
            _ageRatingsBusiness.DeleteAgeRating(id);
            return Results.Ok();
        }
    }
}
