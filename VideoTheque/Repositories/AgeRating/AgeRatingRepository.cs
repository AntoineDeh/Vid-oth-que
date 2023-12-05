using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.AgeRating
{
    public class AgeRatingRepository : IAgeRatingRepository
    {
        private readonly VideothequeDb _db;
        public AgeRatingRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<AgeRatingDto>> GetAgeRatings() => _db.AgeRatings.ToListAsync();

        public ValueTask<AgeRatingDto?> GetAgeRating(int id) => _db.AgeRatings.FindAsync(id);

        public Task InsertAgeRating(AgeRatingDto genre)
        {
            _db.AgeRatings.AddAsync(AgeRating);
            return _db.AgeRatings.SaveChangesAsync();
        }

        public Task UpdateAgeRating(int id, AgeRatingDto genre)
        {

        }

        public Task DeleteAgeRating(int id)
        {

        }
    }
}
