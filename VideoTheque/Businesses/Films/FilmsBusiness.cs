using VideoTheque.DTOs;
using VideoTheque.Core;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Personnes;
using VideoTheque.Repositories.Supports;
using VideoTheque.Repositories.AgeRatings;

namespace VideoTheque.Businesses.Films
{
    public class FilmsBusiness : IFilmsBusiness
    {
        private readonly IBluRaysRepository _BluRayDao;
        private readonly IGenresRepository _GenreDao;
        private readonly IPersonnesRepository _PersonneDao;
        private readonly IAgeRatingsRepository _ageRatingDao;
        private readonly ISupportsRepository _supportsDao;

        public FilmsBusiness(IBluRaysRepository bluRayDao, IGenresRepository genreDao, IPersonnesRepository personneDao, IAgeRatingsRepository ageRatingDao, ISupportsRepository supportsDao)
        {
            _BluRayDao = bluRayDao;
            _GenreDao = genreDao;
            _PersonneDao = personneDao;
            _ageRatingDao = ageRatingDao;
            _supportsDao = supportsDao;
        }

        public async Task<List<FilmDto>> GetFilms()
        {
            var blurays = await _BluRayDao.GetBluRays();
            var filmsDto = new List<FilmDto>();

            foreach(var bluRay in blurays)
            {
                var directeur = await _PersonneDao.GetPersonne(bluRay.IdDirector);
                var scenariste = await _PersonneDao.GetPersonne(bluRay.IdScenarist);
                var limiteAge = await _ageRatingDao.GetAgeRating(bluRay.IdAgeRating);
                var genre = await _GenreDao.GetGenre(bluRay.IdGenre);
                var acteurPrincipal = await _PersonneDao.GetPersonne(bluRay.IdFirstActor);

                filmsDto.Add(new FilmDto
                {
                    Id = bluRay.Id,
                    Director = directeur,
                    Scenarist = scenariste,
                    Duration = (int) bluRay.Duration,
                    Support = await _supportsDao.GetSupport(1),
                    AgeRating = limiteAge,
                    Genre = genre,
                    Title = bluRay.Title,
                    FirstActor = acteurPrincipal
                }
                );
            }
            return filmsDto;
        }

        public async Task<FilmDto> GetFilm(int id)
        {
            var bluRay = await _BluRayDao.GetBluRay(id);

            if(bluRay is null)
            {
                throw new NotFoundException($"Film '{id}' non trouvé");
            }

            var directeur = await _PersonneDao.GetPersonne(bluRay.IdDirector);
            var scenariste = await _PersonneDao.GetPersonne(bluRay.IdScenarist);
            var limiteAge = await _ageRatingDao.GetAgeRating(bluRay.IdAgeRating);
            var genre = await _GenreDao.GetGenre(bluRay.IdGenre);
            var acteurPrincipal = await _PersonneDao.GetPersonne(bluRay.IdFirstActor);

            var filmDto = new FilmDto
            {
                Id = bluRay.Id,
                Director = directeur,
                Scenarist = scenariste,
                Duration = (int)bluRay.Duration,
                Support = await _supportsDao.GetSupport(1),
                AgeRating = limiteAge,
                Genre = genre,
                Title = bluRay.Title,
                FirstActor = acteurPrincipal
            };

            return filmDto;
        }

        public async Task<BluRayDto> InsertFilm(FilmDto film)
        {

            var dir = film.Director != null ? await _PersonneDao.GetPersonne(film.Director.FirstName, film.Director.LastName) : null;
            var sce = film.Scenarist != null ? await _PersonneDao.GetPersonne(film.Scenarist.FirstName, film.Scenarist.LastName) : null;
            var act = film.FirstActor != null ? await _PersonneDao.GetPersonne(film.FirstActor.FirstName, film.FirstActor.LastName) : null;
            var age = film.AgeRating != null ? await _ageRatingDao.GetAgeRating(film.AgeRating.Name) : null;
            var gen = film.Genre != null ? await _GenreDao.GetGenre(film.Genre.Name) : null;


            if (dir == null || sce == null || act == null || age == null || gen == null)
            {
                // Gérer le cas où l'une des références d'objet est null
                throw new NotFoundException("Personne ou entité associée non trouvée");
            }

            var bluRay = new BluRayDto
            {
                Id = film.Id,
                Title = film.Title,
                Duration = film.Duration,
                IdFirstActor = act.Id,
                IdDirector = dir.Id,
                IdScenarist = sce.Id,
                IdAgeRating = age.Id,
                IdGenre = gen.Id,
                IsAvailable = true,
                IdOwner = null,
            };

            if (_BluRayDao.InsertBluRay(bluRay).IsFaulted) 
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du film {bluRay.Title}");
            }
            return bluRay;
        }

        public async void UpdateFilm(int id, FilmDto film)
        {

            var dir = film.Director != null ? await _PersonneDao.GetPersonne(film.Director.FirstName, film.Director.LastName) : null;
            var sce = film.Scenarist != null ? await _PersonneDao.GetPersonne(film.Scenarist.FirstName, film.Scenarist.LastName) : null;
            var act = film.FirstActor != null ? await _PersonneDao.GetPersonne(film.FirstActor.FirstName, film.FirstActor.LastName) : null;
            var age = film.AgeRating != null ? await _ageRatingDao.GetAgeRating(film.AgeRating.Name) : null;
            var gen = film.Genre != null ? await _GenreDao.GetGenre(film.Genre.Name) : null;

            var bluRay = new BluRayDto
            {
                Id = id,
                Title = film.Title,
                Duration = film.Duration,
                IdFirstActor = act.Id,
                IdDirector = dir.Id,
                IdScenarist = sce.Id,
                IdAgeRating = age.Id,
                IdGenre = gen.Id,
                IsAvailable = true,
                IdOwner = null,
            };

            if (_BluRayDao.UpdateBluRay(id, bluRay).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {bluRay.Title}");
            }


        }

        public void DeleteFilm(int id)
        {
            if (_BluRayDao.DeleteBluRay(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression de la personne identifiante {id}");
            }
        }
    }
}
