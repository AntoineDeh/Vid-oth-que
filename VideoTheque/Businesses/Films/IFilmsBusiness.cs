using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Films
{
    public interface IFilmsBusiness
    {
        Task<List<FilmDto>> GetFilms();

        Task<FilmDto> GetFilm(int id);

        Task<BluRayDto> InsertFilm(FilmDto film);

        void UpdateFilm(int id, FilmDto film);

        void DeleteFilm(int id);
    }
}
