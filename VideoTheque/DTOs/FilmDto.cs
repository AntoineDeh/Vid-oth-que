namespace VideoTheque.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public PersonneDto Director { get; set; }
        //public string Director { get; set; }
        public PersonneDto Scenarist { get; set; }
        //public string Scenarist { get; set; }
        public int Duration { get; set; }
        public SupportsDto Support { get; set; }
        //public string Support { get; set; }
        public AgeRatingDto AgeRating { get; set; }
        //public string AgeRating { get; set; }
        public GenreDto Genre { get; set; }
        //public string Genre { get; set; }
        public string Title { get; set; }
        public PersonneDto FirstActor { get; set; }
        //public string FirstActor { get; set; }
    }
}
