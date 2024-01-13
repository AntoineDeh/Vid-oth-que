namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Repositories.BluRays;
    using VideoTheque.Repositories.Genres;
    using VideoTheque.Repositories.Personnes;
    using VideoTheque.Repositories.Supports;
    using VideoTheque.Repositories.AgeRatings;
    using VideoTheque.Businesses.Films;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("films")]
    public class FilmsController : ControllerBase
    {

        private readonly IFilmsBusiness _FilmsBusiness;
        protected readonly ILogger<FilmsController> _Logger;

        public FilmsController(IFilmsBusiness filmsBusiness, ILogger<FilmsController> logger)
        {
            _FilmsBusiness = filmsBusiness;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<List<FilmViewModel>> GetFilms() => (await _FilmsBusiness.GetFilms()).Adapt<List<FilmViewModel>>();

        [HttpGet("{id}")]
        public async Task<FilmViewModel> GeFilm([FromRoute] int id) => (await _FilmsBusiness.GetFilm(id)).Adapt<FilmViewModel>();

        [HttpPost]
        public async Task<IResult> InsertFilm([FromBody] FilmViewModel filmVM)
        {
            var filmdto = ConvertFilmVmToDto(filmVM);
            var created = _FilmsBusiness.InsertFilm(filmdto.Adapt<FilmDto>());
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateFilm([FromRoute] int id, [FromBody] FilmViewModel filmVM)
        {
            var filmdto = ConvertFilmVmToDto(filmVM);
            _FilmsBusiness.UpdateFilm(id, filmdto.Adapt<FilmDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilm([FromRoute] int id)
        {
            _FilmsBusiness?.DeleteFilm(id);
            return Results.Ok();
        }

        private async Task<FilmDto> ConvertFilmVmToDto(FilmViewModel filmVM)
        {

            return new FilmDto
            {
                Director = new PersonneDto {FirstName= filmVM.Director.Split(' ')[0], LastName = filmVM.Director.Split(' ')[1], Nationality = "France", BirthDay = new DateTime() },
                Scenarist = new PersonneDto {FirstName = filmVM.Scenarist.Split(' ')[0], LastName = filmVM.Scenarist.Split(' ')[1], Nationality = "France", BirthDay = new DateTime() },
                Duration = filmVM.Duration,
                Support = new SupportsDto { Name = filmVM.Support},
                AgeRating = new AgeRatingDto { Name = filmVM.AgeRating},
                Genre = new GenreDto { Name = filmVM.Genre},
                Title = filmVM.Title,
                FirstActor = new PersonneDto {FirstName = filmVM.FirstActor.Split(' ')[0], LastName = filmVM.FirstActor.Split(' ')[1], Nationality = "France", BirthDay = new DateTime() },
            };
        }
    }
}

